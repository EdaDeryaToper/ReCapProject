using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Core.Utilities.IoC;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace Core.CrossCuttingConcern.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        private IMemoryCache _memoryCache;

        public MemoryCacheManager()
        {
            _memoryCache = ServiceTool.ServiceProvider.GetService<IMemoryCache>();
        }
        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }

        public void Add(string key, object value, int duration)
        {
            _memoryCache.Set(key, value, TimeSpan.FromMinutes(duration));
        }

        public bool IsAdd(string key)
        {
            //ikinci parametre istiyordu (out object value) diye.Değeri verme demek :out _ 
            return _memoryCache.TryGetValue(key, out _); 
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }
        //çalışma anında bellekten silmeye yarıyor->Reflection
        public void RemoveByPattern(string pattern)
        {
            //MemoryCache içerisindeki EntriesCollection ı bul
            var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(_memoryCache) as dynamic;
            List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();

            foreach (var cacheItem in cacheEntriesCollection)
            {
                ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
                cacheCollectionValues.Add(cacheItemValue);
            }

            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase); //pattern
            var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();
            //kurala uyanı bul ve sil
            foreach (var key in keysToRemove)
            {
                _memoryCache.Remove(key);
            }
        }

        public object Get(string key)
        {
            return _memoryCache.Get(key);
        }
    }
}
