using GraphQL.Api.Data.Repositories;
using GraphQL.DataLoader;
using GraphQL.Types;

namespace GraphQL.Api.GraphQL.Types
{
    public class TalkType : ObjectGraphType<Data.Entities.Talk>
    {
        public TalkType(SpeakersRepository speakersRepository, IDataLoaderContextAccessor dataLoaderAccessor)
        {
            Field(t => t.Id);
            Field(t => t.Title);
            Field(t => t.Description);
            Field(t => t.SpeakerId);
          //  Field<Speaker>().Name("speaker").Resolve(context => context.Source.Speaker);

            Field(
           name: "speaker",
           type: typeof(Speaker),
           resolve: context => context.Source.Speaker );
        }
    }
}
