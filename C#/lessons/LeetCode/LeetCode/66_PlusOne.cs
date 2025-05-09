namespace LeetCode
{
    public class _66_PlusOne
    {
        public int[] PlusOne(int[] digits)
        {
            List<int> listOfDigits = new List<int>(digits);

            for (int i = listOfDigits.Count - 1; i >= 0; i--)
            {
                if (listOfDigits[i] < 9)
                {
                    listOfDigits[i]++;
                    return listOfDigits.ToArray();
                }
                listOfDigits[i] = 0;
            }

            // Если все цифры были 9 (например, [9, 9, 9]), добавляем 1 в начало
            listOfDigits.Insert(0, 1);

            foreach (int i in listOfDigits)
            {
                Console.Write(i + ", ");
            }

            return listOfDigits.ToArray();
        }

    }
}
