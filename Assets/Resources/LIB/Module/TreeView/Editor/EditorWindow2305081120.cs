using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
using System;
using System.Linq;
using UnityEditor.TreeViewExamples;
/// <summary>
/// 
/// </summary>
public class EditorGUILayoutTest : EditorWindow, IEditorGUILayoutPopup
{
    [MenuItem("World/Выбрать Мир")]
    static void Init()
    {
        GetWindow(typeof(EditorGUILayoutTest), false, "LIB").Show();
    }
    static public MonoBehaviour _mb;
    static public MonoBehaviour ТекущийИгровойМир
    {
        get
        {
            if (_mb == null) _mb = stModule.world.Class.Моно;
            return _mb;
        }
        set => _mb = value;
    }
    static public uint НомерТекущегоМира
    {
        get
        {
            var mb = ТекущийИгровойМир;
            if (mb == null) return 0;
            return (uint)mb.GetType().GetProperty("НомерМира").GetValue(mb);
        }
    }
    private static string[] _options;

    static public void ОбновитьСписокМиров() => _options = stModule.world.Class.СформироватьСписокМиров;

    static public string[] СписокМиров
    {
        get
        {
            if (_options == null || _options.Length == 0)
                ОбновитьСписокМиров();
            return _options;
        }
    }
    public int tabs = 3;
    void OnGUI()
    {
        stModule.file.Class.Открыть();
        tabs = GUILayout.Toolbar(tabs,(from x in Разделы select Enum.GetName(typeof(stModule.path.Class.Разделы),x.Номер) as String).ToArray<string>());
        Разделы[tabs].fun_project(this, tabs);
    }

    private object GetName<T>(byte номер)
    {
        throw new NotImplementedException();
    }

    public void Очистить()
    {
        //очистка игрового объекта
        var Root = stModule.world.Class.ОбъектМира.transform;
        while (Root.childCount != 0)
            foreach (Transform child in Root)
                UnityEngine.Object.DestroyImmediate(child.gameObject);
        UnityEngine.Object.DestroyImmediate(stModule.world.Class.Моно);
    }
    private MyTree[] Разделы = new MyTree[6] {
        new MyTree((byte)stModule.path.Class.Разделы.PROG,stModule.path.Class.КореньМира),
        new MyTree((byte)stModule.path.Class.Разделы.GO,stModule.path.Class.КореньОбъектМира),
        new MyTree((byte)stModule.path.Class.Разделы.CLASS,stModule.path.Class.КореньКласс),
        new MyTree((byte)stModule.path.Class.Разделы.STRUCT,stModule.path.Class.КореньСтрукт),
        new MyTree((byte)stModule.path.Class.Разделы.FUNS,stModule.path.Class.КореньФунМира),
        new MyTree((byte)stModule.path.Class.Разделы.SHADER,stModule.path.Class.КореньШейдеров),
    };
    private class MyTree
    {
        string PATH;
        public byte Номер;
        public MyTree(byte Номер, string PATH)
        {
            this.Номер = Номер;
            this.PATH = PATH;
        }
        [NonSerialized] bool m_Initialized;
        [SerializeField] UnityEditor.IMGUI.Controls.TreeViewState m_TreeViewState;
        CustomHeightTreeView m_TreeView;
        UnityEditor.IMGUI.Controls.SearchField m_SearchField;
        MyTreeAsset m_MyTreeAsset;

