using System;

namespace Generics
{
    class Program
    {
        static void Main()
        {
            var intClass = new GetValue<int>
            {
                Value = 20
            };

            var stringClass = new GetValue<string>()
            {
                Value = "Test"
            };

            intClass.PrintValue("Integer", intClass.Value);
            stringClass.PrintValue("String", stringClass.Value);

            Console.ReadKey();
        }
    }

    internal class GetValue<T>
    {
        private T _data;

        public T Value
        {
            get => _data;
            set => _data = value;
        }

        public void PrintValue<TYpeOfValue>(string msg, TYpeOfValue val)
        {
            Console.WriteLine($"Message: {msg} and Value: {val}");
        }
    }
}
