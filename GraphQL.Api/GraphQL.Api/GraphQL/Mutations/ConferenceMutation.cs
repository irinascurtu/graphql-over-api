using Conference.Data.Data.Repositories;
using GraphQL.Api.GraphQL.Types;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Api.GraphQL.Mutations
{
    public class ConferenceMutation : ObjectGraphType
    {
        public ConferenceMutation(TalksRepository talkRepository)
        {
            FieldAsync<Talk>(
              "createTalk",
              arguments: new QueryArguments(
                  new QueryArgument<NonNullGraphType<TalkInput>>
                  {
                      Name = "talkInput"
                  }
              ),
              resolve: async context =>
              {
                  var talk = context.GetArgument<Data.Entities.Talk>("talkInput");

                  return await context.TryAsyncResolve(async c => await talkRepository.Add(talk));
              });       
        }

    }
}
