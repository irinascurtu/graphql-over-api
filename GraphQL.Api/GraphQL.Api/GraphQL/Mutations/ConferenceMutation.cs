using Conference.Data.Data.Repositories;
using GraphQL.Api.GraphQL.Types;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Api.Data.Repositories;

namespace GraphQL.Api.GraphQL.Mutations
{
    public class ConferenceMutation : ObjectGraphType
    {
        public ConferenceMutation(TalksRepository talkRepository, SpeakersRepository speakersRepository)
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
                  //you can also validate
                  return await context.TryAsyncResolve(async c => await talkRepository.Add(talk));
              });



            FieldAsync<Speaker>(
                "createSpeaker",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<SpeakerInput>>
                    {
                        Name = "speakerInput"
                    }
                ),
                resolve: async context =>
                {
                    var speaker = context.GetArgument<Data.Entities.Speaker>("speakerInput");
                    //you can also validate

                    return await context.TryAsyncResolve(async c => await speakersRepository.Add(speaker));
                });


        }

    }
}
