using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace stModule.uses
{ 
    /// <summary>
    /// 
    /// </summary>
    public class Class
    {
        static public Match НайтиРегулярно(string line)
        {
            //поиск fun,field,prop
            string pat = @"go\d{10}|cs\d{10}|field\d{12}|prop\d{12}|fun\d{12}";
            return new Regex(pat, RegexOptions.IgnoreCase).Match(line);
        }
        struct Статика
        {
            string count;
            string num;
            string M;
            string name;
            public string full;
            public Статика(string M, string Найденный, int i)
            {
                this.M = M;
                count = (i < 10 ? "0" : "") + i.ToString();
                full = Найденный.ToString();
                num = join.Class.ТолькоЦифры(full);
                name = join.Class.ТолькоТекст(full);
            }
            public bool ЭтоШапка=>num == M + count;
        }
        static public void ЗависимостьИлиНет(Match Найденный, string M, int i, System.Action<link.Class.Ссылка> proc,string Шапка)
        {
            var x=new Статика(M, Найденный.ToString(), i);
            if (i != -1 && Шапка== x.full) return;
            proc(new link.Class.Ссылка(Найденный));
        }
        static public void НайтиЗависимостиВСтроке(string line, string M, System.Action<link.Class.Ссылка> proc, int i, string Шапка)
        {
            Match m = НайтиРегулярно(line);
            while (m.Success)
            {
                ЗависимостьИлиНет(m, M, i, proc, Шапка);
                m = m.NextMatch();
            }
        }
        public static string ОбработкаСтрокиДляМодуля(Dictionary<ulong, link.Class.Ссылка> ns, string line, uint M,int i=-1, string Шапка ="")
        {
            var Строка = line;
            НайтиЗависимостиВСтроке(line, M.ToString(), (link) => {
                var m = link.M;
                if (link.t == "st")
                {
                    var t_obj = link.ЭтоСтатика;
                    var m_i = link.Число;
                    Строка = Regex.Replace(Строка, "st" + link.M + ".Class." + t_obj + m_i, "st.Class." + t_obj + m_i);
                }

                if (ns.ContainsKey(link.Число)) return;
                ns.Add(link.Число, link);
            },i, Шапка);
            return Строка;
        }
    }
}