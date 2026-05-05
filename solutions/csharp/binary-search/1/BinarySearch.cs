public static class BinarySearch
{
    public static int Find(int[] input, int value)
    {
        int upper = input.Length - 1;
        int lower = 0;

        while (lower <= upper)
        {
            var middle = (upper + lower) / 2;
            if (value > input[middle])
            {
                lower = middle + 1;
            }
            else if (value < input[middle])
            {
                upper = middle - 1;
            }
            else if (value == input[middle])
            {
                return middle;
            }
        }

        return -1;

    }
}