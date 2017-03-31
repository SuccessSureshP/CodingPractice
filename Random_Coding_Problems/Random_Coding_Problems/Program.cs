using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_Coding_Problems
{
    class Program
    {
        static void Main(string[] args)
        {

            //CountReversedPairs_InAnArray.CountReversedPairs();
            LinkedList_MergeSort.PerformLinkedList_MergeSort();
            Console.ReadKey();

            //string str = "AAB";
            //string str = "AABC";  -- Negative case
            //string str = "BABACAA";
            string str = "DDDAACAAACCCD";
            IsItPotentialPalindrome(str);

            Console.ReadKey();
        }

         static void IsItPotentialPalindrome(string str)
        {
            char[] input = str.ToCharArray();
            //Below is O(n) solution. Space also o(n) worse case
            Hashtable ht = new Hashtable();
            foreach (char chr in input)
            {
                if (ht.Contains(chr))
                    ht[chr] = ((int)ht[chr]) + 1;
                else
                    ht.Add(chr, 1);
            }

            int oddCount = 0;
            foreach (var key in ht.Keys)
            {
                if (((int)ht[key]) % 2 != 0) //if we found odd # of occurrence of this character
                    oddCount++;
            }

            if (oddCount == 0 || oddCount == 1)
                Console.WriteLine("String is a potential palindrome");
            else
                Console.WriteLine("String is not a potential palindrome");
        }
      
    }
}
