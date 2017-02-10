using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class DisplayBoard
    {
        int id;
        List<ParkingLevel> parkingLevels;
        public ConcurrentDictionary<int, int> allBoardData = new ConcurrentDictionary<int, int>();
        public DisplayBoard(int id, List<ParkingLevel> parkingLevelsData)
        {
            this.id = id;
            this.parkingLevels = parkingLevelsData;
            foreach(ParkingLevel parkingLevel in parkingLevelsData)
            {
                parkingLevel.notify += Update;
            }
        }

        private void Update(int parkingLevelId, int freeSpaceCount)
        {
  //          allBoardData.AddOrUpdate(parkingLevelId, freeSpaceCount,
  //(key, oldValue) => parkingLevelId);

            Console.WriteLine("B: {0}, PId: {1}, FS:  {2}", this.id, parkingLevelId, freeSpaceCount);
            Thread.Sleep(100*id);
        }
    }
}
