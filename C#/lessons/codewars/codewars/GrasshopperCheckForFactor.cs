namespace codewars;

public class GrasshopperCheckForFactor
{
    public static bool CheckForFactor(int num, int factor)
    {
        if (factor == 0) return false;
        return num % factor == 0;
    }
}
