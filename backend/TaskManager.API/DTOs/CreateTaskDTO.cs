namespace TaskManager.API.DTOs
{
    public class CreateTaskDTO
    {
        public string TaskDescripion {  get; set; }

        public string TaskName { get; set; }

        public Guid UserID { get; set; }

        public DateTime TaskDuedate {  get; set; }
    }
}
