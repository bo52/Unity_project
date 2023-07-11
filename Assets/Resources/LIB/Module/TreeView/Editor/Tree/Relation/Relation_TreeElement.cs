using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text.RegularExpressions;
using System;

namespace UnityEditor.TreeViewExamples
{
    [Serializable]
    internal class Relation_TreeElement : TreeElementProp
    {
        //name = namefile

        public void ПоискФайлов()
        {

        }
        public Relation_TreeElement() : base("empty", false, "empty", "empty", 0, -1)
        {

        }
        public Relation_TreeElement(string path,bool NoProject, string name, string description, int depth, int id) : base(path,NoProject, name, description, depth, id)
        {
        }
    }
}
