using Domains.itinsync.interfaces.domain;
using System;

namespace Domains.itinsync.icom.task.taskdedinition
{
    public class xTaskDefinition : System.Attribute, IDomain
    {
        public enum columns
        { name, openService, completeService, parameters, dueDays, deadLineDays, body, route }
        public enum primaryKey { xTaskDefinitionID }
        public Int32 xTaskDefinitionID { get; set; }
        public String name { get; set; }
        public String openService { get; set; }
        public String completeService { get; set; }
        public String parameters { get; set; }
        public String dueDays { get; set; }
        public String deadLineDays { get; set; }
        public String body { get; set; }
        public String route { get; set; }
        public object getKey() { return xTaskDefinitionID; }

        public void setTransID(object transID)
        {
        }
    }
}