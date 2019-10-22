using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;

namespace CsharpLazycode.Module.MemoryCacheHelper.CacheHelper
{
    public static class Util
    {
        public static void Set(string key, object obj, int seconds = 7200)
        {
            var cache = MemoryCache.Default;

            var policy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTime.Now.AddSeconds(seconds)
            };

            cache.Set(key, obj, policy);
        }

        public static T Get<T>(string key) where T : class
        {
            var cache = MemoryCache.Default;

            try
            {
                return (T)cache[key];
            }
            catch (Exception)
            {
                return null;
            }
        } 

        public static void Remove(string key)
        {
            MemoryCache.Default.Remove(key);
        }

        public static void ClearAll()
        {
            var cache = MemoryCache.Default;
            var allKeys = cache.Select(o => o.Key);
            System.Threading.Tasks.Parallel.ForEach(allKeys, key => cache.Remove(key));
        }

        public static void ClearVersionOne()
        {
            var cache = MemoryCache.Default;

            List<string> cacheKeys = cache.Select(kvp => kvp.Key).ToList();
            foreach (string cacheKey in cacheKeys)
            {
                cache.Remove(cacheKey);
            }
        }



    }
}
