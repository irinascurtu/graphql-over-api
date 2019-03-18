using GraphQL.Api.GraphQL.Mutations;
using GraphQL.Types;

namespace GraphQL.Api.GraphQL
{
    public class ConferenceSchema : Schema
    {
        public ConferenceSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<ConferenceQuery>();
            Mutation = resolver.Resolve<ConferenceMutation>();
        }
    }
}
