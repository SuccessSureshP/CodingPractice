using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class ParkingLevel
    {
        int id;
        int freeSpotsCount = 100;
        public ParkingLevel(int id)
        {
            this.id = id;
        }

        public int FreeSpots
        {
            set
            {
                this.freeSpotsCount = value;
                notify.Invoke(this.id, this.freeSpotsCount);
            }
        }

        public delegate void NotifyAction(int id, int data);
        public event NotifyAction notify;
        
    }
}
