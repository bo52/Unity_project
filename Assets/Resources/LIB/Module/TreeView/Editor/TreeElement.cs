using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;


namespace UnityEditor.TreeViewExamples
{

    [Serializable]
    public class TreeElement
    {
        [SerializeField] int m_ID;
        [SerializeField] string m_Name;
        [SerializeField] int m_Depth;
        [NonSerialized] TreeElement m_Parent;
        [NonSerialized] List<TreeElement> m_Children;

        public int depth
        {
            get { return m_Depth; }
            set { m_Depth = value; }
        }

        public TreeElement parent
        {
            get { return m_Parent; }
            set { m_Parent = value; }
        }

        public List<TreeElement> children
        {
            get { return m_Children; }
            set { m_Children = value; }
        }

        public bool hasChildren
        {
            get { return children != null && children.Count > 0; }
        }

        public string name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        public int id
        {
            get { return m_ID; }
            set { m_ID = value; }
        }

        public TreeElement()
        {
        }

        public TreeElement(string name, int depth, int id)
        {
            m_Name = name;
            m_ID = id;
            m_Depth = depth;
        }
    }
    [Serializable]
    internal class MyTreeElement : TreeElement
    {
        public string description;
        public string path;
        public bool NoProject;
        public string text = "";
        public bool enabled;
        public List<string> Файлы=new List<string>();
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
        private static FileAttributes RemoveAttribute(FileAttributes attributes, FileAttributes attributesToRemove)
        {
            return attributes & ~attributesToRemove;
        }
        public void ОбработкаФайла(string f)
        {
            FileAttributes attributes = File.GetAttributes(f);

            if ((attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
            {
                // Show the file.
                attributes = RemoveAttribute(attributes, FileAttributes.Hidden);
                File.SetAttributes(f, attributes);
            }
        }
        public void ПолучитьФайлы()
        {
            Файлы.Clear();
            if (Directory.Exists(this.path) == false) return;
            foreach (string f in Directory.GetFiles(this.path, "*.cs"))
                Файлы.Add(f);
            foreach (string f in Directory.GetFiles(this.path, "*.shader"))
                Файлы.Add(f);
        }
        public MyTreeElement(bool NoProject, string name, string description, string path, int depth, int id) : base(name, depth, id)
        {
            this.NoProject = NoProject;
            this.path = path+"/";
            Информация();
            ПолучитьФайлы();
            this.description = description;
            enabled = true;
        }
    }
    [CreateAssetMenu(fileName = "TreeDataAsset", menuName = "Tree Asset", order = 1)]
    public class MyTreeAsset : ScriptableObject
    {
        [SerializeField] List<MyTreeElement> m_TreeElements = new List<MyTreeElement>();

        internal List<MyTreeElement> treeElements
        {
            get { return m_TreeElements; }
            set { m_TreeElements = value; }
        }
    }

}


