using Newtonsoft.Json;
using RoomStatusFunction.Cache;

namespace RoomStatusFunction.Processors
{
    public class MotionStatusProcessor 
    {
        public static bool GetStatus(string spaceid)
        {
            var cachedValue = JsonConvert.DeserializeObject<CacheResponse>(CacheManager.GetValue(spaceid + "_Motion"));
            return bool.Parse(cachedValue.ProcessedValue);
        }
    }
}