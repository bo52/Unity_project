using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityEditor.TreeViewExamples
{
    public class Relation
    {
        static public Relation Single;
        public void Обновить(string PATH){
            tabs = 0;
            myRelation.fun_f(PATH);
        }
        private EditorGUILayoutTest edit;
        private int tabs = 0;
        private Relation_myTree myRelation;
        private Section_HTML Html;
        public Relation(EditorGUILayoutTest edit)
        {
            this.edit = edit;
            myRelation = new Relation_myTree(edit);
            Html = new Section_HTML(edit,"");
            Single = this;
        }
        public void Показать()
        {
            GUILayout.BeginArea(new Rect(edit.dw + 10, 20, edit.dw - 10, 20));
            tabs = GUILayout.Toolbar(tabs, new string[] { "Зависимости","HTML" });
            GUILayout.EndArea();
            switch (tabs)
            {
                case 0:
                    myRelation.fun_project(tabs);
                    break;
                case 1:
                    Html.fun_project(tabs);
                    break;
            }
        }
    }
}