using BookingCar.Core.Domain.ViewModels;
using System.Collections.Generic;

namespace BookingCar.Core.Domain.Drivers
{
    public class DictionaryOfDrivers
    {
        private DriverViewModel? _data;
        private Dictionary<char, DictionaryOfDrivers> children = new Dictionary<char, DictionaryOfDrivers>();

        public void Add(string path, DriverViewModel data)
        {
            if (path == null) return;
            Add(path, 0, data);
        }

        private void Add(string path, int index, DriverViewModel data)
        {
            if (index == path.Length)
            {
                _data = data;
                return;
            }

            var c = path[index];
            if (!children.ContainsKey(c)) children.Add(c, new DictionaryOfDrivers());
            children[c].Add(path, index + 1, data);
        }

        public void GetByPrefix(string prefix, HashSet<DriverViewModel> result)
        {
            GetByPrefix(prefix, 0, result);
        }

        private void GetByPrefix(string prefix, int index, HashSet<DriverViewModel> result)
        {
            if (_data.HasValue)
                result.Add(_data.Value);

            if (index >= prefix.Length)
            {
                foreach (var node in children.Values)
                    node.GetByPrefix(prefix, index, result);
            }
            else
            {
                var c = prefix[index];
                if (children.ContainsKey(c))
                    children[c].GetByPrefix(prefix, index + 1, result);
            }
        }
    }
}
