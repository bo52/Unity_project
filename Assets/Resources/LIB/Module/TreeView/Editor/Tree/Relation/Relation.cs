using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityEditor.TreeViewExamples
{
    public class Relation
    {
        private Relation_myTree[] Разделы;
        private EditorGUILayoutTest edit;
        private int tabs = 0;
        public Relation(EditorGUILayoutTest edit)
        {
            this.edit = edit;
            Разделы = new Relation_myTree[2] {
                new Relation_myTree(edit),
                new Relation_myTree(edit),
            };
        }
        public void Показать()
        {
            GUILayout.BeginArea(new Rect(edit.dw + 10, 20, edit.dw - 10, 20));
            tabs = GUILayout.Toolbar(tabs, new string[] { "Зависимости","HTML" });
            GUILayout.EndArea();
            Разделы[tabs].fun_project(tabs);
        }
    }
}