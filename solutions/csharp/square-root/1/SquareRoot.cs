public static class SquareRoot
{
    public static int Root(int number)
    {
        bool solved = false;
        int x = 0;
        while (!solved)
        {
            x++;
            solved = x == (number / x);
        }

        return x;
    }
}
