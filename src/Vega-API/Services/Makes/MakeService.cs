using AutoMapper;
using Serilog;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vega_API.DataAccess.Interfaces;
using Vega_API.DataAccess.Specifications.Make;
using Vega_API.Entities;
using Vega_API.Extension;
using Vega_API.Model.Constants;
using Vega_API.Model.Core;
using Vega_API.Model.Response;

namespace Vega_API.Services.Makes
{
    public class MakeService : IMakeService
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseRepository<VegaMake> _makeRepository;

        public MakeService(ILogger logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _makeRepository = _unitOfWork.Repository<VegaMake>();
            _mapper = mapper;
        }

        public async Task<Result<IReadOnlyList<VegaMakeResponse>>> GetMakes()
        {
            _logger.Here().MethodEnterd();

            var spec = new GetMakeWithModelsSpec();
            var result = await _makeRepository.ListAsync(spec);

            if (result == null || result.Count == 0)
            {
                _logger.Here().Information("{@errorCode}: no make was found", ErrorCodes.NotFound);
                return null;
            }

            _logger.Here().Information("Makes found. {@makes}", result);
            _logger.Here().MethodExited();

            var response = _mapper.Map<IReadOnlyList<VegaMakeResponse>>(result);

            return Result<IReadOnlyList<VegaMakeResponse>>.Success(response);
        }
    }
}
