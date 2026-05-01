namespace _2.AddTwoNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            ListNode l1 = new ListNode(2, new ListNode(4, new ListNode(3)));
            ListNode l2 = new ListNode(5, new ListNode(6, new ListNode(4)));
            Print(AddTwoNumbers(l1, l2));
        }

        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            // "Пустышка" (dummy head), чтобы было удобно прикреплять узлы
            ListNode dummyHead = new ListNode(0);
            ListNode current = dummyHead;
            int carry = 0; // Перенос в следующий разряд

            // Цикл работает, пока есть узлы в списках ИЛИ остался перенос
            while (l1 != null || l2 != null || carry != 0)
            {
                // Берем значения (если список кончился, берем 0)
                int x = (l1 != null) ? l1.val : 0;
                int y = (l2 != null) ? l2.val : 0;

                // Считаем сумму разряда + перенос
                int sum = carry + x + y;
                carry = sum / 10; // Вычисляем новый перенос (например, 14 / 10 = 1)

                // Создаем новый узел с остатком (например, 14 % 10 = 4)
                current.next = new ListNode(sum % 10);
                current = current.next;

                // Двигаемся дальше по спискам
                if (l1 != null) l1 = l1.next;
                if (l2 != null) l2 = l2.next;
            }

            return dummyHead.next; // Возвращаем список, начиная со следующего после пустышки
        }

        public static void Print(ListNode node)
        {
            while (node != null)
            {
                Console.Write(node.val + " -> ");
                node = node.next;
            }
            Console.WriteLine("null");
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}
