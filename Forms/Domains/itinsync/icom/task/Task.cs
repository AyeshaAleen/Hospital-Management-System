using Domains.itinsync.icom.task.taskdedinition;

namespace Entities.itinsync.task
{
    public class Task
    {
        public enum columns
        {
            taskid, body, tranid, trandate, trantime, duedate, deadlinedate,
            taskdefinitionid, subjectid, teamid, status, name, parentref
        }
        public int taskid { get; set; }
        public string body { get; set; }
        public int tranid { get; set; }
        public string trandate { get; set; }
        public string trantime { get; set; }
        public string duedate { get; set; }
        public string deadlinedate { get; set; }
        public int taskdefinitionid { get; set; }
        public string subjectid { get; set; }
        public int teamid { get; set; }
        public string status { get; set; }
        public string statusText { get; set; }
        public string alertState { get; set; }
        public string name { get; set; }
        public string parentref { get; set; }
        public TaskDefinition taskDefinition { get; set; }

    }
}
