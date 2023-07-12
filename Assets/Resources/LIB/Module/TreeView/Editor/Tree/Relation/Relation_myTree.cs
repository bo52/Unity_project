using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor.IMGUI.Controls;
using System.IO;

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
            base.InitIfNeeded();
        }
        public override void Bar(System.Action CastomBar)
        {
        }
        public override void fun_project(int key, System.Action Castom_Bar = null)
        {
            base.fun_project(key);
        }
        #region Rect
        public override Rect toolbarRect => new Rect(edit.dw + 20, 50, edit.dw, 60);
        public override Rect multiColumnTreeViewRect => new Rect(edit.dw + 20, 100, edit.dw, edit.position.height - 200);
        #endregion
        #region �����������
        public override void AddChildrenRecursive(string path, TreeElement element, List<Relation_TreeElement> treeElements)
        {
            var child = ��������(path, element, treeElements);
            var M = stFile.����������(path);
            fun_uses(M,
                (���) => �����������(���, child, treeElements),
                (���������, item) => { ��������(���������, item, treeElements); }
            );
            fun_used(M, child, treeElements);
        }
        public void AddChildrenRecursive2(string path, TreeViewItem<Relation_TreeElement> element)
        {
            if (element.children!=null&&element.children.Count>0)
                m_TreeView.treeModel.RemoveElements(new List<int> { element.children[0].id });

            //var ROOT = new Relation_TreeElement(path, false, path, "����������", -1, 0);
            //m_TreeView.treeModel.AddElement(ROOT, element.data, 0);

            var M = stFile.����������(path);
            fun_uses(M,
                (���������) =>
                {
                    var root = new Relation_TreeElement(���������, true, ���������, "����������", -1, ++����������������);
                    m_TreeView.treeModel.AddElement(root, element.data, 0);
                    return root;
                },
                (���������, item) =>
                {
                    var root_element = new Relation_TreeElement(���������, false, Path.GetFileName(���������), "����������", -1, ++����������������);
                    m_TreeView.treeModel.AddElement(root_element, item, 0);
                }
            );
        }
        private void fun_uses(uint M, System.Func<string, TreeElement> fun_root, System.Action<string, TreeElement> fun)
        {
            //�������� � ����������
            if (stModule.path.Class.����������.ContainsKey(M) == false) return;
            var bs = stModule.path.Class.����������[M].fs;

            TreeElement child = null;
            foreach (var b in bs)
                foreach (var num in b.numbers)
                {
                    if (num.M == M) continue;
                    if (!stModule.path.Class.����������.ContainsKey(num.M)) continue;
                    if (child == null) child = fun_root("uses");
                    fun(stModule.path.Class.����������[num.M].path, child);
                }
        }
        private void fun_used(uint M, TreeElement element, List<Relation_TreeElement> treeElements)
        {
            �����������("used", element, treeElements);
        }
        public void fun_f(string new_path)
        {
            this.PATH = new_path;
            stModule.path.Class.�����������������();
            InitIfNeeded();
        }
        public void ��������������������(TreeViewItem<Relation_TreeElement> item)
        {
            stModule.path.Class.�����������������();
            AddChildrenRecursive2(item.data.path, item);
        }
        #endregion
    }
}
