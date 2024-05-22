using System.ComponentModel.DataAnnotations;
using WorksTheDaily.API.Enums;

namespace WorksTheDaily.API.Model
{
    public class TaskModel
    {
        [Key]
        public int? id {  get; set; }
        public string TaskName { get; set; }
        public EFamily type { get; set; }
        public EStatus? status { get; set; } = EStatus.Novo;
        public string? Description { get; set; }
        public int? NivelPrioridade { get; set; } = 7;
        public DateTime? DataCriacao {  get; set; } = DateTime.Now;

        public TaskModel() { }

        public TaskModel(int? id, string taskName, EFamily type, string? description, int? nivelPrioridade)
        {
            this.id = id;
            TaskName = taskName;
            this.type = type;
            Description = description;
            NivelPrioridade = nivelPrioridade;
        }
    }
}
