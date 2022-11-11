using airproject.domain.Application.Ports.Inbound;
using Microsoft.Extensions.DependencyInjection;

namespace airproject.domain.Application.Services
{
    public interface IServiceManager<in TCommand, out TResult>
        where TCommand : class
        where TResult : class
    {
        public IEnumerable<TResult> Query(TCommand command);
        public object? Replay(int index);
    }
    public class ServiceManager<T, TResult> : IServiceManager<T, TResult>
        where T : class
        where TResult : class
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IRequestStore _requestStore;
        public ServiceManager(IServiceProvider serviceProvider, IRequestStore requestStore)
        {
            _serviceProvider = serviceProvider;
            _requestStore = requestStore;
        }

        public IEnumerable<TResult> Query(T command)
        {
            if (command != null)
            {
                var commandHandler = _serviceProvider.GetRequiredService<ICommandHandler<T, TResult>>();

                _requestStore.Save(Tuple.Create(typeof(T), typeof(ICommandHandler<T, TResult>), (object)command));

                return commandHandler.Query(command);
            }

            return Enumerable.Empty<TResult>();
        }

        public object? Replay(int index = 0)
        {
            var request = _requestStore.GetCommand(index);
            if (request != null)
            {
                using var scope = _serviceProvider.CreateScope();
                var commandHandler = scope.ServiceProvider.GetService(request.Item2);
                return commandHandler?.GetType().GetMethod("Query")?.Invoke(commandHandler, new object[] { request.Item3 });
            }
            return null;
        }
    }
}