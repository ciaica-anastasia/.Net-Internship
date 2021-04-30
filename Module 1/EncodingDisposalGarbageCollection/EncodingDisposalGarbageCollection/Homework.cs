using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace EncodingDisposalGarbageCollection
{
    public class Homework
    {
        static void Main(string[] args)
        {
            //use encodings in writing to file stream
            string writePath =
                @"/Users/Ciaica_Anastasia/Desktop/Computer Science/C#, .Net/Amdaris/EncodingDisposalGarbageCollection/EncodingDisposalGarbageCollection/file.txt";

            FileStream fs = new FileStream(writePath, FileMode.Open);

            string text = "Hello, world! This is Pi (\u03C0)";
            var bytes = Encoding.UTF8.GetBytes(text);
            var bytesCount = Encoding.UTF8.GetByteCount(text);
            
            fs.Write(bytes, 0, bytesCount);

            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, true, Encoding.UTF8))
                {
                    sw.WriteLine(text);
                }

                using (StreamWriter sw = new StreamWriter(writePath, true, Encoding.UTF8))
                {
                    sw.WriteLine("Дозапись");
                    sw.Write('!');
                }

                Console.WriteLine("Запись выполнена");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            fs.Dispose(); //better with using 

            //string formatting, searching and comparing
            string s1 = "Sample string for exercise.";
            Console.WriteLine(s1.Contains("Sample"));
            Console.WriteLine(s1.StartsWith("sample", StringComparison.CurrentCultureIgnoreCase));
            Console.WriteLine(s1.EndsWith("."));

            Person person = new Person {Name = "Tom", Age = 23};
            string output = String.Format("Имя: {0, -20}  Возраст: {1, 5}", person.Name, person.Age);
            Console.WriteLine(output);

            person = null;
            GC.Collect();
            Console.ReadLine();

            var firstString = "Hello";
            var secondString = "hello";
            Console.WriteLine(firstString.Equals(secondString, StringComparison.InvariantCultureIgnoreCase));

            //cultureinfo
            var culture = CultureInfo.GetCultureInfo("tr-Tr"); //different culture
            var str = "i";
            Console.WriteLine("I".Equals(str.ToUpper(culture))); //false
            Console.WriteLine(str.ToUpper(culture)); //İ

            //timespan
            TimeSpan span = new TimeSpan(1, 2, 1, 0, 0);
            Console.WriteLine(span);

            TimeSpan span1 = TimeSpan.FromMinutes(1);
            TimeSpan span2 = TimeSpan.FromMinutes(2);
            TimeSpan span3 = span1 + span2;
            Console.WriteLine(span3);
            
            //datetime
            DateTime date1 = new DateTime(2020, 7, 20, 18, 30, 25); // 20.07.2020 18:30:25
            DateTime date2 = new DateTime(2020, 7, 20, 15, 30, 25); // 20.07.2020 15:30:25
            Console.WriteLine(date1.Subtract(date2)); // 03:00:00
            
            DateTime date3 = new DateTime(2020, 7, 20, 18, 30, 25); // 20.07.2020 18:30:25
            Console.WriteLine(date1.AddHours(3)); // 20.07.2020 21:30:25
            
            //datetimeoffset
            DateTime localTime = DateTime.Now;
            Console.WriteLine(localTime);
            DateTime specifiedKind = DateTime.SpecifyKind(localTime, DateTimeKind.Local);
            DateTimeOffset dateAndOffset = specifiedKind;
            Console.WriteLine(dateAndOffset);
            
            //timezone
            TimeZoneInfo zone = TimeZoneInfo.Local;
            Console.WriteLine(zone.StandardName); //Eastern European Standard Time
            Console.WriteLine(zone.DaylightName); //Eastern European Summer Time
            Console.WriteLine(zone.IsDaylightSavingTime(date1)); //true
            Console.WriteLine(zone.GetUtcOffset(date2)); //03:00:00
        }
    }

    class Person : IDisposable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        
        public override string ToString() => GetType().Name;

        ~Person()
        {
            ReleaseUnmanagedResources();
        }

        private void ReleaseUnmanagedResources()
        {
            //make null
        }

        public void Dispose()
        {
            ReleaseUnmanagedResources();
            GC.SuppressFinalize(this);
        }
    }
}
