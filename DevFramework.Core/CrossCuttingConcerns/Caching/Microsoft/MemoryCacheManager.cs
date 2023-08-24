using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DevFramework.Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {

        //protected ObjectCache Cache
        //{
        //    get
        //    {
        //        return MemoryCache.Default;
        //    }
        //}
        protected ObjectCache Cache => MemoryCache.Default;





        public void Add(string key, object data, int cacheTime)
        {
            if(data == null)
            {
                return;
            }

            var policy = new CacheItemPolicy 
            { 
                AbsoluteExpiration = DateTime.UtcNow +TimeSpan.FromMinutes(cacheTime) //cachede ne kadar duracak günümüz + metoda gönderdiğin cachetimedaki saat kadar
            };
            Cache.Add(new CacheItem(key, data), policy);

        }

        public void Clear()
        {
            foreach (var item in Cache)
            {
                Remove(item.Key);
            }
        }

        public T Get<T>(string key)
        {
            return (T)Cache[key];
        }

        public bool IsAdd(string key)
        {
            return Cache.Contains(key);//cache içinde data var mı
           
        }

        public void Remove(string key)
        {
            Cache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            var regex = new Regex(pattern,RegexOptions.Singleline|RegexOptions.Compiled|RegexOptions.IgnoreCase); //pattern, tek satır gönderiyoruz, compile edilmiş,case sens. çalışma
            var keysToRemove= Cache.Where(d=>regex.IsMatch(d.Key)).Select(d=>d.Key).ToList();
            foreach (var key in keysToRemove)
            {
                Remove(key);
            }
        }
    }
}
