using System;

namespace RoomStatusFunction.Processors
{
    public class RoomStatusProcessor
    {
        public static OccupancyStatus GetStatus(string spaceid)
        {
            try
            {
                var conferenceRoomStatus = ConfRoomStatusProcessor.GetStatus(spaceid);
                var motionStatus = MotionStatusProcessor.GetStatus(spaceid);
                return ProcessStatus(conferenceRoomStatus, motionStatus);
            }
            catch (Exception)
            {

                return OccupancyStatus.UNKNOWN;
            }
        }

        private static OccupancyStatus ProcessStatus(ConfRoomStatus confRoomStatus, bool motionStatus)
        {
            if(motionStatus)
            {
                return OccupancyStatus.OCCUPIED;
            }
            else if(confRoomStatus == ConfRoomStatus.FREE && !motionStatus)
            {
                return OccupancyStatus.AVAILABLE;
            }
            else if(confRoomStatus == ConfRoomStatus.BUSY && !motionStatus)
            {
                return OccupancyStatus.RESERVED_UNOCCUPIED;
            }
            else
            {
                return OccupancyStatus.UNKNOWN;
            }
        }
    }
}