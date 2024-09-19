using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;

namespace Test2
{
    internal class Program
    {

        const string Note = "db.txt";
        static void Main(string[] args)
        {
            Menu(Note);
        }
        static void Menu(string path)
        {
            Check(path);
            char key = '0';
            do
            {
                Console.WriteLine("Запись данных = 1 , Вывод данных = 2 , Завершить запись 0\n");
                key = Console.ReadKey(true).KeyChar;
                switch (key)
                {
                    case '0':
                        break;
                    case '1':
                        Imput();
                        break;
                    case '2':
                        Print();
                        break;
                    default:
                        Console.WriteLine("Неизвестная команда ");
                        break;
                }
                Console.WriteLine();
            }
            while (key != '0');

        }
        static void Imput()
        {
            int id = 1;
            id = File.ReadAllLines(Note).Length + 1;

            using (StreamWriter sw = new StreamWriter(Note, true, Encoding.Unicode))// запись данных в файл
            {

                {
                    string note = string.Empty;
                    Console.Write($"Ваш Id: {id}");
                    note += $"{id++}\t";

                    DateTime now = DateTime.Now;
                    Console.WriteLine($"\nДата и время : {now}");
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
                }
            }
        }
        static void Print()
        {
            using (StreamReader sr = new StreamReader(Note, Encoding.Unicode))// Вывод данных из файла
            {

                string lines;
                while ((lines = sr.ReadLine()) != null)
                {
                    string[] data = lines.Split();
                    Console.WriteLine(string.Join("#", data[0], data[1], data[2], data[3], data[4], data[5], data[6]));
                }
            }
            using (StreamReader sr = new StreamReader(Note, Encoding.Unicode))
            {
                string lines = sr.ReadLine();
                if (lines == null)
                {
                    Console.WriteLine("Файл пустой");
                }
            }

        }
        static void Check(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
                Console.WriteLine("Файл создан ");
            }
            else
            {
                Console.WriteLine("Файл существует ");
            }
        }

    }
}

