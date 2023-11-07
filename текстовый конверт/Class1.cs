using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace текстовый_конверт
{
    public class ocnov
    {
        public string figura;
        public string pervoe;
        public string vtoroe;
        public string tretie;

    private static string[] massiv (string []per, List<ocnov> text)
        {
            foreach (var item in text)
            {
                per[0] = item.figura;
                per[1] = item.pervoe;
                per[2] = item.vtoroe;
                per[3] = item.tretie;
            }
            return per;
        }
        private static List<ocnov> vivod(List<ocnov> text)
        {
            foreach (var item in text)
            {
                Console.WriteLine(item.figura);
                Console.WriteLine(item.pervoe);
                Console.WriteLine(item.vtoroe);
                Console.WriteLine(item.tretie);
            }
            return text;
        }
        public static List<ocnov> txtvivod(string [] per, string asd, List<ocnov>text, ocnov figuri)
        {
            per = File.ReadAllLines(asd);
            foreach (var line in text)
            {
                Console.WriteLine(line);
            }
            for (int i = 0; i < 4; i++)
            {
                figuri.figura = per[0];
                figuri.pervoe = per[1];
                figuri.vtoroe = per[2];
                figuri.tretie = per[3];
            }
            text.Add(figuri);
            vivod(text);
            return text;
        }
        public static List<ocnov> xmlvivod( string asd, List<ocnov> text, string[] per)
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<ocnov>));
            using (FileStream xm = new FileStream(asd, FileMode.Open))
            {
                text = (List<ocnov>)xml.Deserialize(xm);
            }
            massiv(per, text);
            vivod(text);
            return text;
        }
        public static List<ocnov> jsonvivod(string asd, List<ocnov> text, string[]per)
        {
            string ret = File.ReadAllText(asd);
            text = JsonConvert.DeserializeObject<List<ocnov>>(ret);
            massiv(per, text);
            vivod(text);
            return text;
        }
        public static List<ocnov> txtvvod(string[] per, List<ocnov> text, string asd)
        {
            massiv(per,text);
            File.WriteAllLines(asd, per);
            return text;
        }
        public static List<ocnov> xmlvvod(string asd, List<ocnov> text, string[]per)
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<ocnov>));
            using (FileStream xm = new FileStream(asd, FileMode.OpenOrCreate))
            {
                xml.Serialize(xm, text);
            }
            massiv(per, text);
            return text;
        }
        public static List<ocnov> jsonvvod(string asd, List<ocnov> text,ocnov figuri, string[]per)
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<ocnov>));
            using (FileStream xm = new FileStream(asd, FileMode.OpenOrCreate))
            {
                xml.Serialize(xm, text);
            }
            for (int i = 0; i < 4; i++)
            {
                figuri.figura = per[0];
                figuri.pervoe = per[1];
                figuri.vtoroe = per[2];
                figuri.tretie = per[3];
            }
            return text;
        }

       
    }
    
}
