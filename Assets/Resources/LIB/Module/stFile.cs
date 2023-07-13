using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;
using UnityEngine.UI;
using System.Text.RegularExpressions;

static public class stFile
{
    static public string �������������������(string path)
    {
        if (!File.Exists(path)) return "";
        var sr = new StreamReader(path);
        var line = sr.ReadLine();
        sr.Close();
        return line;
    }
    static public uint ����������(string f)
    {
        f = Path.GetFileNameWithoutExtension(f);
        var i = f.LastIndexOf('.');
        if (i == -1) return 0;
        f = f.Substring(i + 1);
        f = Regex.Replace(f, "[^0-9]", "");
        return f == "" ? 0 : System.Convert.ToUInt32(f);
    }
    static public Color32 ����� = Color.gray;
    static public Color32 ���������� = new Color32(195, 0, 255, 255);
    static public GUIStyle ������ => �����(new Color32(0, 158, 26, 255));
    static public GUIStyle �����(Color32 ���� = default)
    {
        var style = new GUIStyle();
        style.normal.textColor = ����;
        style.fontStyle = FontStyle.Bold;
        return style;
    }
    static public GUIStyle �����������(Color32 ���� = default)
    {
        var style = new GUIStyle();
        style.normal.textColor = ����;
        style.fontStyle = FontStyle.BoldAndItalic;
        return style;
    }
    static public GUIStyle �����(int w)
    {
        var style = new GUIStyle("box");
        return style;
    }
    public static Color GUI_btn(Rect rect, bool b, string f, Color ����, System.Action Relation)
    {
        ���� = �����������������(f, FileAttributes.Archive, ����);
        rect.y += 2;

        rect.width = Path.GetFileName(f).Length * 7;
        //������
        if (GUI.Button(rect, Path.GetFileName(f), b ? �����������(Color.blue) : �����(����)))
            stModule.file.Class.�����������(f);

        //open|close
        rect.x = rect.x + rect.width + 2f;
        rect.width = 48;
        var btn = GUI.Button(rect, ���� == ����� ? "Open!!!" : "CLOSE", �����(���� == ����� ? Color.gray : Color.red));
        if (btn) ���� = ���������������������(f, ����);
        //�����������
        rect.x = rect.x + rect.width + 10f;
        rect.width = 75;
        if (GUI.Button(rect, "�����������", �����(����������))) Relation();
        return ����;
    }
    public static Color �����������������(string f, FileAttributes Attribute, Color ����) => �����������������(f, Attribute) ? ���� : �����;
    public static Color ���������������������(string f, Color ����) => ���������������������(f) ? ���� : �����;
    public static bool �����������������(string f, FileAttributes Attribute) => �����������������(File.GetAttributes(f), Attribute);
    public static bool �����������������(FileAttributes attributes, FileAttributes Attribute) => (attributes & Attribute) == Attribute;
    public static bool ���������������������(string f)
    {
        FileAttributes attributes = File.GetAttributes(f);
        var delete = �����������������(attributes, FileAttributes.Archive);
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
