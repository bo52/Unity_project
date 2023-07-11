using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;
namespace stModule.path
{
    public class Class
    {
        public enum ������� {
            PROG,
            GO,
            FUNS,
            CLASS,
            STRUCT,
            SHADER,
        };
        public static string ������������� => ������������� + "temp/";
        public static string ������������������ => ������������� + "backup/";
        public static string ������������� => Application.dataPath + "/../../Unity_LIB/Assets/";
        public static string ������������� => ������������� + "SYS/";
        public static string ������������(string ������) => ������������� + ������ + "/EMPTY/";
        public static string �������������� => Application.dataPath + "/Resources/";
        public static string �������������� => �������������� + "LIB/";
        public static string ��������������� => �������������� + "Mono.cs";
        #region ������
        public static bool �������(bool noproject,string path, Rect rect) => file.Class.�������(����������������(path), path, rect, noproject);
        public static string ���������� => ������������� + "PROJECT/";
        public static string ���������������� => ������������� + "GO/";
        public static string ����������� => ������������� + "CLASS/";
        public static string ������������ => ������������� + "STRUCT/";
        public static string ������������� => ������������� + "FUNS/";
        public static string �������������� => �������������� + "SHADERS/";
        public static byte ����������������(string path)
        {
            if (path.IndexOf(����������) != -1) return (byte)�������.PROG;
            if (path.IndexOf(����������������) != -1) return (byte)�������.GO;
            if (path.IndexOf(�������������) != -1) return (byte)�������.FUNS;
            if (path.IndexOf(�����������) != -1) return (byte)�������.CLASS;
            if (path.IndexOf(������������) != -1) return (byte)�������.STRUCT;
            if (path.IndexOf(��������������) != -1) return (byte)�������.SHADER;
            return byte.MaxValue;
        }
        public static string �����������������������(byte x)
        {
            switch ((�������)x)
            {
                case �������.PROG:return ����������;
                case �������.GO: return ����������������;
                case �������.FUNS: return �������������;
                case �������.CLASS: return �����������;
                case �������.STRUCT: return ������������;
                case �������.SHADER: return ��������������;
            }
            return null;
        }
        #endregion
        public static bool ��������������������������(string line) => line.IndexOf("using ") == -1;

        public struct ����������
        {
            public string t;
            public Body[] fs;
            public ����������(string t, List<Body> fs)
            {
                this.t = t;
                this.fs = fs.ToArray();
            }
            public ����������(string t, Body[] fs)
            {
                this.t = t;
                this.fs = fs;
            }
        }
        public struct Body
        {
            public int i;
            public string[] lines;
            public link.Class.������[] numbers;
            public Body(List<string> lines, List<link.Class.������> numbers, int i = -1)
            {
                this.i = i;
                this.lines = lines.ToArray();
                this.numbers = numbers.ToArray();
            }
            public Body(List<string> lines, link.Class.������[] numbers, int i = -1)
            {
                this.i = i;
                this.lines = lines.ToArray();
                this.numbers = numbers;
            }
        }
        static public Dictionary<uint, ����������> ���������� = new Dictionary<uint, ����������>();
        public static Body[] ���������������_go(uint M, string f)
        {
            var path = Path.GetDirectoryName(f);
            var bs = new List<Body>();
            cs_go.Class.��������������(ref bs, M, path + "/Event" + M + ".cs");
            cs_go.Class.��������������(ref bs, M, path + "/Inspector" + M + ".cs");
            cs_go.Class.��������������(ref bs, M, path + "/Scene" + M + ".cs");
            return bs.ToArray();
        }
        public static Body[] ���������������_cs(uint M, string f)
        {
            var bs = new List<Body>();
            cs_go.Class.��������������(ref bs, M, f);
            return bs.ToArray();
        }
        public static Body[] ���������������_st(uint M, string f) => stat.Class.�������������(M, f);
        public static void �����������������(string D)
        {
            foreach (string f in Directory.GetFiles(D))
            {
                if (join.Class.���������������(f) != "cs") continue;

                #region �������� M
                var m = Path.GetFileName(f);
                m = m.Substring(0, m.LastIndexOf("."));
                m = m.Substring(m.LastIndexOf(".") + 1);
                m = Regex.Replace(Path.GetFileName(m), "[^0-9]", "");
                if (m == "") continue;
                var M = System.Convert.ToUInt32(m); 
                #endregion

                if (����������.ContainsKey(M)) continue;

                string t = Path.GetFileName(f).Substring(0, 3);
                System.Func<uint, string, Body[]> act;
                switch (t)
                {
                    case "st.":
                        t = "st";
                        act = ���������������_st;
                        break;
                    case "cs.":
                        act = ���������������_cs;
                        t = "cs";
                        break;
                    default:
                        act = ���������������_go;
                        t = "go";
                        break;
                }

                ����������.Add(M, new ����������(t, act(M, f)));
            }
            foreach (string d in Directory.GetDirectories(D))
                �����������������(d);
        }
        public static void �����������������()
        {
            ����������.Clear();
            �����������������(�������������);
            �����������������(����������);
            �����������������(����������������);
            �����������������(�����������);
            �����������������(������������);
            �����������������(�������������);
        }
        public static void ��������(uint M)
        {
            �����������������();
            join.Class.�����������(M);
        }
    }
}
