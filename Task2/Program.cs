static class Converter
{
    public static void Main()
    {
        const float dol = 1;
        const float rub = 90.9f;
        const float euro = 0.906f;
        const float rubBel = 3.28f;
        const float grivn = 41.18f;

        float firstValue = 0;
        float secondValue = 0;

        if (!float.TryParse(Console.ReadLine(), out firstValue))
        {
            ErrorWrite();
            return;
        }

        if (!float.TryParse(Console.ReadLine(), out secondValue))
        {
            ErrorWrite();
            return;
        }
    }

    public static void ErrorWrite()
    {
        Console.WriteLine("Введено неверное значение");
    }
}