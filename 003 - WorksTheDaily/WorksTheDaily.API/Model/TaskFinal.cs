using WorksTheDaily.API.Enums;

namespace WorksTheDaily.API.Model
{
    public class TaskFinal
    {
        public int id { get; set; }
        public string TaskName { get; set; }
        public EFamily type { get; set; }
        public EStatus? status { get; set; }
        public string Description { get; set; }
        public int? NivelPrioridade { get; set; }
        public DateTime? DataCriacao { get; set; }
        public IEnumerable<CommentsModel> Comments { get; set; }

        public TaskFinal()
        {

        }

        public TaskFinal(int id, string taskName, EFamily type, EStatus? status, string description, int? nivelPrioridade, DateTime? dataCriacao, List<CommentsModel> comments)
        {
            this.id = id;
            TaskName = taskName;
            this.type = type;
            this.status = status;
            Description = description;
            NivelPrioridade = nivelPrioridade;
            DataCriacao = dataCriacao;
            Comments = comments;
        }
    }
}
