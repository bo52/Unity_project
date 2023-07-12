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
        private void Зависимости(TreeViewItem<Relation_TreeElement> item) => MyTree.GetType().GetMethod("ВыполнитьЗависимости").Invoke(MyTree, new object[] { item });
        public Relation_CustomHeight() : base(null, null)
        {

        }
        public Relation_CustomHeight(object MyTree, TreeViewState state, TreeModel<Relation_TreeElement> model) : base(state, model)
        {
            this.MyTree = MyTree;
        }

        protected override void RowGUI(RowGUIArgs args)
        {
            var item = (TreeViewItem<Relation_TreeElement>)args.item;
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
        void HeaderGUI(Rect headerRect, string label, TreeViewItem<Relation_TreeElement> item)
        {
            headerRect.y += 1f;
            GUI.backgroundColor = item.data.NoProject ? Color.cyan : Color.white;
            

            Rect labelRect = headerRect;
            //text
            labelRect.width = 300;
            GUI.Label(labelRect, label,stFile.Стиль(ЭтоРаздел(item.data.path) ? Color.red : new Color32(0, 158, 26, 255)));

            header_path(item.data.path, ref labelRect);
            header_relation(item, ref labelRect);

            labelRect.xMin += 2 * labelRect.width + 2f;
            GUI.Label(labelRect, item.data.description);
            GUI.backgroundColor = Color.white;
        }
        #region ссылки на header
        void header_path(string path, ref Rect labelRect)
        {
            //path
            labelRect.x = labelRect.x + labelRect.width + 2f;
            labelRect.width = 28;
            if (EditorGUI.LinkButton(labelRect, "path")) stModule.file.Class.ОткрытьФайл(path);
        }
        #endregion
        //ui вложенненные данные в узле дерева
        protected override float GetCustomRowHeight(int row, TreeViewItem item)
        {
            var min = 30f;
            var myItem = (TreeViewItem<Relation_TreeElement>)item;

            if (myItem.data.enabled)
                //открытый контейнер
                return min + (myItem.data.description.Length == 0 ? 0 : 18);

            return min;
        }
        void ControlsGUI(Rect controlsRect, TreeViewItem<Relation_TreeElement> item)
        {
            var rect = controlsRect;
            rect.y += 3f;
            rect.height = EditorGUIUtility.singleLineHeight + 5;

            Item_descript(ref rect, item.data.description);
        }
        bool ЭтоРаздел(string path) =>path == "uses"|| path == "used";
        void header_relation(TreeViewItem<Relation_TreeElement> item, ref Rect labelRect)
        {
            if (ЭтоРаздел(item.data.path)) return;
            //info
            labelRect.y += 3f;
            labelRect.x = labelRect.x + labelRect.width + 10f;
            labelRect.width = 75;
            if (GUI.Button(labelRect, "Зависимости", stFile.Стиль(stFile.Фиолетовый))) Зависимости(item);
            }
        }
}


