using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Caching;

namespace ClassLibrary.Common
{
 
    public class DataCache
    {
        /// <summary>
        /// 获取当前应用程序指定CacheKey的Cache值
        /// </summary>
        /// <param name="cacheKey">缓存关键字</param>
        /// <returns></returns>
        public static object GetCache(string cacheKey)
        {
            Cache objCache = HttpRuntime.Cache;
            return objCache[cacheKey];
        }

        /// <summary>
        /// 设置指定CacheKey的值
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <param name="value"></param>
        public static void SetCacheValue(string cacheKey, object value)
        {
            Cache objCache = HttpRuntime.Cache;
            objCache[cacheKey] = value;
        }
        
        /// <summary>
        /// 设置当前应用程序指定CacheKey的Cache值(绝对过期)
        /// </summary>
        /// <param name="cacheKey">缓存关键字</param>
        /// <param name="objValue">缓存对象</param>
        /// <param name="minutes">过期时间(分)</param>
        public static void SetCacheAbsolute(string cacheKey, object objValue, int minutes)
        {
            Cache objCache = HttpRuntime.Cache;
            if (GetCache(cacheKey) != null)
            {
                return;
            }
            objCache.Insert(cacheKey, objValue, null, DateTime.Now.AddMinutes(minutes), TimeSpan.Zero);
        }

        /// <summary>
        /// 设置当前应用程序指定CacheKey的Cache值(相对过期)
        /// </summary>
        /// <param name="cacheKey">缓存关键字</param>
        /// <param name="objValue">缓存对象</param>
        /// <param name="minutes">过期时间(分)</param>
        public static void SetCache(string cacheKey, object objValue, int minutes)
        {
            if (GetCache(cacheKey) != null)
            {
                return;
            }
            Cache objCache = HttpRuntime.Cache;
            objCache.Insert(cacheKey, objValue, null, Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(minutes + 0.0));
        }
    }
}
