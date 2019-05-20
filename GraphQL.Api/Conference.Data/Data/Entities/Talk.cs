using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQL.Api.Data.Entities
{
    public class Talk
    {
        public int Id { get; set; }
        public int SpeakerId { get; set; }

        public string Description { get; set; }
        public string Title { get; set; }

        [ForeignKey("SpeakerId")]
        [InverseProperty("Talks")]
        public virtual Speaker Speaker { get; set; }

    }
}
