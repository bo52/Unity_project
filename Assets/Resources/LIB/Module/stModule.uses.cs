using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace stModule.uses
{ 
    /// <summary>
    /// 
    /// </summary>
    public class Class
    {
        static public Match ��������������(string line)
        {
            //����� fun,field,prop
            string pat = @"go\d{10}|cs\d{10}|field\d{12}|prop\d{12}|fun\d{12}";
            return new Regex(pat, RegexOptions.IgnoreCase).Match(line);
        }
        struct �������
        {
            string count;
            string num;
            string M;
            string name;
            public string full;
            public �������(string M, string ���������, int i)
            {
                this.M = M;
                count = (i < 10 ? "0" : "") + i.ToString();
                full = ���������.ToString();
                num = join.Class.�����������(full);
                name = join.Class.�����������(full);
            }
            public bool ��������=>num == M + count;
        }
        static public void �����������������(Match ���������, string M, int i, System.Action<link.Class.������> proc,string �����)
        {
            var x=new �������(M, ���������.ToString(), i);
            if (i != -1 && �����== x.full) return;
            proc(new link.Class.������(���������));
        }
        static public void �����������������������(string line, string M, System.Action<link.Class.������> proc, int i, string �����)
        {
            Match m = ��������������(line);
            while (m.Success)
            {
                �����������������(m, M, i, proc, �����);
                m = m.NextMatch();
            }
        }
        public static string ������������������������(Dictionary<ulong, link.Class.������> ns, string line, uint M,int i=-1, string ����� ="")
        {
            var ������ = line;
            �����������������������(line, M.ToString(), (link) => {
                var m = link.M;
                if (link.t == "st")
                {
                    var t_obj = link.����������;
                    var m_i = link.�����;
                    ������ = Regex.Replace(������, "st" + link.M + ".Class." + t_obj + m_i, "st.Class." + t_obj + m_i);
                }

                if (ns.ContainsKey(link.�����)) return;
                ns.Add(link.�����, link);
            },i, �����);
            return ������;
        }
    }
}