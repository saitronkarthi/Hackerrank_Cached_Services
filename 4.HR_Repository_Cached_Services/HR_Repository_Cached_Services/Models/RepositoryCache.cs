using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Caching;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using System.Web.Caching;

namespace HR_Repository_Cached_Services.Models
{
    public class RepositoryCache
    {
        public ObjectCache Cache
        {
            get { return MemoryCache.Default; }
        }
        public bool IsCached(string Key)
        {
            return Cache.Contains(Key);
        }
        //Inserts the object to Cache with the fixed string Key, with a sliding expiration
        public void Add(string Key, string Value, int Expiration)
        {
            lock (Cache)
            {
                HttpContext.Current.Cache.Insert(Key, Value, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(Expiration), System.Web.Caching.CacheItemPriority.Default, null);
                
                
            }
        }
       
        public string ReturnCache(string Key)
        {
            return Cache[Key] as string;
        }
        public void Remove(string Key)
        {
            Cache.Remove(Key);
        }
       private async Task<string> webapi()
        {
            string uri = "http://localhost:6847/api/job"; //API URL 
            var client = new HttpClient();
           
            Task<string> result = client.GetStringAsync(uri);
            return await result;
           
        }
        public async Task<string> getjobdata()
        {
            
            string uri = "http://localhost:6847/api/job";
            var client = new HttpClient();
            string ApiResponse;
            
            client.BaseAddress = new Uri(uri);
           
            try
            {
               
                var response = client.GetAsync(uri).Result;
                if(response.IsSuccessStatusCode)
                {
                    var content = response.Content;
                    ApiResponse = content.ReadAsStringAsync().Result;
                    return ApiResponse;
                }
                return null;
            }
            catch(Exception e)
            {
                return null;
            }
        }

    }
}