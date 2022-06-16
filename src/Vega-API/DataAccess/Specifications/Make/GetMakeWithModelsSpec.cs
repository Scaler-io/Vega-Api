using Vega_API.Entities;

namespace Vega_API.DataAccess.Specifications.Make
{
    public class GetMakeWithModelsSpec: BaseSpecification<VegaMake>
    {
        public GetMakeWithModelsSpec(): base()
        {
            AddIncludes("Models");
            AddOrderBy(m => m.CreatedAt);
        }
    }
}
