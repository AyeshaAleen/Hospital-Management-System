using Domains.itinsync.interfaces.domain;
using System;

namespace Domains.itinsync.icom.task.taskdedinition
{
    public class TaskDefinition : System.Attribute, IDomain
    {
        public enum columns
        { Name, openService, completeService, parameters, duedays, deadlinedays, body, route, initiateAuditEvent, inprogressAuditEvent, completeAuditEvent }
        public enum primaryKey { xTaskDefinitionID }
        public Int32 xTaskDefinitionID { get; set; }
        public String Name { get; set; }
        public String openService { get; set; }
        public String completeService { get; set; }
        public String parameters { get; set; }
        public String duedays { get; set; }
        public String deadlinedays { get; set; }
        public String body { get; set; }
        public Int32 route { get; set; }

        public string initiateAuditEvent { get; set; }
        public string inprogressAuditEvent { get; set; }
        public string completeAuditEvent { get; set; }


        public object getKey() { return xTaskDefinitionID; }

        public void setTransID(object transID)
        {

        }
    }
}