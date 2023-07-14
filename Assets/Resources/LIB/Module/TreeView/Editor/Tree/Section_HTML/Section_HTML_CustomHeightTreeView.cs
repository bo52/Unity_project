using System.Collections.Generic;
using UnityEngine;

using UnityEditor.IMGUI.Controls;


namespace UnityEditor.TreeViewExamples
{

    internal class Section_HTML_CustomHeightTreeView : CustomHeightTreeView<Section_HTML_TreeElement>
    {
        private object MyTree;
        private void Обновить() => MyTree.GetType().GetMethod("InitIfNeeded").Invoke(MyTree, new object[] { });
        public Section_HTML_CustomHeightTreeView() : base(null, null)
        {

        }
        public Section_HTML_CustomHeightTreeView(object MyTree, TreeViewState state, TreeModel<Section_HTML_TreeElement> model) : base(state, model)
        {
            this.MyTree = MyTree;
        }

        protected override void RowGUI(RowGUIArgs args)
        {
            var item = (TreeViewItem<Section_HTML_TreeElement>)args.item;
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
        void HeaderGUI(Rect headerRect, string label, TreeViewItem<Section_HTML_TreeElement> item)
        {
            headerRect.y += 1f;        
            Rect labelRect = headerRect;
            //text
            labelRect.width = 300;
            GUI.Label(labelRect, label);

            labelRect.y += 3f;
            header_edit(ref labelRect, item);
            labelRect.y -= 3f;
            header_path(item.data.path, ref labelRect);

            labelRect.xMin += 2 * labelRect.width + 2f;
            GUI.Label(labelRect, item.data.description);
        }
        void ControlsGUI(Rect controlsRect, TreeViewItem<Section_HTML_TreeElement> item)
        {
            var rect = controlsRect;
            rect.y += 3f;
            rect.height = EditorGUIUtility.singleLineHeight + 5;

            Item_descript(ref rect, item.data.description);
        }
        #region ссылки на header
        static public string html = "https://evgbobrecov.blogspot.com/";
        void header_path(string path, ref Rect labelRect)
        {
            //path
            labelRect.x = labelRect.x + labelRect.width + 2f;
            labelRect.width = 28;
            if (EditorGUI.LinkButton(labelRect, "path")) stModule.file.Class.ОткрытьФайл(html+ path + ".html");
        }
        static private TreeViewItem<Section_HTML_TreeElement> element;
        static public bool ПоказатьРедактор(Rect barEdit1, Rect barEdit2, Rect barEdit3)
        {
            var b = false;
            if (element != null)
            {
                GUILayout.BeginVertical();
                var e = GUI.TextField(barEdit1, element.data.name);
                if (e!= element.data.name)
                {
                    element.data.name = e;
                    b = true;
                }

                element.data.description = GUI.TextField(barEdit2, element.data.description);
                element.data.path = GUI.TextField(barEdit3, element.data.path);
                GUILayout.EndVertical();
            }
            return b;
        }
        void header_edit(ref Rect labelRect, TreeViewItem<Section_HTML_TreeElement> item)
        {
            //path
            labelRect.x = labelRect.x + labelRect.width + 2f;
            labelRect.width = 28;
            if (GUI.Button(labelRect, "edit",stFile.Стиль(Color.black))) element = item;
        }
        #endregion
        #region ui вложенненные данные в узле дерева
        protected override float GetCustomRowHeight(int row, TreeViewItem item)
        {
            var min = 30f;
            var myItem = (TreeViewItem<Section_HTML_TreeElement>)item;

            if (myItem.data.enabled)
                //открытый контейнер
                return min + (myItem.data.description.Length == 0 ? 0 : 25);

            return min;
        } 
        #endregion
    }
}