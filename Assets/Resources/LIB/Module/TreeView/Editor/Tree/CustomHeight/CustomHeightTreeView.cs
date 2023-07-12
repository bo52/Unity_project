using UnityEditor.IMGUI.Controls;
using UnityEngine;


namespace UnityEditor.TreeViewExamples
{

    internal class CustomHeightTreeView<TTreeElement> : TreeViewWithTreeModel<TTreeElement>
        where TTreeElement : TreeElementProp
    {
        public static class Styles
        {
            public static GUIStyle background = "RL Background";
            public static GUIStyle headerBackground = "RL Header";
        }

        public CustomHeightTreeView(TreeViewState state, TreeModel<TTreeElement> model) : base(state, model)
        {
            // Custom setup
            showBorder = true;
            customFoldoutYOffset = 3f;

            Reload();
        }
        protected void Item_descript(ref Rect rect, string descript)
        {
            if (descript.Length != 0)
            {
                GUI.Label(rect, descript, stFile.Зелень);
                rect.y += EditorGUIUtility.standardVerticalSpacing + 10;
            }
        }
        public override void OnGUI(Rect rect)
        {
            // Background
            if (Event.current.type == EventType.Repaint)
                DefaultStyles.backgroundOdd.Draw(rect, false, false, false, false);

            // TreeView
            base.OnGUI(rect);
        }

        protected override void RowGUI(RowGUIArgs args)
        {
            var item = (TreeViewItem<TTreeElement>)args.item;
            var contentIndent = GetContentIndent(item);
            // Background
            var bgRect = args.rowRect;
            //высота вложенности
            bgRect.x = contentIndent;
            bgRect.width = Mathf.Max(bgRect.width - contentIndent, 155f) - 5f;
            bgRect.yMin += 2f;
            bgRect.yMax -= 2f;
            DrawItemBackground(bgRect);

            // Custom label
            var headerRect = bgRect;
            headerRect.xMin += 5f;
            headerRect.xMax -= 10f;
            headerRect.height = Styles.headerBackground.fixedHeight;
            //GUI.color = Color.red;
            HeaderGUI(headerRect, args.label, item);
            //GUI.color = Color.white;
            // Controls
            var controlsRect = headerRect;
            controlsRect.xMin += 10f;
            controlsRect.y += headerRect.height;
            //controlsRect.height = 100;
            if (item.data.enabled)
                ControlsGUI(controlsRect, item);
        }
        void DrawItemBackground(Rect bgRect)
        {
            if (Event.current.type == EventType.Repaint)
            {
                var rect = bgRect;
                rect.height = Styles.headerBackground.fixedHeight;
                Styles.headerBackground.Draw(rect, false, false, false, false);

                rect.y += rect.height;
                rect.height = bgRect.height - rect.height;
                Styles.background.Draw(rect, false, false, false, false);
            }
        }
        //заголовок родительского узла корня
        void HeaderGUI(Rect headerRect, string label, TreeViewItem<TTreeElement> item)
        {
        }
        //ui вложенненные данные в узле дерева
        protected override float GetCustomRowHeight(int row, TreeViewItem item)
        {
            var min = 30f;
            return min;
        }
        void ControlsGUI(Rect controlsRect, TreeViewItem<TTreeElement> item)
        {
        }

        protected override Rect GetRenameRect(Rect rowRect, int row, TreeViewItem item)
        {
            // Match label perfectly
            var renameRect = base.GetRenameRect(rowRect, row, item);
            renameRect.xMin += 25f;
            renameRect.y += 2f;
            return renameRect;
        }
    }
}
