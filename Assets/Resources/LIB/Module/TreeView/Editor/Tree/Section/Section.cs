using UnityEngine;
using System.Linq;
using System.Collections.Generic;

namespace UnityEditor.TreeViewExamples
{
    public class Section
    {
        static public Section Single;
        private Section_MyTree[] Разделы;
        static public int tabs = 3;
        private EditorGUILayoutTest edit;
        private Section_HTML Html;
        public Section(EditorGUILayoutTest edit)
        {
            this.edit = edit;
            Разделы = new Section_MyTree[6] {
                new Section_Project(edit,(byte)stModule.path.Class.Разделы.PROG,stModule.path.Class.КореньМира),
                new Section_MyTree(edit,(byte)stModule.path.Class.Разделы.GO,stModule.path.Class.КореньОбъектМира),
                new Section_MyTree(edit,(byte)stModule.path.Class.Разделы.CLASS,stModule.path.Class.КореньКласс),
                new Section_MyTree(edit,(byte)stModule.path.Class.Разделы.STRUCT,stModule.path.Class.КореньСтрукт),
                new Section_MyTree(edit,(byte)stModule.path.Class.Разделы.FUNS,stModule.path.Class.КореньФунМира),
                new Section_MyTree(edit,(byte)stModule.path.Class.Разделы.SHADER,stModule.path.Class.КореньШейдеров)
            };
            Html = new Section_HTML(edit, (byte)stModule.path.Class.Разделы.HTML, "https://evgbobrecov.blogspot.com/");
            Single = this;
        }
        public void Показать()
        {

            GUILayout.BeginArea(new Rect(0, 20, edit.dw, 20));
            tabs = GUILayout.Toolbar(tabs, (from x in Разделы select System.Enum.GetName(typeof(stModule.path.Class.Разделы), x.Номер)).ToArray<string>());
            GUILayout.EndArea();
            Разделы[tabs].fun_project(tabs);
        }
        public void Поиск(string f)
        {
            var cnt = 0;
            foreach (var MyTree in Разделы)
            {
                if (MyTree.m_TreeView == null) MyTree.InitIfNeeded();

                if (MyTree.m_TreeView.treeModel.Find(
                    (element) =>
                    {
                        var i = element.ПоискФайла(f);
                        var b = i != -1;
                        if (b)
                        {
                            tabs = cnt;
                            Relation_myTree.Отмечен.tabs = tabs;
                            Relation_myTree.Отмечен.element = element.id;
                            Relation_myTree.Отмечен.f = i;

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