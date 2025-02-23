namespace LeetCode
{
    public class _21_ListNode
    {
        public int val;
        public _21_ListNode next;
        public _21_ListNode(int val = 0, _21_ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class _21_MergeTwoSortedLists
    {
        public _21_ListNode MergeTwoLists(_21_ListNode list1, _21_ListNode list2)
        {
            _21_ListNode dummy = new _21_ListNode();
            _21_ListNode current = dummy;

            while (list1 != null && list2 != null)
            {
                if (list1.val < list2.val)
                {
                    current.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    current.next = list2;
                    list2 = list2.next;
                }
                current = current.next;
            }

            if (list1 != null)
            {
                current.next = list1;
            }
            else
            {
                current.next = list2;
            }

            return dummy.next;
        }
    }
}
