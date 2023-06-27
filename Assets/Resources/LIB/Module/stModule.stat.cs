using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace stModule.stat { 
static public class Class
{
        static public bool ������������(string line) => line.LastIndexOf("static public class Class") !=-1;
        static public bool ����������(string line) => line.LastIndexOf("<summary>") !=-1;

        static private List<path.Class.Body> bs = new List<path.Class.Body>();
        static private List<string>  lines = new List<string>();
        static private Dictionary<ulong, link.Class.������> numbers = new Dictionary<ulong, link.Class.������>();
        static public void ��������(int i,int ID)
        {
            if (i > -1) bs.Add(new path.Class.Body(lines, numbers.Values.ToArray(),ID));
            lines.Clear();
            numbers.Clear();
        }
        static public string ���������������(ref int ID,string line)
        {
            string pat = @"field\d{12}|prop\d{12}|fun\d{12}";
            var m = new Regex(pat, RegexOptions.IgnoreCase).Match(line);
            var h = m.Success ? m.ToString() : "";
            ID = h == "" ? -1 : System.Convert.ToInt32(h.Substring(h.Length - 2, 2));
            return h;
        }
        static public int ������������������������(string �����) => System.Convert.ToInt32(�����.Substring(�����.Length - 2, 2));
        static public path.Class.Body[] �������������(uint M,string f)
        {
            var sr = new StreamReader(f);
            var i = -1;
            var ����������������� = false;

            var line = sr.ReadLine();
            var ����������� = false;

            var ����� = "";
            var ID = -1;
            while (line != null)
            {
                if (line.IndexOf("///exit") != -1) break;
                if (!�����������������)
                {
                    ����������������� = ������������(line);
                }
                else
                {
                    if (����������� && line.IndexOf("///") == -1)
                    {
                        ����� = ���������������(ref ID, line);
                        if (����� == "field230625213403")
                        {
                            var text = "";
                        }
                        uses.Class.������������������������(numbers, line, M, bs.Count, �����);
                        ����������� = false;
                    }
                    if (����������(line))
                    {
                        ��������(i, ID);
                        ����������� = true;
                        //����� ������
                        i += 1;
                    }
                    //�������� � ���������
                    if (i > -1)
                    {
                        lines.Add(uses.Class.������������������������(numbers, line, M, bs.Count, �����));
                    }
                }
                line = sr.ReadLine();
            }
            ��������(i,ID);
            sr.Close();
            var arr=bs.ToArray();
            bs.Clear();
            return arr;
        }
}
}
