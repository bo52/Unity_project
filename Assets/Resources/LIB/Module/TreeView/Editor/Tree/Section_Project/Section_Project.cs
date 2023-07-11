using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityEditor.TreeViewExamples
{
    internal class Section_Project : Section_MyTree
    {
        public Section_Project(EditorGUILayoutTest edit,byte НОМЕР,string PATH) :base(edit, НОМЕР, PATH)
        {
        }
        public override void fun_project(int key, System.Action Castom_Bar=null)
        {
            base.fun_project(key);
            if (key == 0) BottomToolBar(bottomToolbarRect);
        }
        public void BottomToolBar(Rect rect)
        {
            GUILayout.BeginArea(rect);
            using (new EditorGUILayout.VerticalScope())
            {
                var style = "miniButton";
                using (new EditorGUILayout.HorizontalScope())
                {
                    GUILayout.Label("number=" + IEditorGUILayoutPopup.НомерМира + ", назначен " + EditorGUILayoutTest.НомерТекущегоМира);
                }
                using (new EditorGUILayout.HorizontalScope())
                {
                    if (GUILayout.Button("Выбрать", style))
                    {
                        edit.Очистить();
                        //обход по всем файлам
                        stModule.path.Class.Обновить(IEditorGUILayoutPopup.НомерМира);
                        //сохранение
                        stModule.Class.Сохранить(IEditorGUILayoutPopup.НомерМира, IEditorGUILayoutPopup.info);
                        stModule.file.Class.ОткрытьФайл(stModule.path.Class.ОбщийМодульМира);
                    }
                    if (GUILayout.Button("Update", style))
                    {
                        EditorGUILayoutTest.ТекущийИгровойМир = stModule.world.Class.Моно;
                        EditorGUILayoutTest.ТекущийИгровойМир.GetType().GetMethod("ИзменитьМир").Invoke(EditorGUILayoutTest.ТекущийИгровойМир, new object[] { IEditorGUILayoutPopup.НомерМира });
                        Debug.Log("Мировой объект изменился!!!");
                    }
                    if (GUILayout.Button("Free", style))
                    {
                        edit.Очистить();
                        stModule.file.Class.Очистить();
                        stModule.file.Class.ОткрытьФайл(stModule.path.Class.ОбщийМодульМира);
                    }
                }
                using (new EditorGUILayout.HorizontalScope())
                {
                    GUILayout.Label(IEditorGUILayoutPopup.info);
                }
            }
            GUILayout.EndArea();
        }
        Rect bottomToolbarRect
        {
            get { return new Rect(20f, edit.position.height - 100f, edit.position.width - edit.dw, 150f); }
        }
    }
}