using airproject.domain.Validation;
using FluentValidation;

namespace airproject.domain.Application.Ports.Inbound
{
    public class QueryAirConditionForCityCommand : SelfValidating<QueryAirConditionForCityCommand>
    {
        public QueryAirConditionForCityCommand(IValidator<QueryAirConditionForCityCommand> validator,
            string city,
            string sort
            ) : base(validator)
        {
            City = city;
            Sort = sort;
            this.ValidateSelf();
        }
        public int PageSize { get; set; } = 100;
        public int Page { get; set; } = 1;
        public string City { get; set; } = string.Empty;

        public string Sort { get; set; } = "desc";

    }

    public class QueryAirConditionForCityCommandValidator : AbstractValidator<QueryAirConditionForCityCommand>
    {
        private readonly string[] _sorts = { "desc", "asc" };
        public QueryAirConditionForCityCommandValidator()
        {
            RuleFor(x => x.PageSize).LessThanOrEqualTo(100);
            RuleFor(x => x.City).NotEmpty();
            RuleFor(x => x.Sort).Must(v => _sorts.Contains(v));
        }
    }
}