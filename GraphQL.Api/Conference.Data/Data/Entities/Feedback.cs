namespace GraphQL.Api.Data.Entities
{
    public class Feedback
    {
        public int Id { get; set; }
        //max 5 for delivery and conntent
        public int Delivery { get; set; }
        public int Content { get; set; }
        public string Comments { get; set; }
        public int TalkId { get; set; }
    }
}
