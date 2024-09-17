using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Test1
{

    internal class Program
    {


        static void Pause()
        {
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Запись данных = д , Выводл данных = н");
            char key = Console.ReadKey(true).KeyChar;
            while (char.ToLower(key) == 'д')
            {
                
                using (StreamWriter sw = new StreamWriter("db.txt", true, Encoding.Unicode))// запись данных в файл
                {

                    {
                        string note = string.Empty;
                        Console.Write("Введите ваш ID: ");
                        note += $"{Console.ReadLine()}\t";

                        DateTime now = DateTime.Now;
                        Console.WriteLine($"Дата и время :{now}");
                        note += $"{now}\t";

                        Console.Write("Ф.И.О: ");
                        note += $"{Console.ReadLine()}\t";

                        Console.Write("Возраст: ");
                        note += $"{Console.ReadLine()}\t";

                        Console.Write("Рост: ");
                        note += $"{Console.ReadLine()}\t";

                        Console.Write("Дата рождения: ");
                        note += $"{Console.ReadLine()}\t";

                        Console.Write("Место рождения: ");
                        note += $"{Console.ReadLine()}\t";

                        sw.WriteLine(note);
                        Console.WriteLine("Продожить н/д"); key = Console.ReadKey(true).KeyChar;
                    }
                }
            }

            using (StreamReader sr = new StreamReader("db.txt", Encoding.Unicode))// Вывод данных из файла
            {
                {
                    string lines;
                    while ((lines = sr.ReadLine()) != null)
                    {
                        string[] data = lines.Split('\t');
                        Console.WriteLine($"{data[0],3} {data[1]} {data[2]} {data[3]} {data[4]} {data[5]} {data[6]}");
                    }
                }
            }
            Pause();
        }
    }
}

