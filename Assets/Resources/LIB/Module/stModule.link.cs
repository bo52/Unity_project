using System.Text.RegularExpressions;
using UnityEngine;

namespace stModule.link { 
    static public class Class
    {
        public struct Ссылка
        {
            public string full;
            public Ссылка(Match m)
            {
                full = m.ToString();
            }
            public string t
            {
                get
                {
                    if (full.IndexOf("st") == 0 || ЭтоСтатика != "") return "st";
                    if (full.IndexOf("cs") == 0) return "cs";
                    if (full.IndexOf("go") == 0) return "go";
                    return "";
                }
            }
            public string ЭтоСтатика
            {
                get
                {
                    if (full.IndexOf("field") != -1) return "field";
                    if (full.IndexOf("prop") != -1) return "prop";
                    if (full.IndexOf("fun") != -1) return "fun";
                    return "";
                }
            }
            public uint M
            {
                get
                {
                    var i = full.IndexOf(".");
                    var m_i = full;

                    if (i != -1)
                    {
                        m_i = m_i.Substring(0, i);
                    }
                    else
                    {
                        if (ЭтоСтатика != "") m_i = m_i.Substring(0, m_i.Length - 2);
                    }

                    m_i = join.Class.ТолькоЦифры(m_i);
                    //Debug.Log(full+"="+m_i);
                    return System.Convert.ToUInt32(m_i);
                }
            }
            public ulong Число
            {
                get
                {
                    var i = ИндексСтатики;
                    if (i == -1) return M;
                    return System.Convert.ToUInt64(M.ToString() + join.Class.ЭтоЦифра(i)+ i.ToString());
                }
            }
            public string НомерСтатики => full.Substring(full.Length - 2);
            public int ИндексСтатики => ЭтоСтатика == ""?-1:System.Convert.ToInt32(НомерСтатики);
        }
    }
}
