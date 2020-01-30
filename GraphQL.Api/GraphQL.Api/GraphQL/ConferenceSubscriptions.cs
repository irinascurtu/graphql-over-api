using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Conference.Service;
using GraphQL.Resolvers;
using GraphQL.Types;

namespace GraphQL.Api.GraphQL
{
    public class ConferenceSubscriptions : ObjectGraphType
    {
        public ConferenceSubscriptions(FeedbackService feedbackService)
        {
            Name = "Subscription";
           
        }
    }
}
