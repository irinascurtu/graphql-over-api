using Conference.Data.Data.Repositories;
using Conference.Service;
using GraphQL.Api.Data.Repositories;
using GraphQL.Api.GraphQL.Types;
using GraphQL.DataLoader;
using GraphQL.Types;
using System.Collections.Generic;

namespace GraphQL.Api.GraphQL
{
    /// <summary>
    /// This class wil be the source of data trough EF
    /// </summary>
    public class ConferenceQuery : ObjectGraphType
    {
        public ConferenceQuery(SpeakersRepository speakersRepo, TalksRepository talksRepo, FeedbackService feedbackService, IDataLoaderContextAccessor accessor)
        {
            Field<ListGraphType<Types.Speaker>>(
                "speakers",
                Description = "will return all the speakers from current and past editions",
                resolve: context => speakersRepo.GetAll()
            );


            //Field<ListGraphType<Talk>>(
            //    "talks",
            //    Description = "will return all the talks from current and past editions",
            //    resolve: context => talksRepo.GetAll()
            //);



            Field<ListGraphType<Talk>, IEnumerable<Data.Entities.Talk>>()
           .Name("talks")
           .Description("Get all talks in the system")
           .ResolveAsync(ctx =>
           {
               // Get or add a loader with the key "GetAllUsers"
               var loader = accessor.Context.GetOrAddLoader("talksdssd",
                  () => talksRepo.GetAllAsync());

               // Prepare the load operation
               // If the result is cached, a completed Task<IEnumerable<User>> will be returned
               return loader.LoadAsync();
           });



            //  Field<ListGraphType<FeedbackType>>(
            //      "feedbacks",
            //      Description = "will return all the feedbacks",
            //      resolve: context => feedbackService.GetAll()
            //);


            //caches subsequent calls using IDataLoaderContextAccessor
            Field<ListGraphType<FeedbackType>, IEnumerable<Feedback>>()
           .Name("feedbacks")
           .Description("Get all feedbacks")
           .ResolveAsync(ctx =>
           {
                // Get or add a loader with the key "GetAllUsers"
                var loader = accessor.Context.GetOrAddLoader("GetAllFeedbacks",
                   () => feedbackService.GetAll());

                // Prepare the load operation
                // If the result is cached, a completed Task<IEnumerable<User>> will be returned
                return loader.LoadAsync();
           });


            Field<ListGraphType<Types.Talk>>(
                "talksForASpeaker",
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
                "speakerById",
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
