using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace UnityEditor.TreeViewExamples
{
    internal class Section_HTML : Section_MyTree<Section_HTML_TreeElement, Section_HTML_CustomHeightTreeView>
    {
        public Section_HTML(EditorGUILayoutTest edit, string PATH) : base(edit, PATH)
        {
        }
        private string myPATH = "/Resources/LIB/Module/TreeView/Editor/Tree/Section_HTML/data.ini";
        public override void bar()
        {
            if (GUILayout.Button("Url"))
                stModule.file.Class.ОткрытьФайл(Section_HTML_CustomHeightTreeView.html);
            //if (GUILayout.Button("test"))
                //this.m_TreeView.Reload();

                if (GUILayout.Button("Добавить"))
            {
                var root = new Section_HTML_TreeElement("empty", "empty", "empty", -1, ++ПоследнийЭлемент);
                var list = m_TreeView.GetSelection();
                if (list.Count == 0)
                    m_TreeView.treeModel.AddElement(root, m_TreeView.treeModel.root, 0);
                else
                    foreach (var id in list)
                        m_TreeView.treeModel.AddElement(root, m_TreeView.treeModel.Find(id), 0);
            }
            if (GUILayout.Button("Сохранить"))
            {
                StreamWriter sw = new StreamWriter(Application.dataPath + myPATH);
                foreach (var ROW in m_TreeView.GetRows())
                {
                    var row = ROW as TreeViewItem<Section_HTML_TreeElement>;
                    sw.WriteLine(row.depth + "|" + row.data.name + "|" + row.data.path + "|" + row.data.description);
                }
                sw.Close();
            }
            if (GUILayout.Button("Загрузить")) m_Initialized = false;
        }
        public override object[] ПараметрыКорня => new object[] { PATH, "Root", "КореньМира", -1, ПоследнийЭлемент };
        public override void AddChildrenRecursive(string path, TreeElement element, List<Section_HTML_TreeElement> treeElements)
        {
            var f = Application.dataPath + myPATH;
            if (!File.Exists(f)) return;
            StreamReader sr = new StreamReader(Application.dataPath + myPATH);
            var line = sr.ReadLine();
            while (line != null)
            {
                var ms = line.Split("|");
                var depth = System.Convert.ToInt32(ms[0]);
                var child = stExemple.СоздатьЭкземпляр<Section_HTML_TreeElement>(new object[] { ms[2], ms[1], ms[3], depth, ++ПоследнийЭлемент });
                treeElements.Add(child);
                line = sr.ReadLine();
            }
            sr.Close();
        }
        public override void Bar(System.Action CastomBar)
        {
            var y = 50;
            var h = 20;
            var x = 20 + edit.dw;
            var w = 500;
            if (Section_HTML_CustomHeightTreeView.ПоказатьРедактор(new Rect(x, y, w, h), new Rect(x, y + 20, w, h), new Rect(x, y + 40, w, h))) m_TreeView.Reload();
            base.Bar(null);
        }
        #region Rect
        public Rect barEdit => new Rect(20 + edit.dw, 50 + 40, edit.dw - 10, 20);
        public override Rect toolbarRect => new Rect(20 + edit.dw, 75 + 40, edit.dw - 10, 60);
        public override Rect multiColumnTreeViewRect => new Rect(20 + edit.dw, 125 + 40, edit.dw, edit.position.height - 200);
        #endregion
    }
}