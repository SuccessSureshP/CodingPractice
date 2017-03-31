using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_Coding_Problems
{
    public class AreEqual
    {
        static void Main1(string[] args)
        {
            Stack_With_Min.PerformStackWithMin();
            //COmputeAreEqual();
           // Strings_RegExpMatchin.MatchString_RegExp();

            Console.ReadKey();
        }

        static void COmputeAreEqual()
        {
            var result = AreSameNumbers_Version1(4, 5);
            Console.WriteLine(result);

            result = AreSameNumbers_Version1(5, 5);
            Console.WriteLine(result);


            var result2 = AreSameNumbers_Version2(4, 5);
            Console.WriteLine(result2);

            result2 = AreSameNumbers_Version2(5, 5);
            Console.WriteLine(result2);
        }

        static bool AreSameNumbers_Version1(int x, int y)
        {
            HashSet<int> hs = new HashSet<int>();

            hs.Add(x);

            if (hs.Contains(y))  //If y is in the HashSet means x and y are same values
                return true;
            else
                return false;
        }

        static bool AreSameNumbers_Version2(int x, int y)
        {
            var diff = x - y;

            var boolValue = Convert.ToBoolean(diff); //This method returns FALSE if diff is 0. It returns TRUE for any other positive or Negative number

            return !boolValue; // if we get FALSE means diff is 0, that means x and y are same numbers. 
        }
    }
}
