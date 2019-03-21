﻿using Conference.Service;
using GraphQL.Api.Data.Repositories;
using GraphQL.DataLoader;
using GraphQL.Types;

namespace GraphQL.Api.GraphQL.Types
{
    public class Talk : ObjectGraphType<Data.Entities.Talk>
    {
        public Talk(FeedbackService feedbackService, IDataLoaderContextAccessor dataLoaderAccessor)
        {
            Field(t => t.Id);
            Field(t => t.Title);
            Field(t => t.Description);
            Field(t => t.SpeakerId);
            Field(name: "speaker", type: typeof(Speaker), resolve: context => context.Source.Speaker);
            //Field<ListGraphType<Feedback>>("feedbacks",
            //  arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
            //  resolve: context => feedbackService.GetByTalkType(context.Source.Id),
            //  description: "all the feedbacks for the current talks");

            // multiiple

         Field<ListGraphType<FeedbackType>>(
         "feedbacks",
         resolve: context =>
         {

             var loader =
                 dataLoaderAccessor.Context.GetOrAddCollectionBatchLoader<int, Conference.Service.Feedback>(
                     "GetReviewsByTalkId", feedbackService.GetAllInOneGo);

             return loader.LoadAsync(context.Source.Id);
         });

        }
    }
}

