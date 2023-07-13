using UnityEngine;
using System.Linq;
using System.Collections.Generic;

namespace UnityEditor.TreeViewExamples
{
    public class Section
    {
        static public Section Single;
        private Section_MyTree[] �������;
        static public int tabs = 3;
        private EditorGUILayoutTest edit;
        private Section_HTML Html;
        public Section(EditorGUILayoutTest edit)
        {
            this.edit = edit;
            ������� = new Section_MyTree[6] {
                new Section_Project(edit,(byte)stModule.path.Class.�������.PROG,stModule.path.Class.����������),
                new Section_MyTree(edit,(byte)stModule.path.Class.�������.GO,stModule.path.Class.����������������),
                new Section_MyTree(edit,(byte)stModule.path.Class.�������.CLASS,stModule.path.Class.�����������),
                new Section_MyTree(edit,(byte)stModule.path.Class.�������.STRUCT,stModule.path.Class.������������),
                new Section_MyTree(edit,(byte)stModule.path.Class.�������.FUNS,stModule.path.Class.�������������),
                new Section_MyTree(edit,(byte)stModule.path.Class.�������.SHADER,stModule.path.Class.��������������)
            };
            Html = new Section_HTML(edit, (byte)stModule.path.Class.�������.HTML, "https://evgbobrecov.blogspot.com/");
            Single = this;
        }
        public void ��������()
        {

            GUILayout.BeginArea(new Rect(0, 20, edit.dw, 20));
            tabs = GUILayout.Toolbar(tabs, (from x in ������� select System.Enum.GetName(typeof(stModule.path.Class.�������), x.�����)).ToArray<string>());
            GUILayout.EndArea();
            �������[tabs].fun_project(tabs);
        }
        public void �����(string f)
        {
            var cnt = 0;
            foreach (var MyTree in �������)
            {
                if (MyTree.m_TreeView == null) MyTree.InitIfNeeded();

                if (MyTree.m_TreeView.treeModel.Find(
                    (element) =>
                    {
                        var i = element.����������(f);
                        var b = i != -1;
                        if (b)
                        {
                            tabs = cnt;
                            Relation_myTree.�������.tabs = tabs;
                            Relation_myTree.�������.element = element.id;
                            Relation_myTree.�������.f = i;

                            MyTree.m_TreeView.CollapseAll();
                            var parent = element.parent;
                            while (parent != null)
                            {
                                MyTree.m_TreeView.SetExpanded(parent.id, true);
                                parent = parent.parent;
                            }
                                //MyTree.m_TreeView.SetSelection(element.id);
                                
                            MyTree.m_TreeView.Repaint();
                            MyTree.m_TreeView.SetFocus();
                        }
                        return b;
                    })) break;
                cnt++;
            }

        }
    }
}