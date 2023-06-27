using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using System.Text.RegularExpressions;
namespace stModule.join
{
    static public class Class
    {
        static public void ������������������(this StreamWriter sw, string dir)
        {
            foreach (string f in Directory.GetFiles(dir)) sw.����������������������(f);
            foreach (string d in Directory.GetDirectories(dir)) sw.������������������(d);
        }
        static public void ����������������������(this StreamWriter sw, string file)
        {
            //�� ����������?
            if (!File.Exists(file)) return;
            if (���������������(file) != "cs") return;
            var sr = new StreamReader(file);
            var line = sr.ReadLine();
            while (line != null)
            {
                if (line.IndexOf("using ") == -1)
                    sw.WriteLine(line);
                line = sr.ReadLine();
            }
            sr.Close();
        }
        static public List<ulong> �������� = new List<ulong>();
        static public string �����������(this string s) => Regex.Replace(s, "[^0-9]", "");
        static public bool ����������(this string s) => �����������(s.Substring(s.LastIndexOf('.') + 1)) =="";
        static public string �����������(this string s) => Regex.Replace(s, "[0-9]", "");
        static public string ���������������(this string s) => s.Substring(s.LastIndexOf(".")+1);
        static public string ��������(int i) => i < 10 ? "0" : "";
        static public void ��������������(StreamWriter sw,path.Class.Body b)
        {
            foreach (var line in b.lines) sw.WriteLine(line);
            �������������������(sw, b);
        }
        static public void �������������������(StreamWriter sw, path.Class.Body b)
        {
            foreach (var num in b.numbers)
            {
                �����������������(sw, num.M, num.�������������);
            }
        }
        static public bool ��������(uint M, int i = -1)
        {
            var m_i = System.Convert.ToUInt64(M.ToString() + (i == -1 ? "" : (��������(i)+i.ToString())));
            if (i == -1)
            {
                if (��������.IndexOf(m_i) != -1) return false;
                ��������.Add(m_i);
                return true;
            }
            if (����������������.IndexOf(m_i) != -1) return false;
            ����������������.Add(m_i);
            return true;
        }
        static public path.Class.Body ���������������������������������(uint m, int ID)
        {
            var arr = (from f in path.Class.����������[m].fs where f.i == ID select f).ToArray();
            if (arr.Length == 0) Debug.Log(m+"."+ID);
            return arr[0];
        }

        static public void �����������������(StreamWriter sw, uint M, int i=-1)
        {
            if (!��������(M, i)) return;
            if (path.Class.����������.ContainsKey(M) == false) return;
            //�� ����������� ������
            if (i == -1) foreach (var b in path.Class.����������[M].fs) ��������������(sw, b);
            //����������� ������
            else �������������������(sw, ���������������������������������(M,i));
        }
        static public List<ulong> ���������������� = new List<ulong>();
        static public void ������������������(StreamWriter sw)
        {
            sw.WriteLine("namespace LIB.st");
            sw.WriteLine("{");
            sw.WriteLine("static public class Class");
            sw.WriteLine("{");
            foreach (var st in ����������������)
            {
                var m_i = st.ToString();
                var m = System.Convert.ToUInt32(m_i.Substring(0, m_i.Length-2));
                var i = System.Convert.ToInt32(m_i.Substring(m_i.Length - 2));
                var body = ���������������������������������(m, i);
                foreach (var line in body.lines)
                    sw.WriteLine(line);
            }
            sw.WriteLine("}");
            sw.WriteLine("}");
        }
        static public void �����������(uint M)
        {
            //File.WriteAllText(@"C:\file.txt", File.ReadAllText(@"C:\file.txt"), System.Text.Encoding.UTF8);
            StreamWriter sw = new StreamWriter(path.Class.���������������);
            file.Class.����������(sw);
            �����������������(sw, M);
            ������������������(sw);
            sw.Close();
        }
    }
}
