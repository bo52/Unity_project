using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityEditor.TreeViewExamples
{
    public class TreeElementProp : TreeElement
    {
        public string path;
        public bool enabled;
        public string description;
        public string text = "";
        public bool NoProject;
        public TreeElementProp(string path,bool NoProject,string name, string description, int depth, int id) : base(name, depth,id)
        {
            this.path = path;
            this.NoProject = NoProject;
            this.description = description;
            enabled = true;
        }
    }
}