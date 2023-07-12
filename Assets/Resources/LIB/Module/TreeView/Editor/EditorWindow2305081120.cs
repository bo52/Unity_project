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
    public float dw;
    #region mb
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
    #endregion
    private Section Section;
    private Relation Relation;
    void OnGUI()
    {
        stModule.file.Class.Открыть();
        //GUILayout.BeginHorizontal();
        Section.Показать();
        Relation.Показать();
        //GUILayout.EndHorizontal();
        //GUILayout.BeginHorizontal();
        //GUILayout.Label("100");
        //GUILayout.EndHorizontal();
    }

    private object GetName<T>(byte номер)
    {
        throw new NotImplementedException();
    }
    private void OnEnable()
    {
       dw= 0.5f * 1200;
       Section = new Section(this);
       Relation = new Relation(this);
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

}