using WorksTheDaily.API.Enums;

namespace WorksTheDaily.API.View
{
    public class TaskPO
    {
        public string TaskName { get; set; }
        public EFamily type { get; set; }
        public EStatus? status { get; set; }
        public string? Description { get; set; }
        public int? NivelPrioridade { get; set; } = 7;
    }
}
