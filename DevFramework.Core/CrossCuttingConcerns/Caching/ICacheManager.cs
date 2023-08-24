using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);//keye göre cache getirme
        void Add(string key, object data, int cacheTime); //cache ekleme
        bool IsAdd(string key); //cache var mı ?
        void Remove(string key);    //cache silme
        void RemoveByPattern(string pattern); //bir patterne göre silmne
        void Clear();   //cache i tamamen silme
    }
}
