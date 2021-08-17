using System.Collections.Generic;

namespace SignalSources.Interfaces
{
    public interface IDataAccess<T>
    {
        IEnumerable<T> GetSourceConfigurations();
        void Save(IEnumerable<T> sourceConfigurations);
    }
}
