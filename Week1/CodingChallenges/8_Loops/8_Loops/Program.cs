

using System;
using System.Collections.Generic;
using System.Linq;

namespace _8_LoopsChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /* Your code here */

        }

        /// <summary>
        /// Return the number of elements in the List<int> that are odd.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int UseFor(List<int> x)
        {
            //throw new NotImplementedException("UseFor() is not implemented yet.");
            int odds = 0;
            foreach (int i in x)
            {
                if (i % 2 == 1)
                {
                    odds++;
                }
            }
            return odds;
        }

        /// <summary>
        /// This method counts the even entries from the provided List<object> 
        /// and returns the total number found.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int UseForEach(List<object> x)
        {
            //throw new NotImplementedException("UseForEach() is not implemented yet.");
            int evens = 0;
            foreach (var i in x)
            {
                if ((i is int &&  (int)i % 2 == 0) || (i is long && (long)i % 2 == 0))
                {
                    evens++;
                }
            }
            return evens;
        }

        /// <summary>
        /// This method counts the multiples of 4 from the provided List<int>. 
        /// Exit the loop when the integer 1234 is found.
        /// Return the total number of multiples of 4.
        /// </summary>
        /// <param name="x"></param>
        public static int UseWhile(List<int> x)
        {
            //throw new NotImplementedException("UseFor() is not implemented yet.");

            int i = 0;
            int fours = 0;
            while (i < x.Count)
            {
                int num = x[i];
                if (num == 4)
                {
                    fours++;
                }
                else if (num == 1234)
                {
                    break;
                }
                i++;
            }
            return fours;
        }

        /// <summary>
        /// This method will evaluate the Int Array provided and return how many of its 
        /// values are multiples of 3 and 4.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int UseForThreeFour(int[] x)
        {
            //throw new NotImplementedException("UseForThreeFour() is not implemented yet.");
            int count = 0;
            for (int i = 0; i < x.Length; i++)
            {
                if (i % 12 == 0)
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// This method takes an array of List<string>'s. 
        /// It concatenates all the strings, with a space between each, in the Lists and returns the resulting string.
        /// </summary>
        /// <param name="stringListArray"></param>
        /// <returns></returns>
        public static string LoopdyLoop(List<string>[] stringListArray)
        {
            //throw new NotImplementedException("LoopdyLoop() is not implemented yet.");
            string sentence = "";
            foreach (List<string> stringList in stringListArray)
            {
                
                foreach (string s in stringList)
                {
                    sentence += " " + s; 
                }
            }
            Console.WriteLine(sentence.TrimStart());
            return sentence.TrimStart();
        }
    }
}

//using System;
//using System.Collections.Generic;

//namespace _8_LoopsChallenge
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            /* Your code here */

//        }

//        /// <summary>
//        /// Return the number of elements in the List<int> that are odd.
//        /// </summary>
//        /// <param name="x"></param>
//        /// <returns></returns>
//        public static int UseFor(List<int> x)
//        {
//            throw new NotImplementedException("UseFor() is not implemented yet.");
//        }

//        /// <summary>
//        /// This method counts the even entries from the provided List<object> 
//        /// and returns the total number found.
//        /// </summary>
//        /// <param name="x"></param>
//        /// <returns></returns>
//        public static int UseForEach(List<object> x)
//        {
//            throw new NotImplementedException("UseForEach() is not implemented yet.");
//        }

//        /// <summary>
//        /// This method counts the multiples of 4 from the provided List<int>. 
//        /// Exit the loop when the integer 1234 is found.
//        /// Return the total number of multiples of 4.
//        /// </summary>
//        /// <param name="x"></param>
//        public static int UseWhile(List<int> x)
//        {
//            throw new NotImplementedException("UseFor() is not implemented yet.");
//        }

//        /// <summary>
//        /// This method will evaluate the Int Array provided and return how many of its 
//        /// values are multiples of 3 and 4.
//        /// </summary>
//        /// <param name="x"></param>
//        /// <returns></returns>
//        public static int UseForThreeFour(int[] x)
//        {
//            throw new NotImplementedException("UseForThreeFour() is not implemented yet.");
//        }

//        /// <summary>
//        /// This method takes an array of List<string>'s. 
//        /// It concatenates all the strings, with a space between each, in the Lists and returns the resulting string.
//        /// </summary>
//        /// <param name="stringListArray"></param>
//        /// <returns></returns>
//        public static string LoopdyLoop(List<string>[] stringListArray)
//        {
//            throw new NotImplementedException("LoopdyLoop() is not implemented yet.");
//        }
//    }
//}