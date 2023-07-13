using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

namespace UnityEditor.TreeViewExamples
{
    internal class Relation_myTree : MyTree<Relation_TreeElement, Relation_CustomHeight>
    {
        public string NameFile = "empty";
        public static class Отмечен
        {
            public static int tabs =-1;
            public static int element = -1;
            public static int f = -1;
        }
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
        #region Зависимости
        public override void AddChildrenRecursive(string path, TreeElement element, List<Relation_TreeElement> treeElements)
        {
            var child = Добавить(path, element, treeElements);

            TreeElement fun1(string Имя)=>ДобавитьИмя(Имя, child, treeElements);
            void fun2(string Зависимый, TreeElement item) => Добавить(Зависимый, item, treeElements);

            var M = stFile.НомерФайла(path);
            fun_uses(M, fun1, fun2);
            fun_useds(M, fun1, fun2);
        }
        public void AddChildrenRecursive2(string path, TreeViewItem<Relation_TreeElement> element)
        {
            if (element.children != null && element.children.Count > 0&& element.children[0]!=null)
                m_TreeView.treeModel.RemoveElements(new List<int> { element.children[0].id, element.children[1].id });

            TreeElement fun1(string Имя)
            {
                var root = new Relation_TreeElement(Имя, true, Имя, "", -1, ++ПоследнийЭлемент);
                m_TreeView.treeModel.AddElement(root, element.data, 0);
                return root;
            };
            void fun2(string Зависимый, TreeElement item)
            {
                var root_element = new Relation_TreeElement(Зависимый, false, Path.GetFileName(Зависимый), stFile.ВытащитьКомментарий(Зависимый), -1, ++ПоследнийЭлемент);
                m_TreeView.treeModel.AddElement(root_element, item, 0);
                //m_TreeView.SetSelection();
            }
            var M = stFile.НомерФайла(path);
            fun_uses(M, fun1, fun2);
            fun_useds(M, fun1, fun2);
        }

        private void fun_uses(uint M, Func<string, TreeElement> fun_root, System.Action<string, TreeElement> fun)
        {
            //проверка в Библиотеки
            if (stModule.path.Class.Библиотеки.ContainsKey(M) == false) return;
            var bs = stModule.path.Class.Библиотеки[M].fs;
            TreeElement child = null;
            foreach (var b in bs)
                foreach (var num in b.numbers)
                {
                    if (num.M == M) continue;
                    if (!stModule.path.Class.Библиотеки.ContainsKey(num.M)) continue;
                    if (child == null) child = fun_root("uses");
                    fun(stModule.path.Class.Библиотеки[num.M].path, child);
                }

        }
        private void fun_useds(uint M, Func<string, TreeElement> fun_root, Action<string, TreeElement> fun)
        {

            TreeElement child = null;
            void fun_used(stModule.path.Class.Библиотека b)
            {
                foreach (var bodys in b.fs)
                {
                    foreach (var num in bodys.numbers)
                    {
                        if (num.M != M) continue;
                        if (child == null) child = fun_root("used");
                        fun(b.path, child);
                        break;
                    }
                }
            }
            foreach (var b in stModule.path.Class.Библиотеки)
            {
                if (b.Key == M) continue;
                fun_used(b.Value);
            }
        }
        public void fun_f(string new_path)
        {
            this.PATH = new_path;
            stModule.path.Class.СобратьБиблиотеки();
            InitIfNeeded();
        }
        public void ВыполнитьЗависимости(TreeViewItem<Relation_TreeElement> item)
        {
            stModule.path.Class.СобратьБиблиотеки();
            AddChildrenRecursive2(item.data.path, item);
        }
        #endregion
    }
}
