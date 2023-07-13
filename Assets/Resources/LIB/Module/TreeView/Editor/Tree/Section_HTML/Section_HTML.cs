using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityEditor.TreeViewExamples
{
    internal class Section_HTML : Section_MyTree<Section_HTML_TreeElement, Section_HTML_CustomHeightTreeView>
    {
        public Section_HTML(EditorGUILayoutTest edit, byte НОМЕР, string PATH) : base(edit, НОМЕР, PATH)
        {
        }
        public override void AddChildrenRecursive(string path, TreeElement element, List<Section_HTML_TreeElement> treeElements)
        {
        }
        public override void bar()
        {
            if (GUILayout.Button("Добавить"))
            {
                var root = new Section_HTML_TreeElement("empty", true, "empty", "empty", -1, ++ПоследнийЭлемент);
                var list = m_TreeView.GetSelection();
                if (list.Count == 0)
                    m_TreeView.treeModel.AddElement(root, m_TreeView.treeModel.root, 0);
                else
                    foreach (var id in list)
                        m_TreeView.treeModel.AddElement(root, m_TreeView.treeModel.Find(id), 0);
            }
            if (GUILayout.Button("Сохранить"))
            {
            }
            if (GUILayout.Button("Загрузить"))
            {
            }
        }
    }
}