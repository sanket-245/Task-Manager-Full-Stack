namespace Services.DTOs
{
    public class TaskResponseDTO
    {
        public Guid TaskID { get; set; }
        public String TaskName { get; set; }
        public String TaskDescription { get; set; }
        public Guid StatusId {  get; set; }
    }
}
