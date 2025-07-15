namespace LeetCode
{
    public class _148_SortList
    {
        public ListNode SortList(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            ListNode slow = head, fast = head, prev = null;
            while (fast != null && fast.next != null)
            {
                prev = slow;
                slow = slow.next;
                fast = fast.next.next;
            }

            prev.next = null;

            ListNode l1 = SortList(head);
            ListNode l2 = SortList(slow);

            return Merge(l1, l2);
        }

        private ListNode Merge(ListNode l1, ListNode l2)
        {
            ListNode dummy = new ListNode();
            ListNode tail = dummy;

            while (l1 != null && l2 != null)
            {
                if (l1.val < l2.val)
                {
                    tail.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    tail.next = l2;
                    l2 = l2.next;
                }
                tail = tail.next;
            }

            tail.next = (l1 != null) ? l1 : l2;

            return dummy.next;
        }
    }
}
