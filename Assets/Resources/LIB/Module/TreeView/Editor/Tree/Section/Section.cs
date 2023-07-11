using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace UnityEditor.TreeViewExamples
{
    public class Section
    {
        private Section_MyTree[] �������;
        private int tabs = 3;
        private EditorGUILayoutTest edit;
        public Section(EditorGUILayoutTest edit)
        {
            this.edit = edit;
            ������� = new Section_MyTree[6] {
                new Section_Project(edit,(byte)stModule.path.Class.�������.PROG,stModule.path.Class.����������),
                new Section_MyTree(edit,(byte)stModule.path.Class.�������.GO,stModule.path.Class.����������������),
                new Section_MyTree(edit,(byte)stModule.path.Class.�������.CLASS,stModule.path.Class.�����������),
                new Section_MyTree(edit,(byte)stModule.path.Class.�������.STRUCT,stModule.path.Class.������������),
                new Section_MyTree(edit,(byte)stModule.path.Class.�������.FUNS,stModule.path.Class.�������������),
                new Section_MyTree(edit,(byte)stModule.path.Class.�������.SHADER,stModule.path.Class.��������������),
            };
        }
        public void ��������()
        {

            GUILayout.BeginArea(new Rect(0, 20, edit.dw, 20));
            tabs = GUILayout.Toolbar(tabs, (from x in ������� select System.Enum.GetName(typeof(stModule.path.Class.�������), x.�����)).ToArray<string>());
            GUILayout.EndArea();
            �������[tabs].fun_project(tabs);
        }
    }
}