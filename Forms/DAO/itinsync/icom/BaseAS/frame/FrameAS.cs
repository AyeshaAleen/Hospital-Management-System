using DAO.itinsync.icom.audit;
using DAO.itinsync.icom.BaseAS.dbcontext;
using DAO.itinsync.icom.task;
using DAO.itinsync.icom.task.taskdefinition;
using domains.itinsync.audit;
using domains.itinsync.task;
using Domains.itinsync.icom.header;
using Domains.itinsync.icom.interfaces.request;
using Domains.itinsync.icom.interfaces.response;
using Domains.itinsync.icom.task.taskdedinition;
using System;
using Utils.itinsync.icom.cache.task.taskdefinition;
using Utils.itinsync.icom.constant.application;
using Utils.itinsync.icom.constant.lookup;
using Utils.itinsync.icom.date;
using Utils.itinsync.icom.exceptions;

namespace DAO.itinsync.icom.BaseAS.frame
{
    public abstract class FrameAS :BaseAS
    {
        protected abstract IResponseHandler executeBody(object o);
        public IResponseHandler executeAsSecondary(object o, DBContext dbContext)
        {
            IResponseHandler responseHandler = null;
            try
            {
                this.dbContext = dbContext;
                responseHandler = executeBody(o);
                //execute method incase we execute as secondary
                perCommit();
                postCommit();
            }
            catch (ItinsyncException exception)
            {
                throw new ItinsyncException(exception);
            }
            return responseHandler;
        }
        public IResponseHandler executeAsPrimary(object o)
        {
            IResponseHandler responseHandler = null;// new GenaricResponse();
            bool bCommit = false;
            try
            {
                startTransaction();
                //do business transaction
                if (o != null && typeof(IRequestHandler).IsAssignableFrom(o.GetType()))
                    doBusinessTranscation((IRequestHandler)o);
                else
                    dbContext.setHeader(new Header());

                responseHandler = executeBody(o);
                if (responseHandler.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
                    bCommit = true;
            }
            catch (ItinsyncException exception)
            {
                responseHandler = new GenaricResponse();
                responseHandler.getErrorBlock().ErrorCode = exception.code;
                responseHandler.getErrorBlock().ErrorText = exception.errorMessage;
                bCommit = false;
            }
            finally
            {
                endTransaction(bCommit);
            }
            return responseHandler;
        }
        protected Task diaryRequest(string name, Int32 subjectid, string body)
        {
            return diaryRequest(name, subjectid, body, 1);
        }
        protected Task diaryRequest(string name, Int32 subjectid, string body,Int32 priority)
        {
            TaskDefinition td = TaskDefinitionManager.readbyName(name);
            Task task = new Task();
            task.body = td.body + " : " + body;
            task.deadlineDate= DateFunctions.addDays(Convert.ToInt32(td.deadlinedays));
            task.dueDate = DateFunctions.addDays(Convert.ToInt32(td.duedays));
            task.status = ApplicationCodes.TASK_STATUS_NEW;
            task.subjectID = subjectid;
            task.dueTime = DateFunctions.getCurrentTimeInMillis();
            task.deadlineTime = DateFunctions.getCurrentTimeInMillis();
            task.transDate = DateFunctions.getCurrentDateAsString();
            task.transTime = DateFunctions.getCurrentTimeInMillis();
            task.transID = getTransID();
            task.taskDefinitionID = td.xTaskDefinitionID;
            task.teamID = td.route;
            task.name = td.Name;
            //task.parentRef = getHeader().ars.orderNo;
            //task.vendorID = getHeader().ars.vendorID;
            task.priority = priority;
            task.taskID = TaskDAO.getInstance(dbContext).create(task);



            audit(td.initiateAuditEvent, LookupTransConstant.TASK_INITIATE_MESSAGE +td.initiateAuditEvent);
            return task;

        }
        //protected Task diaryComplete(Int32 subjectid, string taskName)
        //{
        //    Task task = TaskDAO.getInstance(dbContext).readyBYSubjectIDAndParentRef(subjectid, getHeader().ars.orderNo, taskName);
        //    return diaryComplete(task.taskID);

        //}
        protected Task diaryComplete(Task task)
        {
            task.status = ApplicationCodes.TAKS_STATUS_COMPLETE;
            TaskDAO.getInstance(dbContext).completeTask(task);

            TaskDefinition taskdefinition = TaskDefinitionDAO.getDefInstance(dbContext).findbyPrimaryKey(task.taskDefinitionID);
            audit(taskdefinition.completeAuditEvent, LookupTransConstant.TASK_COMPLETE_MESSAGE + taskdefinition.initiateAuditEvent);
            return task;
        }
        protected Task diaryComplete(Int32 taskID)
        {
            return diaryComplete(TaskDAO.getInstance(dbContext).findbyPrimaryKey(taskID));
           
        }
        protected Task diaryInProgress(Int32 taskID)
        {
            Task task = TaskDAO.getInstance(dbContext).findbyPrimaryKey(taskID);
           if(task.status == ApplicationCodes.TASK_STATUS_NEW)
                TaskDAO.getInstance(dbContext).inProgressTask(task);

            TaskDefinition taskdefinition = TaskDefinitionDAO.getDefInstance(dbContext).findbyPrimaryKey(task.taskDefinitionID);
            audit(taskdefinition.completeAuditEvent, LookupTransConstant.TASK_INITIATE_MESSAGE + taskdefinition.initiateAuditEvent);            

            return task;

        }

        protected Audit audit(string eventCode, string text)
        {
            Audit audit = new Audit();
            audit.eventCode = Convert.ToInt32(eventCode);
            audit.description = text;
            audit.userID = getHeader().userID;

          
            //    audit.parentRef = getHeader().ars.orderNo ;
            //audit.userName = getHeader().userinformation.userAccount.userName;
            audit.transDate = DateFunctions.getCurrentDateAsString();
            audit.transTime = DateFunctions.getCurrentTimeInMillis();
            audit.auditID = AuditDAO.getInstance(dbContext).create(audit);

            return audit;

        }

       



    }
}