using System.Text.RegularExpressions;
using UnityEngine;

namespace stModule.link { 
    static public class Class
    {
        public struct ������
        {
            public string full;
            public ������(Match m)
            {
                full = m.ToString();
            }
            public string t
            {
                get
                {
                    if (full.IndexOf("st") == 0 || ���������� != "") return "st";
                    if (full.IndexOf("cs") == 0) return "cs";
                    if (full.IndexOf("go") == 0) return "go";
                    return "";
                }
            }
            public string ����������
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
                        if (���������� != "") m_i = m_i.Substring(0, m_i.Length - 2);
                    }

                    m_i = join.Class.�����������(m_i);
                    //Debug.Log(full+"="+m_i);
                    return System.Convert.ToUInt32(m_i);
                }
            }
            public ulong �����
            {
                get
                {
                    var i = �������������;
                    if (i == -1) return M;
                    return System.Convert.ToUInt64(M.ToString() + join.Class.��������(i)+ i.ToString());
                }
            }
            public string ������������ => full.Substring(full.Length - 2);
            public int ������������� => ���������� == ""?-1:System.Convert.ToInt32(������������);
        }
    }
}
