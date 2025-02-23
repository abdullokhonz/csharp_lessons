namespace LeetCode
{
    public class _2_ListNode
    {
        public int val;
        public _2_ListNode next;
        public _2_ListNode(int val = 0, _2_ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class _2_AddTwoNumbers
    {
        public _2_ListNode AddTwoNumbers(_2_ListNode l1, _2_ListNode l2)
        {
            int carry = 0;
            _2_ListNode dummyHead = new _2_ListNode();
            _2_ListNode current = dummyHead;

            while (l1 != null || l2 != null || carry != 0)
            {
                int val1 = l1 != null ? l1.val : 0;
                int val2 = l2 != null ? l2.val : 0;

                int total = val1 + val2 + carry;
                carry = total / 10;
                current.next = new _2_ListNode(total % 10);
                current = current.next;

                if (l1 != null) l1 = l1.next;
                if (l2 != null) l2 = l2.next;
            }

            return dummyHead.next;
        }
    }
}
