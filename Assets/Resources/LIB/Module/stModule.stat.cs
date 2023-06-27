using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace stModule.stat { 
static public class Class
{
        static public bool НачалоКласса(string line) => line.LastIndexOf("static public class Class") !=-1;
        static public bool НачалоТела(string line) => line.LastIndexOf("<summary>") !=-1;

        static private List<path.Class.Body> bs = new List<path.Class.Body>();
        static private List<string>  lines = new List<string>();
        static private Dictionary<ulong, link.Class.Ссылка> numbers = new Dictionary<ulong, link.Class.Ссылка>();
        static public void Закрытие(int i,int ID)
        {
            if (i > -1) bs.Add(new path.Class.Body(lines, numbers.Values.ToArray(),ID));
            lines.Clear();
            numbers.Clear();
        }
        static public string ОпределитьШапку(ref int ID,string line)
        {
            string pat = @"field\d{12}|prop\d{12}|fun\d{12}";
            var m = new Regex(pat, RegexOptions.IgnoreCase).Match(line);
            var h = m.Success ? m.ToString() : "";
            ID = h == "" ? -1 : System.Convert.ToInt32(h.Substring(h.Length - 2, 2));
            return h;
        }
        static public int ОпределитьИдОбъектВШапке(string Шапка) => System.Convert.ToInt32(Шапка.Substring(Шапка.Length - 2, 2));
        static public path.Class.Body[] РаботаСФайлом(uint M,string f)
        {
            var sr = new StreamReader(f);
            var i = -1;
            var ПослеНачалаКласса = false;

            var line = sr.ReadLine();
            var комментарий = false;

            var Шапка = "";
            var ID = -1;
            while (line != null)
            {
                if (line.IndexOf("///exit") != -1) break;
                if (!ПослеНачалаКласса)
                {
                    ПослеНачалаКласса = НачалоКласса(line);
                }
                else
                {
                    if (комментарий && line.IndexOf("///") == -1)
                    {
                        Шапка = ОпределитьШапку(ref ID, line);
                        if (Шапка == "field230625213403")
                        {
                            var text = "";
                        }
                        uses.Class.ОбработкаСтрокиДляМодуля(numbers, line, M, bs.Count, Шапка);
                        комментарий = false;
                    }
                    if (НачалоТела(line))
                    {
                        Закрытие(i, ID);
                        комментарий = true;
                        //новое начало
                        i += 1;
                    }
                    //добавить в последнее
                    if (i > -1)
                    {
                        lines.Add(uses.Class.ОбработкаСтрокиДляМодуля(numbers, line, M, bs.Count, Шапка));
                    }
                }
                line = sr.ReadLine();
            }
            Закрытие(i,ID);
            sr.Close();
            var arr=bs.ToArray();
            bs.Clear();
            return arr;
        }
}
}
