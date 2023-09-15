using System.Collections.Generic;

namespace _8._List_of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number=int.Parse(Console.ReadLine());
            int[]arrayNumbers=Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            List<Predicate<int>>list= new List<Predicate<int>>();
            for (int i = 2; i <= number; i++)
            {
                foreach (var item in arrayNumbers)
                {
                    Predicate<int> predicate = (item) => i % item != 0;
                    bool isDivisible = predicate(item);
                    if (isDivisible)
                    {
                        list.Add(predicate);
                    }

                }
            }
          
            foreach (var item in list)
            {
                int num = 0;
                bool isDivisible = false;
                for (int i = 1; i <= number; i++)
                {
                    if (item(i))
                    {
                        isDivisible = true;
                        num = i;
                        break;
                    }
                }
                if (isDivisible)
                {
                    Console.Write($"{num} ");
                }
               
            }

           
           
           

            //for (int i = 2; i <= number; i++)
            //{
            //    bool isDivible = false;
            //    for (int j = 0; j < arrayNumbers.Length; j++)
            //    {
            //        if (i % arrayNumbers[j] != 0)
            //        {
            //            isDivible = true;
            //            break;
            //        }
            //    }
            //    if (!isDivible)
            //    {
            //        Console.Write($"{i} ");
            //    }

            //}
         

        }
      


    }
}