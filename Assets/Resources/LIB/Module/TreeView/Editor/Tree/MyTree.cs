using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

namespace UnityEditor.TreeViewExamples
{
    internal class MyTree<TTreeElement, TCustomHeightTreeView>
        where TTreeElement : TreeElementProp
        where TCustomHeightTreeView : CustomHeightTreeView<TTreeElement>, new()
    {
        public EditorGUILayoutTest edit;
        public string PATH;
        [NonSerialized] public bool m_Initialized;
        [SerializeField] IMGUI.Controls.TreeViewState m_TreeViewState;
        public TCustomHeightTreeView m_TreeView;
        public MyTree()
        {

        }
        #region Generate
        private int IDCounter; public int ПоследнийЭлемент { get => IDCounter; set => IDCounter = value; }
        public List<TTreeElement> GenerateRandomTree()
        {
            ПоследнийЭлемент = 0;

            var treeElements = new List<TTreeElement>();
            var root = stExemple.СоздатьЭкземпляр<TTreeElement>(new object[] { PATH, false, "Root", "КореньМира", -1, ПоследнийЭлемент });
            treeElements.Add(root);
            AddChildrenRecursive(PATH, root, treeElements);

            return treeElements;
        }

        #region ADD
        public TTreeElement ДобавитьИмя(string name, TreeElement element, List<TTreeElement> treeElements) => Добавить(name, name, element, treeElements);
        public TTreeElement Добавить(string path, TreeElement element, List<TTreeElement> treeElements) => Добавить(path, Path.GetFileName(path), element, treeElements);
        public virtual TTreeElement Добавить(string path, string name, TreeElement element, List<TTreeElement> treeElements)
        {
            var child = Создать(path, name, element);
            treeElements.Add(child);
            return child;
        }
        public TTreeElement Создать(string path, string name, TreeElement element)
        {
            var b = stModule.join.Class.ЭтоНеЦифры(path);
            return stExemple.СоздатьЭкземпляр<TTreeElement>(new object[] {
                path, b, name, stFile.ВытащитьКомментарий(path), element.depth + 1, ++ПоследнийЭлемент });
        }
        public virtual void AddChildrenRecursive(string path, TreeElement element, List<TTreeElement> treeElements)
        {
            foreach (string d in Directory.GetDirectories(path))
                AddChildrenRecursive(d, Добавить(d, element, treeElements), treeElements);
        }
        #endregion
        #endregion
        public MyTree(EditorGUILayoutTest edit, string PATH)
        {
            this.edit = edit;
            this.PATH = PATH;
        }
        #region m_MyTreeAsset
        MyTreeAsset<TTreeElement> m_MyTreeAsset;
        private IList<TTreeElement> GetData()
        {
            if (m_MyTreeAsset != null && m_MyTreeAsset.treeElements != null && m_MyTreeAsset.treeElements.Count > 0)
                return m_MyTreeAsset.treeElements;

            // generate some test data
            return GenerateRandomTree();
        }
        #endregion
        public virtual void InitIfNeeded()
        {
            // Check if it already exists (deserialized from window layout file or scriptable object)
            if (m_TreeViewState == null)
                m_TreeViewState = new IMGUI.Controls.TreeViewState();

            m_TreeView = stExemple.СоздатьЭкземпляр<TCustomHeightTreeView>(new object[] { this, m_TreeViewState, new TreeModel<TTreeElement>(GetData()) });

            m_Initialized = true;
        }
        public virtual void fun_project(int key = 0, System.Action Castom_Bar = null)
        {
            if (!m_Initialized) InitIfNeeded();
            Bar(Castom_Bar);
            m_TreeView.OnGUI(multiColumnTreeViewRect);
        }
        public virtual void Bar(System.Action CastomBar)
        {
            GUILayout.BeginArea(toolbarRect);
            var style = "miniButton";
            using (new EditorGUILayout.HorizontalScope())
            {
                if (GUILayout.Button("Обновить", style)) m_Initialized = false;
                if (GUILayout.Button("Expand All", style))
                    m_TreeView.ExpandAll();

                if (GUILayout.Button("Collapse All", style))
                    m_TreeView.CollapseAll();
            }
            CastomBar?.Invoke();
            GUILayout.EndArea();
        }
        #region Rect
        public virtual Rect toolbarRect => new Rect(20, 50, edit.dw - 10, 60);
        public virtual Rect multiColumnTreeViewRect => new Rect(20, 100, edit.dw, edit.position.height - 200);
        #endregion
    }
}