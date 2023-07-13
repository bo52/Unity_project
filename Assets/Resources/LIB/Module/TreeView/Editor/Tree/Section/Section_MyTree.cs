namespace UnityEditor.TreeViewExamples
{
    internal class Section_MyTree : Section_MyTree<Section_TreeElement, Section_CustomHeightTreeView>
    {
        public Section_MyTree(EditorGUILayoutTest edit, byte Номер, string PATH) : base(edit, Номер, PATH)
        {
        }
    }
    internal class Section_MyTree<TTreeElement, TCustomHeightTreeView> : MyTree<TTreeElement, TCustomHeightTreeView>
        where TTreeElement : TreeElementProp, new()
        where TCustomHeightTreeView : CustomHeightTreeView<TTreeElement>, new()
    {
        public byte Номер;
        TreeSearch _search;
        TreeSearch Search
        {
            get
            {
                if (_search == null) _search = new TreeSearch(edit, this.m_TreeView);
                return _search;
            }
        }
        public Section_MyTree(EditorGUILayoutTest edit, byte Номер, string PATH) : base(edit, PATH)
        {
            this.Номер = Номер;
        }
        public override void InitIfNeeded()
        {

            base.InitIfNeeded();
            Search.InitIfNeeded();
        }
        public override void Bar(System.Action CastomBar)
        {
            base.Bar(Search.Bar);
        }
        public override void fun_project(int key, System.Action Castom_Bar = null)
        {
            base.fun_project(key);
        }
    }
}