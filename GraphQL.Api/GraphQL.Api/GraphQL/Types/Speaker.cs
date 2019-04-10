using GraphQL.Api.Data.Entities;
using GraphQL.Types;

namespace GraphQL.Api.GraphQL.Types
{
    public class Speaker : ObjectGraphType<Data.Entities.Speaker>
    {
        public Speaker()
        {
            Field(t => t.Id);
            Field(t => t.FirstName);
            Field(t => t.LastName);
            Field(t => t.Position).Description("The position in the company");
            Field(t => t.Description).Description("Speaker Bio");
            Field(t => t.CompanyName);
            Field(t => t.LinkedIn);
            Field(t => t.Twitter).Description("Twitter username");
        }
    }
}
