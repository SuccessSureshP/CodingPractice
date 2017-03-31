using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_Coding_Problems
{
    //Implement Stack with Min property all with O(1) complexity in both space and time
    public class Stack_With_Min
    {
        public static void PerformStackWithMin()
        {
            StackWithMinValue stkWithMin = new StackWithMinValue();
            stkWithMin.Push(20);
            stkWithMin.Push(25);
            Console.WriteLine("Min So far:" + stkWithMin.Min);
            stkWithMin.Push(3);
            Console.WriteLine("Top Element:" + stkWithMin.Peek());
            Console.WriteLine("Min So far:" + stkWithMin.Min);
            stkWithMin.Push(3);
            Console.WriteLine("Top Element:" + stkWithMin.Peek());
            Console.WriteLine("Min So far:" + stkWithMin.Min);
            stkWithMin.Push(2);
            Console.WriteLine("Min So far:" + stkWithMin.Min);
            var popedValue =  stkWithMin.Pop();
            Console.WriteLine("Popped Value:" + popedValue); 
            Console.WriteLine("Min So far:" + stkWithMin.Min);
            popedValue = stkWithMin.Pop();
            Console.WriteLine("Popped Value:" + popedValue);
            Console.WriteLine("Min So far:" + stkWithMin.Min);
            popedValue =  stkWithMin.Pop();
            Console.WriteLine("Poped Value:" + popedValue);
            Console.WriteLine("Min So far:" + stkWithMin.Min);
            Console.ReadKey();
        }
        
    }

    //Without using extra stack
    public class StackWithMinValue
    {
        Stack<int> st = new Stack<int>();
        int? min;
        int count = 0;

        public void Push(int v)
        {
            if(count ==0)
            {
                st.Push(v);
                min = v;
            }
            else
            {
                if (v < min) //newly inserted value is smaller than current min. i.e. We found new minimum number
                {
                    st.Push(2 * v - Min);  // Keeping this value to get previous min value
                    min = v; //keeping the latest min      
                }
                else
                    st.Push(v);
            }
            count++;
        }

        public int Pop()
        {
            int returnValue;
            if (min > st.Peek())
            {
                returnValue = Min;
                min = 2 * min - st.Peek(); //updating the min with previous min
                st.Pop();
            }
            else
             returnValue = st.Pop();

            count--;
            if (count == 0)
                min = null;
            return returnValue;
            
        }

        //Peek or Top method
        public int Peek()
        {
            if (Min > st.Peek())
                return Min;
            else
                return st.Peek();            
        }

        public int Min
        {
            get {
                if (min == null)
                    throw new Exception("Stack is empty");
                return (int)min;

            }
        }
    }
}

