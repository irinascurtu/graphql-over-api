using Conference.Service;
using GraphQL.Api.Data.Repositories;
using GraphQL.DataLoader;
using GraphQL.Types;

namespace GraphQL.Api.GraphQL.Types
{
    public class Talk : ObjectGraphType<Data.Entities.Talk>
    {
        public Talk(FeedbackService feedbackService, IDataLoaderContextAccessor dataLoaderAccessor, SpeakersRepository speakersRepository)
        {
            Field(t => t.Id);
            Field(t => t.Title);
            Field(t => t.Description);
            Field(t => t.SpeakerId);
            //Field(name: "speaker", type: typeof(Speaker), resolve: context => context.Source.Speaker);


            ///loads the feedbacks for a talk in one go
            Field<ListGraphType<FeedbackType>>(
            "feedbacks",
            resolve: context =>
            {
                //his is an example of using a DataLoader to batch requests for loading a collection of items by a key.
                //This is used when a key may be associated with more than one item. LoadAsync() is called by the field resolver for each User.

                var loader =
                    dataLoaderAccessor.Context.GetOrAddCollectionBatchLoader<int, Conference.Service.Feedback>(
                        "GetReviewsByTalkId", feedbackService.GetAllInOneGo);

                return loader.LoadAsync(context.Source.Id);
            });


            Field<ListGraphType<Speaker>>(
             "speakers",
             resolve: context =>
            {
                var loader =
                    dataLoaderAccessor.Context.GetOrAddCollectionBatchLoader<int, Data.Entities.Speaker>("GetSpeakersForTalk", speakersRepository.GetAllSpeakersInOneGo);

                return loader.LoadAsync(context.Source.Id);
            });



        }
    }
}

