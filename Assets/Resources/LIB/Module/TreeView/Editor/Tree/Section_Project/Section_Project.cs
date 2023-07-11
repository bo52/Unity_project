using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityEditor.TreeViewExamples
{
    internal class Section_Project : Section_MyTree
    {
        public Section_Project(EditorGUILayoutTest edit,byte �����,string PATH) :base(edit, �����, PATH)
        {
        }
        public override void fun_project(int key, System.Action Castom_Bar=null)
        {
            base.fun_project(key);
            if (key == 0) BottomToolBar(bottomToolbarRect);
        }
        public void BottomToolBar(Rect rect)
        {
            GUILayout.BeginArea(rect);
            using (new EditorGUILayout.VerticalScope())
            {
                var style = "miniButton";
                using (new EditorGUILayout.HorizontalScope())
                {
                    GUILayout.Label("number=" + IEditorGUILayoutPopup.��������� + ", �������� " + EditorGUILayoutTest.�����������������);
                }
                using (new EditorGUILayout.HorizontalScope())
                {
                    if (GUILayout.Button("�������", style))
                    {
                        edit.��������();
                        //����� �� ���� ������
                        stModule.path.Class.��������(IEditorGUILayoutPopup.���������);
                        //����������
                        stModule.Class.���������(IEditorGUILayoutPopup.���������, IEditorGUILayoutPopup.info);
                        stModule.file.Class.�����������(stModule.path.Class.���������������);
                    }
                    if (GUILayout.Button("Update", style))
                    {
                        EditorGUILayoutTest.����������������� = stModule.world.Class.����;
                        EditorGUILayoutTest.�����������������.GetType().GetMethod("�����������").Invoke(EditorGUILayoutTest.�����������������, new object[] { IEditorGUILayoutPopup.��������� });
                        Debug.Log("������� ������ ���������!!!");
                    }
                    if (GUILayout.Button("Free", style))
                    {
                        edit.��������();
                        stModule.file.Class.��������();
                        stModule.file.Class.�����������(stModule.path.Class.���������������);
                    }
                }
                using (new EditorGUILayout.HorizontalScope())
                {
                    GUILayout.Label(IEditorGUILayoutPopup.info);
                }
            }
            GUILayout.EndArea();
        }
        Rect bottomToolbarRect
        {
            get { return new Rect(20f, edit.position.height - 100f, edit.position.width - edit.dw, 150f); }
        }
    }
}