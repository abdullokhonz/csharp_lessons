namespace LeetCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            _2962_Count_Subarrays_Where_Max_Element_Appears_At_Least_K_Times test = new _2962_Count_Subarrays_Where_Max_Element_Appears_At_Least_K_Times();

            Console.WriteLine(test.CountSubarrays([1, 3, 2, 3, 3], 2));
            Console.WriteLine(test.CountSubarrays([1, 4, 2, 1], 3));
        }
    }
}
