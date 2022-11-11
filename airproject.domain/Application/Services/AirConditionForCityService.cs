using airproject.domain.Application.Ports.Inbound;
using airproject.domain.Application.Ports.Outbound;
using airproject.domain.Domain;

namespace airproject.domain.Application.Services
{
    public class AirConditionForCityService : ICommandHandler<QueryAirConditionForCityCommand, Location>
    {
        private readonly IAirConditionRepository _airConditionRepository;

        public AirConditionForCityService(IAirConditionRepository airConditionRepository)
        {
            _airConditionRepository = airConditionRepository;
        }
        public IEnumerable<Location> Query(QueryAirConditionForCityCommand command)
        {
            return _airConditionRepository.GetLocations(
                        command.City,
                        command.Sort,
                        command.Page,
                        command.PageSize);
        }
    }
}