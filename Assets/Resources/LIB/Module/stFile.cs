using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;
using UnityEngine.UI;
using System.Text.RegularExpressions;

static public class stFile
{
    static public string ВытащитьКомментарий(string path)
    {
        if (!File.Exists(path)) return "";
        var sr = new StreamReader(path);
        var line = sr.ReadLine();
        sr.Close();
        return line;
    }
    static public uint НомерФайла(string f)
    {
        f = Path.GetFileNameWithoutExtension(f);
        var i = f.LastIndexOf('.');
        if (i == -1) return 0;
        f = f.Substring(i + 1);
        f = Regex.Replace(f, "[^0-9]", "");
        return f == "" ? 0 : System.Convert.ToUInt32(f);
    }
    static public Color32 Серый = Color.gray;
    static public Color32 Фиолетовый = new Color32(195, 0, 255, 255);
    static public GUIStyle Зелень => Стиль(new Color32(0, 158, 26, 255));
    static public GUIStyle Стиль(Color32 Цвет = default)
    {
        var style = new GUIStyle();
        style.normal.textColor = Цвет;
        style.fontStyle = FontStyle.Bold;
        return style;
    }
    static public GUIStyle СтильИталия(Color32 Цвет = default)
    {
        var style = new GUIStyle();
        style.normal.textColor = Цвет;
        style.fontStyle = FontStyle.BoldAndItalic;
        return style;
    }
    static public GUIStyle Стиль(int w)
    {
        var style = new GUIStyle("box");
        return style;
    }
    public static Color GUI_btn(Rect rect, bool b, string f, Color Цвет, System.Action Relation)
    {
        Цвет = СуществуетАтрибут(f, FileAttributes.Archive, Цвет);
        rect.y += 2;

        rect.width = Path.GetFileName(f).Length * 7;
        //кнопка
        if (GUI.Button(rect, Path.GetFileName(f), b ? СтильИталия(Color.blue) : Стиль(Цвет)))
            stModule.file.Class.ОткрытьФайл(f);

        //open|close
        rect.x = rect.x + rect.width + 2f;
        rect.width = 48;
        var btn = GUI.Button(rect, Цвет == Серый ? "Open!!!" : "CLOSE", Стиль(Цвет == Серый ? Color.gray : Color.red));
        if (btn) Цвет = ИнверсияАтрибутаФайла(f, Цвет);
        //Зависимости
        rect.x = rect.x + rect.width + 10f;
        rect.width = 75;
        if (GUI.Button(rect, "Зависимости", Стиль(Фиолетовый))) Relation();
        return Цвет;
    }
    public static Color СуществуетАтрибут(string f, FileAttributes Attribute, Color Цвет) => СуществуетАтрибут(f, Attribute) ? Цвет : Серый;
    public static Color ИнверсияАтрибутаФайла(string f, Color Цвет) => ИнверсияАтрибутаФайла(f) ? Цвет : Серый;
    public static bool СуществуетАтрибут(string f, FileAttributes Attribute) => СуществуетАтрибут(File.GetAttributes(f), Attribute);
    public static bool СуществуетАтрибут(FileAttributes attributes, FileAttributes Attribute) => (attributes & Attribute) == Attribute;
    public static bool ИнверсияАтрибутаФайла(string f)
    {
        FileAttributes attributes = File.GetAttributes(f);
        var delete = СуществуетАтрибут(attributes, FileAttributes.Archive);
        if (delete)
        {
            // Make the file RW
            attributes = RemoveAttribute(attributes, FileAttributes.Archive);
            File.SetAttributes(f, attributes);
        }
        else
        {
            // Make the file RO
            File.SetAttributes(f, File.GetAttributes(f) | FileAttributes.Archive);
        }
        return !delete;
    }
    private static FileAttributes RemoveAttribute(FileAttributes attributes, FileAttributes attributesToRemove)
    {
        return attributes & ~attributesToRemove;
    }
}
