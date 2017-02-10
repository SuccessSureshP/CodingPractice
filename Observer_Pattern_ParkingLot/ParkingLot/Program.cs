using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Observer Pattern http://www.dofactory.com/net/observer-design-pattern (below is other simple way explained by Santosh)
namespace ParkingLot
{
    class Program
    {       
        //Observer pattern 
        static void Main(string[] args)
        {
            ParkingLevel p1 = new ParkingLevel(1);
            ParkingLevel p2 = new ParkingLevel(2);
            ParkingLevel p3 = new ParkingLevel(3);
            DisplayBoard d1 = new DisplayBoard(10, new List<ParkingLevel>
            {
                p1, p2,
            });
            DisplayBoard d2 = new DisplayBoard(30, new List<ParkingLevel>
            {
                p2, p3,
            });

            List<Task> taskList = new List<Task>();
            taskList.Add(Task.Run(() => {
                for (int i =1000; i< 1010; i++)
                {
                    p1.FreeSpots = i;
                }
            }));
            taskList.Add(Task.Run(() => {
                for (int i = 2000; i < 2010; i++)
                {
                    p2.FreeSpots = i;
                }
            }));
            taskList.Add(Task.Run(() => {
                for (int i = 3000; i < 3010; i++)
                {
                    p3.FreeSpots = i;
                }
            }));
            //taskList.Add(Task.Run(() => { p3.FreeSpots = 35; }));

            taskList.ForEach(t => t.Wait());
            
            Console.ReadKey();
        }
    }
}