        IList<MyTreeElement> GetData()
        {
            if (m_MyTreeAsset != null && m_MyTreeAsset.treeElements != null && m_MyTreeAsset.treeElements.Count > 0)
                return m_MyTreeAsset.treeElements;

            // generate some test data
            return MyTreeElementGenerator.GenerateRandomTree(12, PATH);
        }
        void InitIfNeeded()
        {
            // Check if it already exists (deserialized from window layout file or scriptable object)
            if (m_TreeViewState == null)
                m_TreeViewState = new UnityEditor.IMGUI.Controls.TreeViewState();

            m_TreeView = new CustomHeightTreeView(InitIfNeeded, m_TreeViewState, new TreeModel<MyTreeElement>(GetData()));

            m_SearchField = new UnityEditor.IMGUI.Controls.SearchField();
            m_SearchField.downOrUpArrowKeyPressed += m_TreeView.SetFocusAndEnsureSelectedItem;

            m_Initialized = true;
        }
        void SearchBar(EditorGUILayoutTest edit, Rect rect)
        {
            GUILayout.BeginArea(rect);
            var style = "miniButton";
            using (new EditorGUILayout.HorizontalScope())
            {
                //if (GUILayout.Button("DIR.add", style))
                //{
                    //EditorUtility.DisplayDialog(name, PATH, "Добавить", "Отмена");
                    //var dlgResult = UnityEngine.Rendering.DebugUI.MessageBox.Show("Patterns have been logged successfully", "Logtool", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    //Directory.CreateDirectory(stModule.path.Class.ОпределитьКореньРаздела(Номер));
                //}
                if (GUILayout.Button("Обновить", style)) m_Initialized = false;
                if (GUILayout.Button("Expand All", style))
                    m_TreeView.ExpandAll();

                if (GUILayout.Button("Collapse All", style))
                    m_TreeView.CollapseAll();
            }
            m_TreeView.searchString = m_SearchField.OnGUI(new Rect(20f, 25f, edit.position.width - 40f, 50f), m_TreeView.searchString);
            //using (new EditorGUILayout.HorizontalScope())
            //{
            //}
            GUILayout.EndArea();
        }
        void DoTreeView(Rect rect)
        {
            m_TreeView.OnGUI(rect);
        }
        public void fun_project(EditorGUILayoutTest edit, int key)
        {
            if (!m_Initialized) InitIfNeeded();
            SearchBar(edit, edit.toolbarRect);
            DoTreeView(edit.multiColumnTreeViewRect);
            if (key == 0) edit.BottomToolBar(edit.bottomToolbarRect);
        }
    }
    Rect toolbarRect
    {
        get { return new Rect(20f, 50f, position.width - 40f, 60f); }
    }
    Rect multiColumnTreeViewRect
    {
        get { return new Rect(20, 100, position.width - 40, position.height - 200); }
    }
    Rect bottomToolbarRect
    {
        get { return new Rect(20f, position.height - 100f, position.width - 40f, 150f); }
    }

    void BottomToolBar(Rect rect)
    {
        GUILayout.BeginArea(rect);
        using (new EditorGUILayout.VerticalScope())
        {
            var style = "miniButton";
            using (new EditorGUILayout.HorizontalScope())
            {
                GUILayout.Label("number=" + IEditorGUILayoutPopup.НомерМира + ", назначен " + НомерТекущегоМира);
            }
            using (new EditorGUILayout.HorizontalScope())
            {
                if (GUILayout.Button("Выбрать", style))
                {
                    Очистить();
                    //обход по всем файлам
                    stModule.path.Class.Обновить(IEditorGUILayoutPopup.НомерМира);
                    //сохранение
                    stModule.Class.Сохранить(IEditorGUILayoutPopup.НомерМира, IEditorGUILayoutPopup.info);
                    stModule.file.Class.ОткрытьФайл(stModule.path.Class.ОбщийМодульМира);
                }
                if (GUILayout.Button("Update", style))
                {
                    ТекущийИгровойМир = stModule.world.Class.Моно;
                    ТекущийИгровойМир.GetType().GetMethod("ИзменитьМир").Invoke(ТекущийИгровойМир, new object[] { IEditorGUILayoutPopup.НомерМира });
                    Debug.Log("Мировой объект изменился!!!");
                }
                if (GUILayout.Button("Free", style))
                {
                    Очистить();
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
    static class MyTreeElementGenerator
    {
        static int IDCounter;
        public static List<MyTreeElement> GenerateRandomTree(int numTotalElements, string PATH)
        {
            IDCounter = 0;
            var treeElements = new List<MyTreeElement>(numTotalElements);
            //var PATH = stModule.path.Class.КореньМира;
            var root = new MyTreeElement(false, "Root", "КореньМира", PATH, -1, IDCounter);
            treeElements.Add(root);
            AddChildrenRecursive(PATH, root, treeElements);

            return treeElements;
        }
        static void AddChildrenRecursive(string PATH, TreeElement element, List<MyTreeElement> treeElements)
        {
            foreach (string d in Directory.GetDirectories(PATH))
            {

                var child = new MyTreeElement(stModule.join.Class.ЭтоНеЦифры(d), Path.GetFileName(d), "empty", d, element.depth + 1, ++IDCounter);
                treeElements.Add(child);
                AddChildrenRecursive(d, child, treeElements);
            }
        }
    }
}