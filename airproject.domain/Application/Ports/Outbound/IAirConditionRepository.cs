using airproject.domain.Domain;

namespace airproject.domain.Application.Ports.Outbound
{
    public interface IAirConditionRepository
    {
        public IEnumerable<Location> GetLocations(string city, string sort, int page, int pageSize);
    }
}
