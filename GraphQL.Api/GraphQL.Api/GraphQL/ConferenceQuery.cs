using Conference.Data.Data.Repositories;
using Conference.Service;
using GraphQL.Api.Data.Repositories;
using GraphQL.Api.GraphQL.Types;
using GraphQL.Types;

namespace GraphQL.Api.GraphQL
{
    /// <summary>
    /// This class wil be the source of data trough EF
    /// </summary>
    public class ConferenceQuery : ObjectGraphType
    {
        public ConferenceQuery(SpeakersRepository speakersRepo, TalksRepository talksRepo, FeedbackService feedbackService)
        {
            Field<ListGraphType<Types.Speaker>>(
                "speakers",
                Description = "will return all the speakers from current and past editions",
                resolve: context => speakersRepo.GetAll()
            );


            Field<ListGraphType<Talk>>(
                "talks",
                Description = "will return all the talks from current and past editions",
                resolve: context => talksRepo.GetAll()
            );


            Field<ListGraphType<FeedbackType>>(
                "feedbacks",
                Description = "will return all the feedbacks",
                resolve: context => feedbackService.GetAll()
          );


            Field<ListGraphType<Types.Talk>>(
                "speakertalks",
                Description = "will return all the talks for a speaker",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>>
                {
                    Name = "id"
                }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return talksRepo.GetAllForSpeaker(id);
                }
            );


            //gets a speaker by id

            Field<Speaker>(
                "speaker",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>>
                {
                    Name = "id",
                    DefaultValue = 2,
                    Description = "test"
                }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return speakersRepo.GetById(id);
                }
            );

            //gets a talk by id
            Field<Talk>(
                "talk",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>>
                {
                    Name = "id"
                }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return talksRepo.GetById(id);
                }
            );


        }
    }
}
