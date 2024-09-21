namespace Structures_and_collections
{
    public interface InterfaceForStruct
    {
        public int InterfaceValue { get; set; }

        public void InterfaceMethod(int value)
        {
            this.InterfaceValue = value;
        }
    }

    public struct MyStruct : InterfaceForStruct
    {
        public int InterfaceValue
        {
            get => StructValue;
            set => StructValue = value;
        }
        public string StructString;
        private int StructValue;

        public List<int> StructList = new();

        public void AddValueToList(int value)
        {
            StructList.Add(value);
        }

        public void RemoveValueToList(int value)
        {
            if (StructList.Contains(value))
                StructList.Remove(value);
            else
                Console.WriteLine($"В списке нет значения {value}");
        }

        public MyStruct(string StructString, int interfaceValue) : this()
        {
            this.StructString = StructString;
            this.InterfaceValue = interfaceValue;

            Console.WriteLine("Создан экземпляр структуры MyStruct c параметрами:" +
                $"\n\t StructString: {StructString}" +
                $"\n\t InterfaceValue: {interfaceValue}");
        }
    }

}
