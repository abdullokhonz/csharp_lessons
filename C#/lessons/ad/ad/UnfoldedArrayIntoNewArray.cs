namespace ad
{
    public class UnfoldedArrayIntoNewArray
    {
        public void ReverseArray()
        {
            //var reversed = Console.ReadLine()
            //                  .Split()
            //                  .Select(int.Parse)
            //                  .Reverse()
            //                  .ToArray();

            //Console.WriteLine("Новый массив: " + string.Join(" ", reversed));

            Console.WriteLine("Новый массив: " + string.Join(" ", Console.ReadLine().Split().Select(int.Parse).Reverse()));
        }
    }
}
