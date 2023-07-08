//empty
//empty
//empty
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;
using System.Linq;
namespace LIB.go2306252014
{
    public interface IInspector : go2305081120.IInspector
    {
        new IScene СЦЕНА { get; }
    }
    public class Inspector : go2305081120.Inspector, IInspector
    {
        new public IScene СЦЕНА => объектСЦЕНА as IScene;
        public override bool Тест()
        {
            st.Class.fun230624130000_НоваяТрехМернаяАльфаТекстура();
            return false;
        }
        public Inspector()
        {
        }
    }
}
namespace LIB.go2305081120
{
    public interface IEvent
    {
        IInspector ОбъктМира { get; set; }
        bool Выполнить();
    }
    public class MyEvent : Object, IEvent
    {
        private IInspector ObjectWorld;
        public IInspector ОбъктМира
        {
            get => ObjectWorld;
            set => ObjectWorld = value;
        }
        public virtual bool Выполнить()
        {
            return false;
        }
    }
}
namespace LIB.go2305081120
{
    public interface IInspector : go2305082132.IInspector
    {
        cs2307031414_Default.IClass Объект { get; set; }
        IScene СЦЕНА { get; }
    }
    public class Inspector : go2305082132.Inspector, IInspector
    {
        public IScene СЦЕНА => объектСЦЕНА as IScene;
        private object Scene;
        private cs2307031414_Default.IClass _obj; public cs2307031414_Default.IClass Объект { get=> _obj; set=> _obj=value; }
        public object объектСЦЕНА
        {
            get
            {
                if (Scene == null) Scene = st.Class.fun230514161403(this, "Scene");
                return Scene;
            }
        }
        public override bool Выполнить()
        {
            Объект?.ИнтерфейсПоУмолчанию();
            GUILayout.Label("КлассМира=" + this.GetType().ToString());
            return base.Выполнить();
        }
    }
}
namespace LIB.go2305082132
{
    public interface IInspector
    {
    MonoBehaviour Моно { get; set; }
        bool Выполнить();
        T field<T>(ref T val) where T : class, new();
    }
    public class Inspector : object, IInspector
    {
        public Inspector() { }
        public Inspector(MonoBehaviour MB) => this.MB = MB;
        private MonoBehaviour MB;
        public MonoBehaviour Моно
        {
            get => MB;
            set => MB = value;
        }
        #region Выполненение
        public virtual bool Тест() => false;
        public virtual bool Выполнить()
        {
            var btn = GUILayout.Button("test");
            if (btn) this.Тест();
            return btn;
        }
        #endregion
        public virtual T field<T>(ref T val) where T : class, new()
        {
            if (val == null) val = new T();
            return val;
        }
        public virtual T field<T>(ref T val, object[] args) where T : class
        {
            System.Type TestType = typeof(T);
            if (TestType == null) return null;
            var ts = new List<System.Type>();
            foreach (var arg in args) ts.Add(arg.GetType());
            System.Reflection.ConstructorInfo ci = TestType.GetConstructor(ts.ToArray());
            return ci.Invoke(args) as T;
        }
    }
}
namespace LIB.cs2307031414_Default
{
    public interface IClass
    {
        public string ИмяКнопки { get; }
        public void Выполнить() { }
        bool ИнтерфейсПоУмолчанию();
    }
    public class Class : IClass
    {
        static public string INFO = "INFO";
        public virtual string ИмяКнопки => "Выполнить";
        public virtual void Выполнить() { }
        public virtual bool ИнтерфейсПоУмолчанию()
        {
            return st.Class.fun230516115102_btn_name(ИмяКнопки, Выполнить);
        }
    }
}
namespace LIB.cs2305161108
{
    public interface IMono
    {
        uint НомерМира { get; }
        go2305081120.IInspector ОбъектМира { get; set; }
        Object ОбновитьОбъектМира { get; }
    }
    public class Mono : MonoBehaviour, IMono
    {
        [SerializeField]
        public string ID;
        private uint _number;
        public uint НомерМира
        {
            get
            {
                if (_number<1000) _number=(uint)System.Type.GetType("IEditorGUILayoutPopup", false, true).GetField("НомерМира").GetValue("null");
                return _number;
            }
        }
        private go2305081120.IInspector ObjectWorld;
        public bool УжеСуществует => ObjectWorld != null && ObjectWorld.GetType().Name.IndexOf(_number.ToString()) > 0 == true;
        public go2305081120.IInspector ОбъектМира
        {
            get
            {
                if (!УжеСуществует) Object.DestroyImmediate(ObjectWorld as Object);
                return (ObjectWorld == null ? st.Class.fun230514161404(this) : ObjectWorld);
            }
            set => ObjectWorld = value;
        }
        public virtual Object ОбновитьОбъектМира => ОбъектМира as Object;
        public Object ИзменитьМир(uint Number) { _number = Number; return ОбновитьОбъектМира; }
        [CustomEditor(typeof(Mono))]
        public class gui : Editor
        {
            public virtual void OnSceneGUI()
            {
                if (target is IMono)
                {
                    Repaint();
                    ((IMono)target).ОбъектМира?.СЦЕНА.Выполнить();
                }
            }
            public override void OnInspectorGUI()
            {
                if (target is IMono)
                {
                    DrawDefaultInspector();
                    ((IMono)target).ОбъектМира?.Выполнить();
                }
            }
        }
    }
}
namespace LIB.go2305081120
{
    public interface IScene : IEvent
    {
    }
    public class Scene : MyEvent, IScene
    {
        override public bool Выполнить()
        {
            event_MouseKey();
            return false;
        }
        virtual public void event_MouseKey()
        {
            Event e = Event.current;
            int controlID = GUIUtility.GetControlID(FocusType.Passive);
            HandleUtility.AddDefaultControl(controlID);
            switch (e.GetTypeForControl(controlID))
            {
                case EventType.MouseMove:
                    event_MouseMove();
                    break;
                case EventType.MouseUp:
                    event_MouseUp();
                    break;
                case EventType.MouseDown:
                    event_MouseDown();
                    break;
                case EventType.KeyDown:
                    event_KeyDown();
                    break;
                case EventType.KeyUp:
                    event_KeyUp();
                    break;
            }
        }
        #region События Мыши
        virtual public void event_MouseMove()
        {
        }
        virtual public void event_leftMouseUp()
        {
        }
        virtual public void event_rightMouseUp()
        {
        }
        virtual public void event_middleMouseUp()
        {
        }
        virtual public void event_MouseUp()
        {
            switch (Event.current.button)
            {
                case 0:
                    event_leftMouseUp();
                    break;
                case 1:
                    event_rightMouseUp();
                    break;
                case 2:
                    event_middleMouseUp();
                    break;
            }
        }
        virtual public void event_MouseDown()
        {
            switch (Event.current.button)
            {
                case 0:
                    event_leftMouseDown();
                    break;
                case 1:
                    event_rightMouseDown();
                    break;
                case 2:
                    event_middleMouseDown();
                    break;
            }
        }
        virtual public void event_leftCtrlMouseDown()
        {
        }
        virtual public bool event_leftMouseDown()
        {
            if (Event.current.control)
            {
                event_leftCtrlMouseDown();
                return true;
            }
            return false;
        }
        virtual public void event_rightMouseDown()
        {
        }
        virtual public void event_middleMouseDown()
        {
        }
        #endregion
        #region События Клавиатуры
        virtual public void event_KeyDown()
        {
        }
        virtual public void event_KeyUp()
        {
        }
        #endregion
    }
}
namespace LIB.go2306252014
{
public interface IScene:go2305081120.IScene
{
}
public class Scene : go2305081120.Scene, IScene
{
override public bool Выполнить()
{
return base.Выполнить();
}
}
}
namespace LIB.st
{
static public class Class
{
        static public bool fun230516115102_btn_name(string name = "test", System.Action proc = null)
        {
            var b = GUILayout.Button(name);
            if (b)
                proc?.Invoke();
            return b;
        }
        static public object fun230514161403(go2305081120.IInspector INS, string ev)
        {
            var mb = INS.Моно as cs2305161108.IMono;
            var obj = fun230514161402_СоздатьОбъектПоИмени("LIB.go" + mb.НомерМира.ToString() + "." + ev);
            (obj as go2305081120.IEvent).ОбъктМира = INS;
            return obj;
        }
        static public go2305081120.IInspector fun230514161404(cs2305161108.IMono mb)
        {
                var obj = fun230514161402_СоздатьОбъектПоИмени("LIB.go" + mb.НомерМира.ToString() + ".Inspector");
                mb.ОбъектМира = obj as go2305081120.IInspector;
                mb.ОбъектМира.Моно = mb as MonoBehaviour;
                return mb.ОбъектМира;
        }
        static public object fun230514161402_СоздатьОбъектПоИмени(this string name)
        {
            System.Type TestType = System.Type.GetType(name, false, true);
            if (TestType == null) return null;
            System.Reflection.ConstructorInfo ci = TestType.GetConstructor(new System.Type[] { });
            var obj = ci.Invoke(new object[] { });
            return obj;
        }
        static public void fun230624130000_НоваяТрехМернаяАльфаТекстура(int MAX = 8)
        {
            var tex = new Texture3D(MAX, MAX, MAX, TextureFormat.Alpha8, false);
            fun230624130003_SaveTextureToFile(tex, field230624130001_file_test);
            st.Class.fun230626135400_ОткрытьФайл(Path.GetFullPath(field230624130001_file_test));
        }
        static public void fun230624130003_SaveTextureToFile(Texture3D tex, string f)
        {
            AssetDatabase.CreateAsset(tex, f);
        }
        static public string field230624130001_file_test = "Assets/Resources/test/alpha.asset";
        static public void fun230626135400_ОткрытьФайл(this string commandText)
        {
            var proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = commandText;
            proc.StartInfo.UseShellExecute = true;
            proc.Start();
        }
}
}
