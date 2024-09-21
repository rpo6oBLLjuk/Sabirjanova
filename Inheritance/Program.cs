public class Inheritance
{
    public static void Main()
    {
        MyDamagableEntity myEntity = new("test name", "test type", 18, 100);

        myEntity.GetDamage(10);
    }
}