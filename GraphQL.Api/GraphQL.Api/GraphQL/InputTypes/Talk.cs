using Conference.Service;
using GraphQL.Api.Data.Repositories;
using GraphQL.DataLoader;
using GraphQL.Types;

namespace GraphQL.Api.GraphQL.Types
{
    public class TalkInput : InputObjectGraphType
    {
        public TalkInput()
        {
            Name = "talkInput"; //will be the name displayed in mutation
            Field<StringGraphType>("title");
            Field<StringGraphType>("description");           
            Field<IntGraphType>("speakerId");
        }

    }
}

