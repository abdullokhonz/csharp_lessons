using static LeetCode.ListNode;

namespace LeetCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            _148_SortList test = new _148_SortList();

            OutputListNode(test.SortList(InputListNode([4, 2, 1, 3])));
        }
    }
}
