using Newtonsoft.Json;
using RoomStatusFunction.Cache;

namespace RoomStatusFunction.Processors
{
    public class ConfRoomStatusProcessor
    {
        public static ConfRoomStatus GetStatus(string spaceid)
        {
            var cachedValue = JsonConvert.DeserializeObject<CacheResponse>(CacheManager.GetValue(spaceid + "_ConferenceStatus"));
            if(cachedValue.ProcessedValue.ToUpper() == ConfRoomStatus.FREE.ToString())
            {
                return ConfRoomStatus.FREE;
            }
            else if(cachedValue.ProcessedValue.ToUpper() == ConfRoomStatus.BUSY.ToString())
            {
                return ConfRoomStatus.BUSY;
            }
            else
            {
                return ConfRoomStatus.UNKNOWN;
            }
        }
    }
}