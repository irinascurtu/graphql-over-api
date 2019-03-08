using GraphQL.Types;

namespace GraphQL.Api.GraphQL
{
    public class ConferenceSchema : Schema
    {
        public ConferenceSchema(IDependencyResolver resolver): base(resolver)
        {
            Query = resolver.Resolve<ConferenceQuery>();
        }
    }
}
