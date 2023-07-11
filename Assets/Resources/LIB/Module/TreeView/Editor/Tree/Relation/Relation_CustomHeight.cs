using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.IMGUI.Controls;


namespace UnityEditor.TreeViewExamples
{

    internal class Relation_CustomHeight : CustomHeightTreeView<Relation_TreeElement>
    {
        private object MyTree;
        private void Обновить() => MyTree.GetType().GetMethod("InitIfNeeded").Invoke(MyTree, new object[] { });
        public Relation_CustomHeight() : base(null, null)
        {

        }
        public Relation_CustomHeight(object MyTree, TreeViewState state, TreeModel<Relation_TreeElement> model) : base(state, model)
        {
            this.MyTree = MyTree;
        }

        protected override void RowGUI(RowGUIArgs args)
        {
            var item = (TreeViewItem<Section_TreeElement>)args.item;
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
        void HeaderGUI(Rect headerRect, string label, TreeViewItem<Section_TreeElement> item)
        {
            headerRect.y += 1f;
            GUI.backgroundColor = item.data.NoProject ? Color.cyan : Color.white;
            // Do toggle
            Rect toggleRect = headerRect;
            toggleRect.width = 16;
            EditorGUI.BeginChangeCheck();
            item.data.enabled = EditorGUI.Toggle(toggleRect, item.data.enabled); // hide when outside cell rect
            if (EditorGUI.EndChangeCheck())
                RefreshCustomRowHeights();

            Rect labelRect = headerRect;
            labelRect.xMin += toggleRect.width + 2f;
            //text
            labelRect.width = 300;
            if (!item.data.NoProject)
            {
                if (EditorGUI.LinkButton(labelRect, label))
                {
                    IEditorGUILayoutPopup.НомерМира = item.data.НомерМира;
                    IEditorGUILayoutPopup.info = item.data.text;
                }
            }
            else
                GUI.Label(labelRect, label);

            if (!item.data.NoProject)
            {
                var num = item.data.НомерМира;
                header_inspector(num, item.data.path, ref labelRect);
                header_scene(num, item.data.path, ref labelRect);
            }
            header_path(item.data.path, ref labelRect);
            header_info(item.data.path, ref labelRect);
            header_new(item.data.NoProject, item.data.path, ref labelRect);

            labelRect.xMin += 2 * labelRect.width + 2f;
            GUI.Label(labelRect, item.data.description);
            GUI.backgroundColor = Color.white;
        }
        #region ссылки на header
        void header_scene(uint num, string path, ref Rect labelRect)
        {
            //scene
            labelRect.x = labelRect.x + labelRect.width + 2f;
            labelRect.width = 35;
            if (EditorGUI.LinkButton(labelRect, "scene")) stModule.file.Class.ОткрытьФайл(path + "/scene" + num + ".cs");
        }
        void header_inspector(uint num, string path, ref Rect labelRect)
        {
            //inspector
            labelRect.x = labelRect.x + labelRect.width + 2f;
            labelRect.width = 57;
            if (EditorGUI.LinkButton(labelRect, "inspector")) stModule.file.Class.ОткрытьФайл(path + "/inspector" + num + ".cs");
        }
        void header_path(string path, ref Rect labelRect)
        {
            //path
            labelRect.x = labelRect.x + labelRect.width + 2f;
            labelRect.width = 28;
            if (EditorGUI.LinkButton(labelRect, "path")) stModule.file.Class.ОткрытьФайл(path);
        }
        void header_info(string path, ref Rect labelRect)
        {
            //info
            labelRect.x = labelRect.x + labelRect.width + 2f;
            labelRect.width = 25;
            if (EditorGUI.LinkButton(labelRect, "info")) stModule.file.Class.ОткрытьФайл(path + "/info.txt", true);
        }
        void header_new(bool NoProject, string path, ref Rect labelRect)
        {
            //new
            //labelRect.x = labelRect.x + labelRect.width + 2f;
            if (stModule.path.Class.Создать(NoProject, path, labelRect)) Обновить();
        }
        #endregion
        //ui вложенненные данные в узле дерева
        protected override float GetCustomRowHeight(int row, TreeViewItem item)
        {
            var min = 30f;
            var myItem = (TreeViewItem<Section_TreeElement>)item;

            if (myItem.data.enabled)
                //открытый контейнер
                return min + (myItem.data.text.Length == 0 ? 0 : 18) + myItem.data.Файлы.Count * 18;

            return min;
        }
        void ControlsGUI(Rect controlsRect, TreeViewItem<Section_TreeElement> item)
        {
            var rect = controlsRect;
            rect.y += 3f;
            rect.height = EditorGUIUtility.singleLineHeight + 5;
            //GUILayout.BeginArea(rect);
            if (item.data.text.Length != 0)
            {
                GUI.Label(rect, item.data.text, stFile.Зелень);
                rect.y += EditorGUIUtility.standardVerticalSpacing + 10;
            }
            //файлы
            foreach (var f in item.data.Файлы)
            {
                rect.height = EditorGUIUtility.singleLineHeight;
                stFile.GUI_btn(rect, f, new Color32(206, 68, 21, 255));
                rect.y += EditorGUIUtility.standardVerticalSpacing + 15;
            }
        }
    }
}


