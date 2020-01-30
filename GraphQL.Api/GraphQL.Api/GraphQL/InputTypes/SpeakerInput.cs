using GraphQL.Api.Data.Entities;
using GraphQL.Types;

namespace GraphQL.Api.GraphQL.Types
{
    public class SpeakerInput : InputObjectGraphType
    {

        public SpeakerInput()
        {
            Name = "speakerInput"; //will be the name displayed in mutation
            Field<StringGraphType>("FirstName");
            Field<StringGraphType>("LastName");
            Field<StringGraphType>("Position");
            Field<StringGraphType>("Description");
            Field<StringGraphType>("CompanyName");
            Field<StringGraphType>("Email");
            Field<StringGraphType>("GitHub");
            Field<StringGraphType>("LinkedIn");

        }
    }
}
