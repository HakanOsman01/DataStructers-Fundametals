namespace ArraySimetric
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string,int>parser=(s)=>int.Parse(s);
            int[]array=Console.ReadLine()
            .Split(" ",StringSplitOptions.RemoveEmptyEntries)
            .Select(parser)
            .ToArray();
            GetIsSimetrical(array, 0, array.Length - 1);


        }
        static void GetIsSimetrical(int[]array,int star,int end)
        {
            if (star >= end)
            {
                Console.WriteLine("Yes");
                return;
            }
            int currentStartElement = array[star]; 
            int currentEnd = array[end];
            if(currentStartElement != currentEnd)
            {
                Console.WriteLine("No");
                return;
            }
            GetIsSimetrical(array, star + 1, end - 1);


        }
    }
}