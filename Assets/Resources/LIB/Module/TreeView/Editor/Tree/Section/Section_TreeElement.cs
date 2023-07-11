using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text.RegularExpressions;
using System;
namespace UnityEditor.TreeViewExamples
{
    [Serializable]
    internal class Section_TreeElement : TreeElementProp
    {
        public List<string> Файлы = new List<string>();
        public uint НомерМира => System.Convert.ToUInt32(Regex.Replace(path.Substring(path.LastIndexOf('.') + 1), "[^0-9]", ""));

        public void Информация()
        {
            text = "";
            if (Directory.Exists(this.path) == false) return;
            var f = this.path + "/info.txt";
            if (File.Exists(f) == false) return;

            var sr = new StreamReader(this.path + "/info.txt");

            var line = sr.ReadLine();
            while (line != null)
            {
                text = line + "\n" + text;
                line = sr.ReadLine();
            }
            sr.Close();
        }
        public void ПолучитьФайлы()
        {
            Файлы.Clear();
            if (Directory.Exists(this.path) == false) return;
            foreach (string f in Directory.GetFiles(this.path, "*.cs"))
            {
                Файлы.Add(f);
            }
            foreach (string f in Directory.GetFiles(this.path, "*.shader"))
                Файлы.Add(f);
        }
        public Section_TreeElement():base("empty", false, "empty", "empty", 0, -1) 
        { 
        }

        public Section_TreeElement(string path,bool NoProject, string name, string description, int depth, int id) : base(path,NoProject, name, description, depth,  id)
        {
            this.path = path + "/";
            Информация();
            ПолучитьФайлы();
        }
    }
}