using System.Collections.Concurrent;

namespace airproject.domain.Application.Services
{
    public interface IRequestStore
    {
        public IEnumerable<Tuple<Type, Type, object>> GetCommands(int count);
        public Tuple<Type, Type, object>? GetCommand(int index);
        public void Save(Tuple<Type, Type, object> request);
    }

    public class RequestStore : IRequestStore
    {
        ConcurrentStack<Tuple<Type, Type, object>> _store = new ConcurrentStack<Tuple<Type, Type, object>>();
        
        public Tuple<Type, Type, object>? GetCommand(int index)
        {
            return _store.Skip(index).FirstOrDefault();
        }

        public IEnumerable<Tuple<Type, Type, object>> GetCommands(int count)
        {
            return _store.Take(count);
        }

        public void Save(Tuple<Type, Type, object> request)
        {
            _store.Push(request);
        }
    }
}