using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace UnityEditor.TreeViewExamples
{
    public class Section
    {
        private Section_MyTree[] Разделы;
        private int tabs = 3;
        private EditorGUILayoutTest edit;
        public Section(EditorGUILayoutTest edit)
        {
            this.edit = edit;
            Разделы = new Section_MyTree[6] {
                new Section_Project(edit,(byte)stModule.path.Class.Разделы.PROG,stModule.path.Class.КореньМира),
                new Section_MyTree(edit,(byte)stModule.path.Class.Разделы.GO,stModule.path.Class.КореньОбъектМира),
                new Section_MyTree(edit,(byte)stModule.path.Class.Разделы.CLASS,stModule.path.Class.КореньКласс),
                new Section_MyTree(edit,(byte)stModule.path.Class.Разделы.STRUCT,stModule.path.Class.КореньСтрукт),
                new Section_MyTree(edit,(byte)stModule.path.Class.Разделы.FUNS,stModule.path.Class.КореньФунМира),
                new Section_MyTree(edit,(byte)stModule.path.Class.Разделы.SHADER,stModule.path.Class.КореньШейдеров),
            };
        }
        public void Показать()
        {

            GUILayout.BeginArea(new Rect(0, 20, edit.dw, 20));
            tabs = GUILayout.Toolbar(tabs, (from x in Разделы select System.Enum.GetName(typeof(stModule.path.Class.Разделы), x.Номер)).ToArray<string>());
            GUILayout.EndArea();
            Разделы[tabs].fun_project(tabs);
        }
    }
}