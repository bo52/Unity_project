using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor.IMGUI.Controls;

namespace UnityEditor.TreeViewExamples
{
    internal class Relation_myTree : MyTree<Relation_TreeElement, Relation_CustomHeight>
    {
        public string NameFile = "empty";
        public Relation_myTree(EditorGUILayoutTest edit) : base(edit, "empty")
        {
        }
        public override void InitIfNeeded()
        {
            n=
            base.InitIfNeeded();
        }
        public override void Bar(System.Action CastomBar)
        {
        }
        public override void fun_project(int key, System.Action Castom_Bar = null)
        {
            base.fun_project(key);
        }
        public override void AddChildrenRecursive(string path, TreeElement element, List<Relation_TreeElement> treeElements)
        {
        }
    }
}
