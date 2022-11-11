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
            var instance = this as T;
            if (instance != null)
            {
                _validator?.ValidateAndThrow(instance);
            }
        }
    }
}