namespace LeetCode
{
    public class ListNode // ← ✅
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }

        public static ListNode InputListNode(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return null;

            ListNode head = new ListNode(nums[0]);
            ListNode current = head;

            for (int i = 1; i < nums.Length; i++)
            {
                current.next = new ListNode(nums[i]);
                current = current.next;
            }

            return head;
        }

        public static void OutputListNode(ListNode list)
        {
            while (list != null)
            {
                Console.Write(list.val + " ");
                list = list.next;
            }
            Console.WriteLine();
        }

    }
}
