using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Api.GraphQL.Types
{
    public class Feedback : ObjectGraphType<Conference.Service.Feedback>
    {

        public Feedback()
        {
            Field(t => t.Id);
            Field(t => t.Content);
            Field(t => t.Delivery);
            Field(t => t.Comments);
            Field(t => t.TalkId);

        }
    }
}
