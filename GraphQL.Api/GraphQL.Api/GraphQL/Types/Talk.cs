using GraphQL.Types;

namespace GraphQL.Api.GraphQL.Types
{
    public class Talk : ObjectGraphType<Data.Entities.Talk>
    {
        public Talk()
        {
            Field(t => t.Id);
            Field(t => t.Title);
            Field(t => t.Description);
            ///TODO : add a few speaker details
        }
    }
}
