namespace TaskManagementAPI.Models
{
    public class TaskData
    {
        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public bool IsFavorited { get; set; }
    }
}
