using UnityEditor.IMGUI.Controls;
using UnityEngine;
namespace UnityEditor.TreeViewExamples
{
    internal class TreeSearch
    {
        private TreeView tree;
        private EditorGUILayoutTest edit;
        public TreeSearch(EditorGUILayoutTest edit, TreeView tree)
        {
            this.edit = edit;
            this.tree = tree;
        }
        IMGUI.Controls.SearchField m_SearchField;
        public void InitIfNeeded()
        {
            m_SearchField = new IMGUI.Controls.SearchField();
            m_SearchField.downOrUpArrowKeyPressed += tree.SetFocusAndEnsureSelectedItem;
        }
        public void Bar()
        {
            tree.searchString = m_SearchField.OnGUI(search_rect, tree.searchString);
        }
        #region rect
        private Rect search_rect=>new Rect(20f, 25f, edit.dw - 30, 50f); 
        #endregion
    }
}