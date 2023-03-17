using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcern.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key); //key verilir value alınır

        object Get(string key); //üstteki bu şekilde de yazılabiliyor
        //Cache : key, value, duration cache'te ne kadar duracak
        void Add(string key, object value, int duration);
        bool IsAdd(string key); //cache'de var mı?
        void Remove(string key); //cache'den uçur
        void RemoveByPattern(string pattern); //cache'den uçur ama başı sonu önemli değil içinde get olan, içinde kategori olan gibi... 
    }
}
