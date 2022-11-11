namespace airproject.domain.Application.Ports.Inbound
{
    public interface ICommandHandler<in TCommand, out TResult>
    {
        public IEnumerable<TResult> Query(TCommand command);
    }
}
