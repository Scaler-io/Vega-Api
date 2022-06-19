using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Serilog;
using Vega_API.DataAccess.Interfaces;
using Vega_API.Entities;
using Vega_API.Extension;
using Vega_API.Model.Constants;
using Vega_API.Model.Core;
using Vega_API.Model.Response;

namespace Vega_API.Services.Features
{
    public class FeatureService : IFeatureService
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseRepository<VegaFeature> _featureRepository;

        public FeatureService(IUnitOfWork unitOfWork, 
            ILogger logger, 
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _featureRepository = _unitOfWork.Repository<VegaFeature>();
        }

        public async Task<Result<IReadOnlyList<VegaFeatureResponse>>> GetFeatures()
        {
            _logger.Here().MethodEnterd();

            var features = await _featureRepository.ListAllAsync();

            if(features == null || features.Count == 0){
                _logger.Here().Information("No features found {@errooCode}", ErrorCodes.NotFound);
                return null;
            }

            var result = _mapper.Map<IReadOnlyList<VegaFeatureResponse>>(features);

            _logger.Here().Information("Features fetched. {@features}", features);
            _logger.Here().MethodExited();

            return Result<IReadOnlyList<VegaFeatureResponse>>.Success(result);
        }
    }
}