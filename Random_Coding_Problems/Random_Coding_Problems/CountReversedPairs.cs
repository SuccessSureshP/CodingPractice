using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_Coding_Problems
{
    //Found in Chapters to Go book. Chapter 7 : Optimization
    public class CountReversedPairs_InAnArray
    {
        public static void CountReversedPairs()
        {
            int[] a = { 7, 5, 6, 4 };
            //output = 5 because we have 5 reversed pairs : (7,5) (7,6) (7,4) (5,4) (6,4)
            //Brute Force : Take each number and compare with rest of the numbers on the right. it is O(n2)./ 
            //Below is based on Marge sort. it is O(nLogn)
            int[] buffer = new int[a.Length]; // Research deeper for usage of this array across the calls
            int r =  CountReversedPairs(a, buffer, 0, a.Length-1);

            Console.WriteLine("Reversed Paris:" + r);
        }

        private static int CountReversedPairs(int[] a, int[] buffer, int st, int end)
        {
            if (st >= end)
                return 0;

            int mid = (st + end) / 2;

            int left = CountReversedPairs(a, buffer, st, mid);
            int right = CountReversedPairs(a, buffer, mid+1,end);
            int between = MergeCountOfReversedParis(a, buffer, st, mid, end);

            return left + right + between;

        }

        private static int MergeCountOfReversedParis(int[] a, int[] buffer, int st, int mid, int end)
        {
            //start comparing the 1st half and 2nd half backwards. means, start from middle number and compare with end number and so on.

            int k = end;
            int i = mid;
            int j = end;            

            int reversedPairCount = 0;
            while (i >= st && j >= mid + 1)
            {
                if (a[i] > a[j]) //means we found an element in 1st half that is greater than all elements in the 2nd half from mid to that number (at j)
                {
                    reversedPairCount += j - mid; // this a[i] will be great than all elements in the 2nd half from mid to j position
                    buffer[k--] = a[i--];
                }
                else
                    buffer[k--] = a[j--];
            }

            while (i >= st)
                buffer[k--] = a[i--];
            while (j >= mid + 1)
                buffer[k--] = a[j--];

            //now copy sorted values back to the array segment (from st to end)
            for (i = st; i <= end; i++)
                a[i] = buffer[i];

            return reversedPairCount;
        }

    }
}
