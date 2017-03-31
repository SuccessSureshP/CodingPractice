using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_Coding_Problems
{
    public static class Strings_RegExpMatchin
    {
        public static void MatchString_RegExp()
        {   
            StringMatchingWithRegExp("abc", "a*b.c");
            StringMatchingWithRegExp("abxc", "a*b.c");
            StringMatchingWithRegExp("bc", "a*bc");
            StringMatchingWithRegExp("bx", "a*b.c*");
            StringMatchingWithRegExp("bc", "a*b.c*");
        }

        private static void StringMatchingWithRegExp(string str, string exp)
        {
            var result =  StringMatchingWithRegExp(str, 0, str.Length, exp, 0, exp.Length);

            Console.WriteLine($"{str} matches with reg expression {exp}: " + result);
        }

        private static bool StringMatchingWithRegExp(string str, int v1, int length1, string exp, int v2, int length2)
        {
            if (v1 >= length1 && v2 >= length2)
                return true;

            //if ((v1 >= length1 && v2 != length2) || (v1 != length1 && v2 >=length2))
            if (v1 <= length1 && v2 >= length2)
                return false;

            if (v2 + 1 < length2 && exp[v2 + 1] == '*') //next char is * in exp
            {
                if ( (v1 < length1  && exp[v2] == str[v1]) || (exp[v2] == '.' && v1 < length1)) //If current letter matches or we have . in current position in exp and any char in the str
                {
                    //consider char and exp
                    return StringMatchingWithRegExp(str, v1 + 1, length1, exp, v2 + 2, length2)
                        //considering the char in str , but keeping the postion in exp as it is to compre with next char
                        || StringMatchingWithRegExp(str, v1 + 1, length1, exp, v2, length2)
                        //Ignoring the exp and considering the char in str to compare with next char in the exp
                        || StringMatchingWithRegExp(str, v1, length1, exp , v2+2, length2);

                }
                else
                    return StringMatchingWithRegExp(str, v1, length1, exp, v2 + 2, length2); // Since charcaters not matched. ignore the exp 
            }
            else if ((v1 < length1 && exp[v2] == str[v1]) || (exp[v2] == '.' && v1 < length1))
                return StringMatchingWithRegExp(str, v1 + 1, length1, exp, v2 + 1, length2); // consider 1 :1 match. So increment by 1 on each string
            else
                return false;
        }
    }
}
