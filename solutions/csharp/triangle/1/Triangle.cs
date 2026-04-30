public static class Triangle
{
    public static bool IsTriangle(List<double> sides)
    {
        sides.Sort();
        return !sides.All(x => x == 0) && sides[0] + sides[1] >= sides[2];
    }

    public static bool IsScalene(double side1, double side2, double side3)
    {
        var sides = new List<double> { side1, side2, side3 };
        return IsTriangle(sides) && sides.Distinct().Count() == 3;
    }

    public static bool IsIsosceles(double side1, double side2, double side3)
    {
        var sides = new List<double> { side1, side2, side3 };
        return IsTriangle(sides) && (sides.Distinct().Count() == 2 || IsEquilateral(side1, side2, side3));
    }

    public static bool IsEquilateral(double side1, double side2, double side3)
    {
        var sides = new List<double> { side1, side2, side3 };
        return IsTriangle(sides) && sides.Distinct().Count() == 1;
    }
}