public static class EliudsEggs
{
    public static int EggCount(int encodedCount)
    {
        int count = 0;
        for (int i = 0; i < 32; i++)
        {
            count += (encodedCount & (1 << i)) != 0 ? 1 : 0;

        }

        return count;

    }
}
