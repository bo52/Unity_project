using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;
using UnityEngine.UI;
using System.Text.RegularExpressions;

static public class stFile
{
    static public uint Ќомер‘айла(string f)
    {
        f = Path.GetFileNameWithoutExtension(f);
        var i = f.LastIndexOf('.');
        if (i == -1) return 0;
        f = f.Substring(i+1);
        f = Regex.Replace(f, "[^0-9]", "");
        return f==""?0:System.Convert.ToUInt32(f);
    }
    static public Color32 —ерый = Color.gray;
    static public Color32 ‘иолетовый = new Color32(195, 0, 255, 255);
    static public GUIStyle «елень => —тиль(new Color32(0, 158, 26, 255));
    static public GUIStyle —тиль(Color32 ÷вет = default)
    {
        var style = new GUIStyle();
        style.normal.textColor = ÷вет;
        style.fontStyle = FontStyle.Bold;
        return style;
    }
    static public GUIStyle —тиль(int w)
    {
        var style = new GUIStyle("box");
        return style;
    }
    public static Color GUI_btn(Rect rect, string f, Color ÷вет,System.Action Relation)
    {
        ÷вет = —уществуетјтрибут(f, FileAttributes.Archive, ÷вет);
        rect.y += 2;

        rect.width = Path.GetFileName(f).Length * 7;
        //кнопка
        if (GUI.Button(rect, Path.GetFileName(f), —тиль(÷вет)))
            stModule.file.Class.ќткрыть‘айл(f);

        //open|close
        rect.x = rect.x + rect.width + 2f;
        rect.width = 48;
        var btn = GUI.Button(rect, ÷вет == —ерый ? "Open!!!" : "CLOSE", —тиль(÷вет == —ерый ? Color.gray : Color.red));
        if (btn) ÷вет = »нверси€јтрибута‘айла(f, ÷вет);
        //«ависимости
        rect.x = rect.x + rect.width + 10f;
        rect.width = 75;
        if (GUI.Button(rect, "«ависимости", —тиль(‘иолетовый))) Relation();
        return ÷вет;
    }
    public static Color —уществуетјтрибут(string f, FileAttributes Attribute, Color ÷вет) => —уществуетјтрибут(f, Attribute) ? ÷вет : —ерый;
    public static Color »нверси€јтрибута‘айла(string f, Color ÷вет) => »нверси€јтрибута‘айла(f) ? ÷вет : —ерый;
    public static bool —уществуетјтрибут(string f, FileAttributes Attribute) => —уществуетјтрибут(File.GetAttributes(f), Attribute);
    public static bool —уществуетјтрибут(FileAttributes attributes, FileAttributes Attribute) => (attributes & Attribute) == Attribute;
    public static bool »нверси€јтрибута‘айла(string f)
    {
        FileAttributes attributes = File.GetAttributes(f);
        var delete = —уществуетјтрибут(attributes, FileAttributes.Archive);
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
