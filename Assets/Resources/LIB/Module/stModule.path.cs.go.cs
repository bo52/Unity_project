using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace stModule.path.cs_go {
    public class Class
    {
        public static void ��������������(ref List<path.Class.Body> bs, uint M, string f)
        {
            if (!File.Exists(f)) return;
            var ls = new List<string>();
            var ns = new Dictionary<ulong, link.Class.������>();

            var sr = new StreamReader(f);
            var line = sr.ReadLine();
            while (line != null)
            {
                if (path.Class.��������������������������(line))
                {
                    ls.Add(uses.Class.������������������������(ns,line, M));
                }
                line = sr.ReadLine();
            }
            sr.Close();
            bs.Add(new path.Class.Body(ls, ns.Values.ToArray()));
        }
    }
}
