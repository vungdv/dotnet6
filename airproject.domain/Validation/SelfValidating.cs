using FluentValidation;

namespace airproject.domain.Validation
{
    public class SelfValidating<T>
        where T : class
    {
        private readonly IValidator<T> _validator;
        protected SelfValidating(IValidator<T> validator)
        {
            _validator = validator;
        }

        protected void ValidateSelf()
        {
            if (this is T instance)
            {
                _validator?.ValidateAndThrow(instance);
            }
        }
    }
}