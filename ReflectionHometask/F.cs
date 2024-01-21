using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionHometask
{
    public class F
    {
        public int i1 { get; set; }
        public int i2 { get; set; }
        public int i3 { get; set; }
        public int i4 { get; set; }
        public int i5 { get; set; }
    }

    public class Checks()
    {
        public void CheckSerializationTime(object f)
        {
            Stopwatch stopwatch = new();
            stopwatch.Start();
            for (int i = 0; i < 1000; i++)
            {
                Serializer.SerializeObjectToString(f);
            }
            stopwatch.Stop();
            Console.WriteLine($"Simple Object To String Serialization execution time: {stopwatch.ElapsedMilliseconds}");
        }

        public void CheckSerializationWithPrintTime(object f)
        {
            Stopwatch stopwatch = new();
            stopwatch.Start();
            for (int i = 0; i < 1000; i++)
            {
                string serializedString = Serializer.SerializeObjectToString(f);
                Console.WriteLine(serializedString);
            }
            stopwatch.Stop();
            Console.WriteLine($"Object To String Serialization with printing execution time: {stopwatch.ElapsedMilliseconds}");
        }

        public void CheckJsonSerializationTime(object f)
        {
            Stopwatch stopwatch = new();
            stopwatch.Start();
            for (int i = 0; i < 1000; i++)
            {
                JsonConvert.SerializeObject(f);
            }
            stopwatch.Stop();
            Console.WriteLine($"Json Serialization Excecition time: {stopwatch.ElapsedMilliseconds}");
        }

        public void CheckJsonDeserializationTime(object f)
        {
            var json = JsonConvert.SerializeObject(f);
            Stopwatch stopwatch = new();
            stopwatch.Start();
            for (int i = 0; i < 1000; i++)
            {
                JsonConvert.DeserializeObject<F>(json);
            }
            stopwatch.Stop();
            Console.WriteLine($"Json Deserialization Excecition time: {stopwatch.ElapsedMilliseconds}");
        }

    }

}
