using ReflectionHometask;
using System.Diagnostics;

Checks checks = new();
F f = new F() { i1 = 1, i2 = 2, i3 = 3, i4 = 4, i5 = 5 };
checks.CheckSerializationTime(f);
checks.CheckSerializationWithPrintTime(f);
checks.CheckJsonSerializationTime(f);
checks.CheckJsonDeserializationTime(f);



Stopwatch stopwatch = new();
stopwatch.Start();
for (int i = 0; i < 1000; i++)
{
    Serializer.DeserializeCsv<F>("File.csv");
}
stopwatch.Stop();
Console.WriteLine($"Deserialization Csv To Obj time: {stopwatch.ElapsedMilliseconds}");


