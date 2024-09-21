static class OverloadingTest
{
    public static void Main()
    {
        MyOverloadMethod(0, 0, out float value);

        Console.WriteLine($"Итоговое значение: {value}");
        Console.ReadKey();
    }

    public static void MyOverloadMethod()=>
        Console.WriteLine("Base Method\n");

    public static void MyOverloadMethod(int x) =>
        Console.WriteLine($"Overload with 1 value: {x}");

    public static void MyOverloadMethod(int x, int y)=>
        Console.WriteLine($"Overload with 2 values, X: {x} Y: {y}");

    public static void MyOverloadMethod(int x, int y, out float z)
    {
        z = 1.1f;

        Console.WriteLine($"Overload with 3 values, X: {x} Y: {y}, Z: {z}");
    }
}