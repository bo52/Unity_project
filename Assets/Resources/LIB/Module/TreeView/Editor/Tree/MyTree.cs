using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

namespace UnityEditor.TreeViewExamples
{
    internal class MyTree<TTreeElement, TCustomHeightTreeView> 
        where TTreeElement : TreeElementProp
        where TCustomHeightTreeView:CustomHeightTreeView<TTreeElement>,new()
    {
        public EditorGUILayoutTest edit;
        public string PATH;
        public int n=1;
        [NonSerialized] public bool m_Initialized;
        [SerializeField] IMGUI.Controls.TreeViewState m_TreeViewState;
        public TCustomHeightTreeView m_TreeView;
        public MyTree()
        {

        }
        #region Generate
        private int IDCounter;
        public List<TTreeElement> GenerateRandomTree()
        {
            IDCounter = 0;

            var treeElements = new List<TTreeElement>();
            //var PATH = stModule.path.Class.КореньМира;
            var root = stExemple.СоздатьЭкземпляр<TTreeElement>(new object[] { PATH, false, "Root", "КореньМира", -1, IDCounter });
            treeElements.Add(root);
            AddChildrenRecursive(PATH, root, treeElements);

            return treeElements;
        }
        public virtual void AddChildrenRecursive(string path, TreeElement element, List<TTreeElement> treeElements)
        {
            foreach (string d in Directory.GetDirectories(path))
            {

                var child = stExemple.СоздатьЭкземпляр<TTreeElement>(new object[] { d, stModule.join.Class.ЭтоНеЦифры(d), Path.GetFileName(d), "empty", element.depth + 1, ++IDCounter });
                treeElements.Add(child);
                AddChildrenRecursive(d, child, treeElements);
            }
        } 
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
        public virtual void fun_project(int key = 0,System.Action Castom_Bar=null)
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
        Rect toolbarRect
        {
            get { return new Rect(20f, 50f,n *edit.dw, 60f); }
        }
        Rect multiColumnTreeViewRect
        {
            get { return new Rect(20, 100, n * edit.dw, edit.position.height - 200); }
        } 
        #endregion
    }
}