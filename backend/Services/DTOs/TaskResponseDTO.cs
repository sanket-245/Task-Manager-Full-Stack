namespace Services.DTOs
{
    public class TaskResponseDTO
    {
        public Guid TaskID { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public Guid StatusId {  get; set; }
    }
}
