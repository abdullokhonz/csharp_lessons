namespace ReturnMaximumHourMinute
{
    public class MaxHourMinute
    {
        public static string Max(int[] inputArray)
        {
            int maxHour = -1;
            int maxMinute = 0;

            for (int i = 0; i < inputArray.Length; i++)
            {
                for (int j = 0; j < inputArray.Length; j++)
                {
                    if (i == j) continue;
                    int hour = inputArray[i] * 10 + inputArray[j];
                    if (hour >= 0 && hour <= 23)
                    {
                        for (int k = 0; k < inputArray.Length; k++)
                        {
                            if (k == i || k == j) continue;
                            for (int l = 0; l < inputArray.Length; l++)
                            {
                                if (l == i || l == j || l == k) continue;
                                int minute = inputArray[k] * 10 + inputArray[l];
                                if (minute >= 0 && minute <= 59)
                                {
                                    if (hour > maxHour || (hour == maxHour && minute > maxMinute))
                                    {
                                        maxHour = hour;
                                        maxMinute = minute;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return "-1";
        }
    }
}
