using System;
using Domains.itinsync.icom.task.taskdedinition;
using Domains.itinsync.interfaces.domain;
using Domains.itinsync.icom.annotation;

namespace domains.itinsync.task
{
    public class Task : IDomain
    {
        public enum columns
        { body, transID, transDate, transTime, dueDate, deadlineDate, taskDefinitionID,
          subjectID, teamID, status, name, parentRef, userID, vendorID, dueTime, deadlineTime, priority
        }
        public enum primaryKey { taskID }
        public Int32 taskID { get; set; }
        public String body { get; set; }
        public Int32 transID { get; set; }
        public String transDate { get; set; }
        [DateTimeAttribute(relatedTag = "transDate")]
        public String transTime { get; set; }
        public String dueDate { get; set; }
        [DateTimeAttribute(relatedTag = "dueDate")]
        public String dueTime { get; set; }
        public String deadlineDate { get; set; }
        [DateTimeAttribute(relatedTag = "deadlineDate")]
        public String deadlineTime { get; set; }
        public Int32 taskDefinitionID { get; set; }
        public Int32 subjectID { get; set; }
        public Int32 teamID { get; set; }

        [LookupAttribute(lookupName = "LKTaskStatus", relatedTag = "status_Text")]
        public String status { get; set; }
        public String status_Text { get; set; }
        public String alertState { get; set; }
        public String name { get; set; }
        public String parentRef { get; set; }
        public Int32 userID { get; set; }
        public Int32 vendorID { get; set; }

        public int priority { get; set; }
        public TaskDefinition taskDefinition { get; set; }
        public object getKey() { return taskID; }

        public void setTransID(object transID)
        {
            this.transID = (Int32)transID;
        }
    }
}