namespace Services.DTOs
{
    public class CreateTaskDTO
    {
        public String TaskDescripion {  get; set; }

        public String TaskName { get; set; }

        public Guid UserID { get; set; }

        public DateTime TaskDuedate {  get; set; }
    }
}
