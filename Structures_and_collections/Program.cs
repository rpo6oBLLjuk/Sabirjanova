namespace Structures_and_collections
{
    public static class Structures_and_collections
    {
        public static MyStruct myStruct;

        public static void Main()
        {
            myStruct = new MyStruct("new  name", 1);

            for (int i = 0; i < 5; i++)
                myStruct.AddValueToList((i + 1) * 10);

            myStruct.StructList = myStruct.StructList
                .Select((int value, int count) =>
                {
                    Console.WriteLine($"Value {count}: {value}");
                    return value;
                })
                .ToList();
        }
    }
}