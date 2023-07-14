using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System;

namespace UnityEditor.TreeViewExamples
{
    [Serializable]
    internal class Section_HTML_TreeElement : TreeElementProp
    {
        public Section_HTML_TreeElement() : base("empty", false, "empty", "empty", 0, -1)
        {
        }

        public Section_HTML_TreeElement(string path, string name, string description, int depth, int id) : base(path, false, name, description, depth, id)
        {
        }
    }
}