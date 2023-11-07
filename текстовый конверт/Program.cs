using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Runtime.ConstrainedExecution;
using System.Xml.Serialization;

namespace текстовый_конверт
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ocnov figuri = new ocnov();
            List<ocnov> text = new List<ocnov>();
            string[] per = new string[4];
            ConsoleKeyInfo der;
            do
            {
                text.Clear();
                Console.WriteLine("Введите путь до файла, который вы хотите открыть");
                Console.WriteLine("-------------------------------------------------");
                string asd = Console.ReadLine();
                if (asd.EndsWith(".txt"))
                {            
                    ocnov.txtvivod (per, asd, text, figuri);
                }
                else if (asd.EndsWith(".xml"))
                {
                    ocnov.xmlvivod(asd, text, per);

                }
                else if (asd.EndsWith(".json"))
                {
                    ocnov.jsonvivod(asd, text, per);

                }
                Console.WriteLine("Сохраните файл в один из 3 форматов (txt,xml,json)-F1 и путь до файла, для выхода - Escape");
                Console.WriteLine("--------------------------------------------------------------------------------------------");
                der = Console.ReadKey();
                if (der.Key== ConsoleKey.F1)
                {
                    Console.WriteLine("");
                    asd = Console.ReadLine();
                    if (asd.EndsWith(".txt"))
                    {
                        ocnov.txtvvod(per, text, asd);
                    }
                    else if (asd.EndsWith(".xml"))
                    {
                        ocnov.xmlvvod(asd, text, per);
                    }
                    else if (asd.EndsWith(".json"))
                    {
                        ocnov.jsonvvod(asd, text, figuri, per);
                    }
                    Console.Clear();
                }
                else if (der.Key != ConsoleKey.Escape && der.Key != ConsoleKey.F1)
                {
                    Console.Clear();
                    Console.WriteLine("Попробуйте еще раз");
                }
                

            } while (der.Key != ConsoleKey.Escape);
        }
    }
}