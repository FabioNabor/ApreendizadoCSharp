using System.ComponentModel.DataAnnotations;

namespace WorksThedaily.WEB.Models
{
    public class CommentsModel
    {

        [Key]
        public int? Id { get; set; }
        public int father { get; set; }
        public string comment { get; set; }
        public DateTime? DateCreate { get; set; } = DateTime.Now;

        public CommentsModel(int? id, int father, string comment)
        {
            Id = id;
            this.father = father;
            this.comment = comment;
        }
    }
}
