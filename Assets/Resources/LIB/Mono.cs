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
        private cs2307051626_ЗЕМЛЯ.IClass ЗЕМЛЯ = new cs2307051626_ЗЕМЛЯ.Class();
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
namespace LIB.cs2307051626_ЗЕМЛЯ
{
    public interface IClass
    {
        static public byte РадиусВидимости = 3;
    }
    public class Class : cs2307051313_Словарь_Ulong.Class<cs2307071139_ЧанкЗемли.IClass>, IClass
    {
        static new public string INFO = "INFO";
        public Class()
        {
            Генерация();
        }
        public void Генерация()
        {
            this.Clear();
            for (var z = -IClass.РадиусВидимости; z <= IClass.РадиусВидимости; z++)
                for (var x = -IClass.РадиусВидимости; x <= IClass.РадиусВидимости; x++)
                {
                    this.ДобавитьЧанк(new Vector2Int(x, z));
                }
        }
        public void ДобавитьЧанк(Vector2Int v)
        {
            var obj = new cs2307071139_ЧанкЗемли.Class(v);
            this.Добавить(v, obj);
            obj.Выполнить();
        }
    }
}
namespace LIB.cs2307051313_Словарь_Ulong
{
    public interface IClass : IDictionary
    {
        void Добавить(Vector3 v, object obj);
        void Добавить(Vector2 v, object obj);
        void Добавить<T>(Vector3 v, T obj) where T : class;
        Vector3 ПолучитьВектор(ulong id);
        Vector2 ПолучитьВЕКТОР(ulong id);
        ulong ПолучитьНомер(Vector3 v);
        void Обойти<T>(System.Func<Vector3, T, bool> Выполнить) where T : class;
        void Обойти(System.Func<ulong, object, bool> Выполнить);
        void Обойти(System.Func<Vector3, object, bool> Выполнить);
        void Очистить();
    }
    public class Class<T> : Dictionary<ulong, T>, IClass where T:class
    {
        static public string INFO = "INFO";
        #region ФункцииКласса
        public void Очистить() => this.Clear();
        public virtual void Добавить(Vector3 v, object obj) => this.Add(ПолучитьНомер(v), (T)obj);
        public virtual void Добавить(Vector2 v, object obj) => this.Add(ПолучитьНомер(v), (T)obj);
        public virtual void Добавить<t>(Vector3 v, t obj) where t:class => this.Add(ПолучитьНомер(v), obj as T);
        public Vector3 ПолучитьВектор(ulong id) => st.Class.fun230521170204_ПолучитьВектор(id);
        public Vector2 ПолучитьВЕКТОР(ulong id) => st.Class.fun230521170207_ПолучитьВектор(id);
        public ulong ПолучитьНомер(Vector3 v) => st.Class.fun230521170203_ПолучитьНомер(v);
        public ulong ПолучитьНомер(Vector2 v) => st.Class.fun230521170206_ПолучитьНомер(v);
        public void Обойти(System.Func<ulong, object, bool> Выполнить)
        {
            foreach (var val in this)
                if (!Выполнить(val.Key, val.Value)) return;
        }
        public void Обойти(System.Func<Vector3, object, bool> Выполнить)
        {
            foreach (var val in this)
                if (!Выполнить(ПолучитьВектор(val.Key), val.Value)) return;
        }
        public void Обойти<t>(System.Func<Vector3, t, bool> Выполнить) where t : class
        {
            foreach (var val in this)
                if (!Выполнить(ПолучитьВектор(val.Key), val.Value as t)) return;
        }
        #endregion
    }
}
namespace LIB.cs2307071139_ЧанкЗемли
{
    public interface IClass : cs2306221522_ЧанкПаралепипеда.IClass
    {
        Vector2Int Координата { get; }
        static int ДлинаЧанкаЗемли = 32;
    }
    public class Class : cs2306221522_ЧанкПаралепипеда.Class, IClass
    {
        static new public string INFO = "INFO";
        private Vector2Int _v; public Vector2Int Координата => _v;
        public virtual Vector3 ВычисляемыеКоординаты => IClass.ДлинаЧанкаЗемли * new Vector3(_v.x, 0, _v.y);
        public override string ИмяИгровогоОбъекта => base.ИмяИгровогоОбъекта + _v.x + "_" + _v.y;
        public override GameObject НовыйИгровойОбъект
        {
            get
            {
                var go = base.НовыйИгровойОбъект;
                go.transform.position = ВычисляемыеКоординаты;
                var mb = st.Class.fun230514161407_ПривязатьМоноКОбъекту(go);
                mb.ОбъектМира.Объект = this;
                return go;
            }
        }
        public Class(Vector2Int v)
        {
            _v = v;
        }
    }
}
namespace LIB.cs2306221522_ЧанкПаралепипеда
{
    public interface IClass : cs2307061242_СловарныйЧанк.IClass
    {
    }
    public class Class : cs2307061242_СловарныйЧанк.Class, IClass
    {
        static new public string INFO = "INFO";
        public override string ИмяКнопки => "ПостроитьЧанкПаралепипед";
        #region ПараметрыКласса
        private cs2306271146_РедакторПаралепипеда.IClass РедакторПаралепипеда = new cs2306271146_РедакторПаралепипеда.Class();
        public override string ИмяИгровогоОбъекта => "ЧанкПаралепипед";
        public Class() : base()
        {
        }
        #endregion
        public override bool ИнтерфейсПоУмолчанию()
        {
            if (РедакторПаралепипеда.ИнтерфейсПоУмолчанию()) Выполнить();
            return base.ИнтерфейсПоУмолчанию();
        }
        public override bool СуществуетВершина(Vector3 v) => РедакторПаралепипеда.СуществуетВершина(v);
    }
}
namespace LIB.cs2307061242_СловарныйЧанк
{
    public interface IClass : cs2305071643_Chunk_default.IClass
    {
        static public byte РазмерЧанка = 32;
        static public byte ГраничныйРазмерЧанка = 30;
        static public byte ПоловинаРазмераЧанка = 14;
        cs2307061139_КораЧанка.IClass КораЧанка { get; }
        cs2307061149_БлокиЧанка.IClass БлокиЧанка { get; }
    }
    public abstract class Class : cs2305071643_Chunk_default.Class, IClass
    {
        static new public string INFO = "INFO";
        private cs2307061139_КораЧанка.IClass _crust = new cs2307061139_КораЧанка.Class(); public cs2307061139_КораЧанка.IClass КораЧанка => _crust;
        public cs2307061149_БлокиЧанка.IClass _btns = new cs2307061149_БлокиЧанка.Class(); public cs2307061149_БлокиЧанка.IClass БлокиЧанка => _btns;
        public Class() : base()
        {
        }
        public override Mesh ПостроитьСЗакрытием()
        {
            СформироватьСловарьЧанка();
            return base.ПостроитьСЗакрытием();
        }
        public override void ФункцияПостройки(cs2305141215.IClass edit)
        {
            _crust.Обойти((Vector3 v, cs2307051205_ЦветнойКодБлока.Class b) =>
            {
                edit.ДОБАВИТЬ(new cs2306262134.Class(v, b.КОД));
                return true;
            });
        }
        public void СформироватьСловарьЧанка()
        {
            _crust.Clear();
            _btns.Clear();
            Vector3 v;
            byte КОД;
            for (var x = 0; x < IClass.РазмерЧанка; x++)
                for (var y = 0; y < IClass.РазмерЧанка; y++)
                    for (var z = 0; z < IClass.РазмерЧанка; z++)
                    {
                        v = new Vector3(x, y, z);
                        КОД = st.Class.fun230627120900_СформироватьКодБлока(v, СуществуетВершина);
                        if (КОД == 0) continue;
                        if (КОД == byte.MaxValue)
                            _btns.Добавить(v);
                        else
                            _crust.Добавить(v, КОД);
                    }
        }
        public abstract bool СуществуетВершина(Vector3 v);
    }
}
namespace LIB.cs2305071643_Chunk_default
{
    public interface IClass : cs2307031414_Default.IClass
    {
        GameObject ИгровойОбъект { get; }
        cs2305141208.IClass.Редактор ТипРедактора { get; }
        Mesh ПостроитьСЗакрытием();
        void ФункцияПостройки(cs2305141215.IClass edit);
        GameObject НовыйИгровойОбъект { get; }
    }
    public abstract class Class : cs2307031414_Default.Class, IClass
    {
        static new public string INFO = "INFO";
        public override string ИмяКнопки => "ПостроитьБезСохранения";
        public virtual string ИмяИгровогоОбъекта => "empty";
        private GameObject _go;
        public virtual GameObject НовыйИгровойОбъект => st.Class.prop230625163904_НовыйОбъектВКорнеМира(ИмяИгровогоОбъекта);
        public virtual GameObject ИгровойОбъект
        {
            get
            {
                if (_go == null)
                {
                    _go = GameObject.Find(ИмяИгровогоОбъекта);
                    if (_go == null)
                    {
                        _go = НовыйИгровойОбъект;
                    }
                }
                return _go;
            }
        }
        public void СохранитьЧанк() => st.Class.fun230516171601_ПереСохранитьМешОбъекта(ИгровойОбъект);
        public Class()
        {
        }
        public virtual cs2305141208.IClass.Редактор ТипРедактора => cs2305141208.IClass.Редактор.Block;
        private cs2307031203_ПараметрыПостройки.Class _param_build => new cs2307031203_ПараметрыПостройки.Class(ФункцияПостройки, ТипРедактора);
        public virtual Mesh ПостроитьСЗакрытием() => new cs2306291123.Class(ИгровойОбъект, _param_build).Закрыть();
        public override void Выполнить() => ПостроитьСЗакрытием();
        public abstract void ФункцияПостройки(cs2305141215.IClass edit);
        public override bool ИнтерфейсПоУмолчанию()
        {
            GUILayout.BeginHorizontal();
            st.Class.fun230516115102_btn_name("СохранитьЧанк", СохранитьЧанк);
            base.ИнтерфейсПоУмолчанию();
            GUILayout.EndHorizontal();
            return true;
        }
    }
}
namespace LIB.cs2305141208
{
    public interface IClass
    {
        public enum Редактор { empty, Block, square, triangle };
        cs2305141215.IClass Editor { get; }
        Mesh ПолучитьМеш();
        Mesh Закрыть();
    }
    public class Class : IClass
    {
        private cs2305141215.IClass _editor; public cs2305141215.IClass Editor => _editor;
        public Class(cs2307031203_ПараметрыПостройки.Class Параметры)
        {
            switch (Параметры.НомерРедактора)
            {
                case 1:
                    _editor = new cs2306291643.Class(Параметры);
                    break;
                case 2:
                    _editor = new cs2306301310.Class(Параметры);
                    break;
                case 3:
                    _editor = new cs2305141209.Class(Параметры);
                    break;
            }
        }
        public virtual Mesh Закрыть()
        {
            _editor.ФункцияПостройки();
            return ПолучитьМеш();
        }
        public Mesh ПолучитьМеш()
        {
            var M = new Mesh();
            M.vertices = _editor.vs.ToArray();
            var uvs = (_editor as cs2305141222.IClass);
            M.uv = uvs.Развёртка[0].ToArray();
            M.uv2 = uvs.Развёртка[1].ToArray();
            M.uv3 = uvs.Развёртка[2].ToArray();
            M.uv4 = uvs.Развёртка[3].ToArray();
            M.uv5 = uvs.Развёртка[4].ToArray();
            M.uv6 = uvs.Развёртка[5].ToArray();
            M.uv7 = uvs.Развёртка[6].ToArray();
            M.uv8 = uvs.Развёртка[7].ToArray();
            M.triangles = _editor.ts.ToArray();
            M.normals = _editor.ns.ToArray();
            M.RecalculateNormals();
            M.RecalculateBounds();
            _editor.Очистить();
            return M;
        }
    }
}
namespace LIB.cs2305141215
{
    public interface IClass : cs2305141222.IClass
    {
        void ДОБАВИТЬ(object arg);
        void ДОБАВИТЬ(object[] args);
        List<Vector3> vs { get; }
        List<int> ts { get; }
        List<Vector3> ns { get; }
        public void ДобавитьВершину(Vector3 v);
        public new void Очистить()
        {
            vs.Clear();
            ts.Clear();
            ns.Clear();
            (this as cs2305141222.IClass).Очистить();
        }
        void ФункцияПостройки();
        cs2307031203_ПараметрыПостройки.Class ПараметрыПостройки { get; }
    }
    public abstract class Class : cs2305141222.Class, IClass
    {
        private cs2307031203_ПараметрыПостройки.Class _param; public cs2307031203_ПараметрыПостройки.Class ПараметрыПостройки => _param;
        public void ФункцияПостройки() => _param.ФункцияПостройки(this);
        public Class(cs2307031203_ПараметрыПостройки.Class param)
        {
            _param = param;
        }
        private List<Vector3> _vs = new List<Vector3>(); public List<Vector3> vs => _vs;
        private List<int> _ts = new List<int>(); public List<int> ts => _ts;
        private List<Vector3> _ns = new List<Vector3>(); public List<Vector3> ns => _ns;
        public void ДобавитьВершину(Vector3 v)
        {
            vs.Add(v);
            ts.Add(vs.Count - 1);
            ns.Add(v.normalized);
            ТреугольникВерстки(this);
        }
        public void ДОБАВИТЬ(object[] args)
        {
            System.Reflection.MethodBase ci = this.GetType().GetMethod("ADD", (from x in args select x.GetType()).ToArray());
            ci.Invoke(this, args);
        }
        public void ДОБАВИТЬ(object arg) => ДОБАВИТЬ(new object[] { arg });
    }
}
namespace LIB.cs2305141222
{
    public interface IClass
    {
        System.Func<cs2305141215.IClass, Vector2[]> ФункцияВерстки { get; set; }
        List<Vector2>[] Развёртка { get; }
        void ТреугольникВерстки(cs2305141215.IClass Редактор);
        void Очистить();
    }
    public class Class
    {
        private List<Vector2>[] _uv = new List<Vector2>[8]
        {
            new List<Vector2>(),
            new List<Vector2>(),
            new List<Vector2>(),
            new List<Vector2>(),
            new List<Vector2>(),
            new List<Vector2>(),
            new List<Vector2>(),
            new List<Vector2>(),
        };
        public List<Vector2>[] Развёртка => _uv;
        private System.Func<cs2305141215.IClass, Vector2[]> fun; public System.Func<cs2305141215.IClass, Vector2[]> ФункцияВерстки { get => fun; set => fun = value; }
        public virtual void ТреугольникВерстки(cs2305141215.IClass Редактор)
        {
            Vector2[]arr;
            if (ФункцияВерстки != null) arr = ФункцияВерстки(Редактор); else
            {
                switch (Редактор.ПараметрыПостройки.НомерРедактора)
                {
                    case 1:
                        arr = st.Class.fun230626171800_ВерсткаБлока(Редактор as cs2306291643.Class);
                        break;
                    default:
                        arr=new Vector2[8] { Vector2.zero, Vector2.zero, Vector2.zero, Vector2.zero, Vector2.zero, Vector2.zero, Vector2.zero, Vector2.zero };
                        break;
                }
            }
            for (int i = 0; i < arr.Length; i++)
                Развёртка[i].Add(arr[i]);
        }
        public virtual void Очистить()
        {
            for (var i = 0; i < Развёртка.Length; i++)
                Развёртка[i].Clear();
        }
    }
}
namespace LIB.cs2306291643
{
    public interface IClass
    {
        cs2306262134.Class ТекущийБлок { get; set; }
        void ADD(cs2306262134.Class b);
    }
    public class Class : cs2305141209.Class, IClass
    {
        static public string INFO = "INFO";
        public Class(cs2307031203_ПараметрыПостройки.Class param) : base(param)
        {
        }
        private cs2306262134.Class _b;
        public cs2306262134.Class ТекущийБлок { get => _b; set => _b = value; }
        public virtual Vector3 ВычислениеВектора(Vector3 dv) => ТекущийБлок.Центр + dv;
        public virtual Vector3 ВычислениеВектора(ushort ИндексУникальногоТреугольника, byte i) => ВычислениеВектора(ТочкаУникальногоТреугольника(ИндексУникальногоТреугольника, i));
        static public Vector3 ВычислениеВектора(byte ИндексВершины, byte НомерОсиБлока)
        {
            var v = st.Class.fun230515154302_ВекторВершиныПоЦентруКуба(ИндексВершины);
            if (НомерОсиБлока != byte.MaxValue)
                v += 0.5f * st.Class.field230514115900_ВекторПоТремОсям[НомерОсиБлока];
            return v;
        }
        static public Vector3 ТочкаУникальногоТреугольника(ushort ИндексУникальногоТреугольника, byte НомерОси)
        {
            var НомерГрани = st.Class.fun230514115300_НомерГраниКуба(ИндексУникальногоТреугольника, НомерОси);
            return ВычислениеВектора(st.Class.field230514115901_НомерВершиныКубаПоНомеруГрани[НомерГрани, 0], st.Class.field230514115901_НомерВершиныКубаПоНомеруГрани[НомерГрани, 1]);
        }
        public void ADD(cs2306262134.Class b)
        {
            if (b.Код == 0) return;
            ТекущийБлок = b;
            Vector3 v1, v2, v3;
            foreach (var ИндексУникальногоТреугольника in st.Class.field230514131500_БлокИзТреугольников[ТекущийБлок.Код])
            {
                v1 = ВычислениеВектора(ИндексУникальногоТреугольника, 0);
                v2 = ВычислениеВектора(ИндексУникальногоТреугольника, 1);
                v3 = ВычислениеВектора(ИндексУникальногоТреугольника, 2);
                ADD(new cs2306301359.Class(v1, v2, v3));
            }
        }
    }
}
namespace LIB.cs2306262134
{
    public struct Class
    {
        static public string INFO = "INFO";
        public byte Код;
        public Vector3 Центр;
        public Class(Vector3 ЦентрБлока, byte КодВершиныБлока)
        {
            this.Центр = ЦентрБлока;
            this.Код = КодВершиныБлока;
        }
    }
}
namespace LIB.cs2305141209
{
    public interface IClass : cs2305141215.IClass
    {
        void ADD(cs2306301359.Class Triangle);
    }
    public class Class : cs2305141215.Class, IClass
    {
        cs2305141202.IClass ВершиныТреугольника;
        public Class(cs2307031203_ПараметрыПостройки.Class param) : base(param)
        {
            ВершиныТреугольника = new cs2305141202.Class(this);
        }
        public void ADD(cs2306301359.Class Triangle)
        {
            ВершиныТреугольника.v1 = Triangle.v1;
            ВершиныТреугольника.v2 = Triangle.v2;
            ВершиныТреугольника.v3 = Triangle.v3;
            ВершиныТреугольника.ДобавитьТреугольник();
        }
    }
}
namespace LIB.cs2306301359
{
    public struct Class
    {
        static public string INFO = "INFO";
        public Vector3 v1;
        public Vector3 v2;
        public Vector3 v3;
        public Class(Vector3 v1, Vector3 v2, Vector3 v3)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
        }
    }
}
namespace LIB.cs2305141202
{
    public interface IClass
    {
        cs2305141215.IClass Редактор { get; }
        Vector3 v1 { get; set; }
        Vector3 v2 { get; set; }
        Vector3 v3 { get; set; }
        void ДобавитьТреугольник();
    }
    public class Class : IClass
    {
        private cs2305141215.IClass _edit; public cs2305141215.IClass Редактор => _edit;
        private Vector3 _v1 = Vector3.zero; public Vector3 v1 { get => _v1; set => _v1 = value; }
        private Vector3 _v2 = Vector3.right; public Vector3 v2 { get => _v2; set => _v2 = value; }
        private Vector3 _v3 = Vector3.forward; public Vector3 v3 { get => _v3; set => _v3 = value; }
        public Class(cs2305141215.IClass edit)
        {
            this._edit = edit;
        }
        public Class(cs2305141215.IClass edit, cs2306301359.Class ВершиныТреугольника)
        {
            this._edit = edit;
            this.v1 = ВершиныТреугольника.v1;
            this.v2 = ВершиныТреугольника.v2;
            this.v3 = ВершиныТреугольника.v3;
        }
        public void ДобавитьТреугольник()
        {
            Редактор.ДобавитьВершину(v1);
            Редактор.ДобавитьВершину(v2);
            Редактор.ДобавитьВершину(v3);
        }
    }
}
namespace LIB.cs2307031203_ПараметрыПостройки
{
    public struct Class
    {
        static public string INFO = "INFO";
        public System.Action<cs2305141215.IClass> ФункцияПостройки;
        public byte НомерРедактора;
        public Class(System.Action<cs2305141215.IClass> ФункцияПостройки, byte НомерРедактора = 1)
        {
            this.ФункцияПостройки = ФункцияПостройки;
            this.НомерРедактора = НомерРедактора;
        }
        public Class(System.Action<cs2305141215.IClass> ФункцияПостройки, cs2305141208.IClass.Редактор Редактор)
        {
            this.ФункцияПостройки = ФункцияПостройки;
            this.НомерРедактора = (byte)Редактор;
        }
    }
}
namespace LIB.cs2306301310
{
    public interface IClass: cs2305141215.IClass
    {
        public void ADD(cs2306301359.Class Triangle, Vector3 v4);
    }
    public class Class : cs2305141215.Class, IClass
    {
        static public string INFO = "INFO";
        private cs2305181555.IClass ВершиныКвадрата;
        public Class(cs2307031203_ПараметрыПостройки.Class param) : base(param)
        {
            ВершиныКвадрата = new cs2305181555.Class(this);
        }
        public void ADD(cs2306301359.Class Triangle,Vector3 v4)
        {
            ВершиныКвадрата.v1 = Triangle.v1;
            ВершиныКвадрата.v2 = Triangle.v2;
            ВершиныКвадрата.v3 = Triangle.v3;
            ВершиныКвадрата.v4 = v4;
            ВершиныКвадрата.ДобавитьКвадрат();
        }
        public void Интерфейс()
        {
        }
    }
}
namespace LIB.cs2305181555
{
    public interface IClass: cs2305141202.IClass
    {
        Vector3 v4 { get; set; }
        void ДобавитьКвадрат();
    }
    public class Class : cs2305141202.Class, IClass
    {
        private Vector3 _v4 = Vector3.forward; public Vector3 v4 { get => _v4; set => _v4 = value; }
        public Class(cs2305141215.IClass edit) : base(edit)
        {
        }
        public Class(cs2305141215.IClass edit, cs2306301359.Class Triangle, Vector3 v4) : base(edit, Triangle)
        {
            _v4 = v4;
        }
        public void ДобавитьОбратныйТреугольник()
        {
            Редактор.ДобавитьВершину(v2);
            Редактор.ДобавитьВершину(v4);
            Редактор.ДобавитьВершину(v3);
        }
        public void ДобавитьКвадрат()
        {
            ДобавитьТреугольник();
            ДобавитьОбратныйТреугольник();
        }
    }
}
namespace LIB.cs2306291123
{
    public interface IClass : cs2305141208.IClass
    {
        GameObject GO { get; }
    }
    public class Class : cs2305141208.Class, IClass
    {
        static public string INFO = "INFO";
        private GameObject _go; public GameObject GO => _go;
        public Class(GameObject go, cs2307031203_ПараметрыПостройки.Class param_build) : base(param_build) => this._go = go;
        public Mesh Привязать(GameObject go)
        {
            var M = base.Закрыть();
            st.Class.fun230507204600_ПривязатьМешКОбъекту(M, go);
            return M;
        }
        public override Mesh Закрыть() => Привязать(GO);
    }
}
namespace LIB.cs2307061139_КораЧанка
{
    public interface IClass: cs2307051313_Словарь_Ulong.IClass
    {
        void Добавить(Vector3 v, byte КОД);
    }
    public class Class : cs2307051313_Словарь_Ulong.Class<cs2307051205_ЦветнойКодБлока.Class>, IClass
    {
        static new public string INFO = "INFO";
        public void Добавить(Vector3 v, byte КОД)
        {
            var b = new cs2307051205_ЦветнойКодБлока.Class(КОД);
            this.Добавить(v, b);
        }
    }
}
namespace LIB.cs2307051205_ЦветнойКодБлока
{
    public interface IClass : cs2307061154_ЦветнойБлок.IClass
    {
        public byte КОД { get; set; }
    }
    public class Class: cs2307061154_ЦветнойБлок.Class, IClass
    {
        static new public string INFO = "INFO";
        private byte _code; public byte КОД { get => _code; set => _code = value; }
        public Color32 c;
        public Class(byte КОД, Color32 c):base(c)
        {
            this.КОД = КОД;
        }
        public Class(byte КОД) : base()
        {
            this.КОД = КОД;
        }
    }
}
namespace LIB.cs2307061154_ЦветнойБлок
{
    public interface IClass
    {
        static Color32 Green = new Color32(211, 151, 0, 255);
        public Color32 Цвет { get; set; }
    }
    public class Class : IClass
    {
        static public string INFO = "INFO";
        private Color32 _c = IClass.Green; public Color32 Цвет { get => _c; set => _c = value; }
        public Class()
        {
        }
        public Class(Color32 c)
        {
            this._c = c;
        }
    }
}
namespace LIB.cs2307061149_БлокиЧанка
{
    public interface IClass: cs2307051313_Словарь_Ulong.IClass
    {
        void Добавить(Vector3 v);
    }
    public class Class : cs2307051313_Словарь_Ulong.Class<cs2307061154_ЦветнойБлок.Class>, IClass
    {
        static new public string INFO = "INFO";
        public virtual void Добавить(Vector3 v)=>base.Добавить(v, new cs2307061154_ЦветнойБлок.Class());
    }
}
namespace LIB.cs2306271146_РедакторПаралепипеда
{
    public interface IClass
    {
        public static int R = cs2307061242_СловарныйЧанк.IClass.РазмерЧанка;
        bool СуществуетВершина(Vector3 v);
        bool ИнтерфейсПоУмолчанию();
        cs2307071130_ВысотаПаралепипеда.IClass H { get; }
    }
    public class Class: IClass
    {
        cs2307071119_ВекторПаралепипеда.IClass D = new cs2307071119_ВекторПаралепипеда.Class("ДЛИННА");
        cs2307071119_ВекторПаралепипеда.IClass W = new cs2307071119_ВекторПаралепипеда.Class("ШИРИНА");
        cs2307071130_ВысотаПаралепипеда.IClass _H = new cs2307071130_ВысотаПаралепипеда.Class(); public cs2307071130_ВысотаПаралепипеда.IClass H => _H;
        static public string INFO = "INFO";
        public Class()
        {
            ИзменитьНастройки.Add("ПоУмолчанию", () => {
                D.Левая = 0;
                D.Правая = 0;
                W.Левая = 0;
                W.Правая = 0;
                H.Высота = 1;
            });
        }
        private Dictionary<string, System.Action> ИзменитьНастройки = new Dictionary<string, System.Action>();
        public bool ПоказатьИзменитьНастройки()
        {
            var b = false;
            GUILayout.BeginHorizontal();
            foreach (var val in ИзменитьНастройки)
            {
                st.Class.fun230516115102_btn_name(val.Key, () =>
                {
                    val.Value();
                    b = true;
                });
            }
            GUILayout.EndHorizontal();
            return b;
        }
        public bool СуществуетВершина(Vector3 v)
        {
            if (v.x > IClass.R - D.Правая || v.x < D.Левая) return false;
            if (v.z > IClass.R - W.Правая || v.z < W.Левая) return false;
            if (v.y > H.Высота + 1) return false;
            return true;
        }
        public bool ИнтерфейсПоУмолчанию()
        {
            GUILayout.BeginVertical();
            var b0 = ПоказатьИзменитьНастройки();
            var b1 = H.Показать();
            var b2 = D.Показать();
            var b3 = W.Показать();
            GUILayout.EndVertical();
            return b0 || b1 || b2 || b3;
        }
    }
}
namespace LIB.cs2307071130_ВысотаПаралепипеда
{
    public interface IClass
    {
        int Высота { get; set; }
        bool Показать(System.Action<Vector3> fun = null);
    }
    public class Class : IClass
    {
        static public string INFO = "INFO";
        private int _h = 1; public int Высота { get => _h; set => _h = value; }
        public bool Показать(System.Action<Vector3> fun = null) => st.Class.fun230514135400_slider_int(ref _h, "Высота", 1, cs2307061242_СловарныйЧанк.IClass.ГраничныйРазмерЧанка);
    }
}
namespace LIB.cs2307071119_ВекторПаралепипеда
{
    public interface IClass
    {
        public static int R = cs2307061242_СловарныйЧанк.IClass.РазмерЧанка;
        public static int r = (int)(0.5f * R - 1);
        int Левая { get; set; }
        int Правая { get; set; }
        bool Показать(System.Action<Vector3> fun = null);
    }
    public class Class : IClass
    {
        static public string INFO = "INFO";
        private bool Развернуть = false;
        private Vector2 _v; 
        public int Левая { get => (int)_v.x; set => _v.x = value; }
        public int Правая { get => (int)_v.y; set => _v.y = value; }
        private string name_x = "x";
        private string name_z = "z";
        private int x_min = 0;
        private int z_min = 0;
        private int x_max = 100;
        private int z_max = 100;
        private string header = "Вектор";
        public Class(string header)
        {
            this.header = header;
            x_min = 0;
            name_x = "x=левая " + header;
            name_z = "z=правая " + header;
            z_min = 0;
            x_max = IClass.r;
            z_max = IClass.r;
        }
        public bool Показать(System.Action<Vector3> fun = null)
        {
            var b = false;
            var v = _v;
            st.Class.fun230516124600(() =>
            {
                var x = (int)v.x;
                var z = (int)v.y;
                GUILayout.BeginVertical();
                var X = st.Class.fun230514135400_slider_int(ref x, name_x, x_min, x_max);
                var Z = st.Class.fun230514135400_slider_int(ref z, name_z, z_min, z_max);
                GUILayout.EndVertical();
                if (X || Z)
                {
                    v = new Vector3(x, z);
                    b = true;
                    return;
                }
                b = false;
            }, header, ref Развернуть);
            if (b)
            {
                _v = v;
                fun?.Invoke(v);
            }
            return b;
        }
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
        static public Vector3 fun230521170204_ПолучитьВектор(this ulong id)
        {
            ulong z = id / field230521170202;
            ulong y = (id - field230521170202 * z) / field230521170201;
            ulong x = id - field230521170201 * y - field230521170202 * z;
            return new Vector3(x, y, z) - field230521170200 * Vector3.one;
        }
        static private ulong field230521170202 = 513 * 513;
        static private ulong field230521170201 = 513;
        static private ulong field230521170200 = 256;
        static public Vector2 fun230521170207_ПолучитьВектор(this ulong id)
        {
            ulong y = id / field230521170201;
            ulong x = id - field230521170201 * y;
            return new Vector2(x, y) - field230521170200 * Vector2.one;
        }
        static public ulong fun230521170203_ПолучитьНомер(this Vector3 v) => fun230521170206_ПолучитьНомер(new Vector2(v.x, v.y)) + field230521170202 * (ulong)(v.z + field230521170200);
        static public ulong fun230521170206_ПолучитьНомер(this Vector2 v) => (ulong)(v.x + field230521170200) + field230521170201 * (ulong)(v.y + field230521170200);
        static public Vector2[] fun230626171800_ВерсткаБлока(this cs2306291643.IClass Редактор)
        {
            return new Vector2[8]
            {
                Vector2.zero,
                new Vector2(Редактор.ТекущийБлок.Центр.x,Редактор.ТекущийБлок.Центр.y),
                new Vector2(Редактор.ТекущийБлок.Центр.z,Редактор.ТекущийБлок.Код),
                Vector2.zero,
                Vector2.zero,
                Vector2.zero,
                Vector2.zero,
                Vector2.zero,
            };
        }
        static public Vector3 fun230515154302_ВекторВершиныПоЦентруКуба(byte ИндексВершины)
        {
            return field230515154300_ВекторОтЦентраКубаПоНомеруВершины[ИндексВершины] - 0.5f * Vector3.one;
        }
        static public readonly Vector3[] field230515154300_ВекторОтЦентраКубаПоНомеруВершины = new Vector3[]
        {
            Vector3.zero,//0
            Vector3.right,//1
            Vector3.up,//2
            Vector3.right+Vector3.up,//3
            Vector3.forward,//4
            Vector3.right+Vector3.forward,//5
            Vector3.up+Vector3.forward,//6
            Vector3.right+Vector3.up+Vector3.forward,//7
        };
        static public readonly Vector3[] field230514115900_ВекторПоТремОсям = new Vector3[3]
        {
            Vector3.right,
            Vector3.up,
            Vector3.forward
        };
        static public byte fun230514115300_НомерГраниКуба(this ushort ИндексУникальногоТреугольника, byte НомерОси) => field230514115301[ИндексУникальногоТреугольника, НомерОси];
        public static readonly byte[,] field230514115301 = new byte[300, 3]
        {
        {0,2,4},//0
        {0,6,3},//1
        {2,4,3},//2
        {3,4,6},//3
        {1,5,2},//4
        {0,1,4},//5
        {1,5,4},//6
        {4,1,5},//7
        {4,3,1},//8
        {4,6,3},//9
        {1,3,7},//10
        {0,7,1},//11
        {0,6,7},//12
        {1,2,7},//13
        {4,6,7},//14
        {4,7,2},//15
        {2,3,5},//16
        {3,7,5},//17
        {0,3,4},//18
        {3,5,4},//19
        {0,6,2},//20
        {2,7,5},//21
        {2,6,7},//22
        {4,7,5},//23
        {4,10,8},//24
        {0,2,10},//25
        {0,10,8},//26
        {2,8,3},//27
        {6,3,8},//28
        {2,10,8},//29
        {0,1,8},//30
        {1,5,10},//31
        {1,10,8},//32
        {1,6,3},//33
        {1,8,6},//34
        {1,5,8},//35
        {5,10,8},//36
        {0,6,1},//37
        {1,6,7},//38
        {2,8,7},//39
        {8,6,7},//40
        {2,3,7},//41
        {3,5,10},//42
        {0,3,10},//43
        {0,5,2},//44
        {0,7,5},//45
        {6,7,8},//46
        {8,7,10},//47
        {5,10,7},//48
        {6,8,11},//49
        {0,8,3},//50
        {3,8,11},//51
        {3,4,8},//52
        {1,4,8},//53
        {1,8,3},//54
        {0,8,1},//55
        {1,8,7},//56
        {7,8,11},//57
        {2,4,1},//58
        {1,4,11},//59
        {1,11,7},//60
        {4,8,11},//61
        {0,5,4},//62
        {0,3,7},//63
        {0,7,2},//64
        {0,11,7},//65
        {0,8,11},//66
        {4,8,5},//67
        {5,8,7},//68
        {8,11,7},//69
        {4,10,6},//70
        {6,10,11},//71
        {0,10,11},//72
        {0,11,6},//73
        {0,4,10},//74
        {0,10,3},//75
        {3,10,11},//76
        {2,11,3},//77
        {2,10,11},//78
        {4,10,11},//79
        {4,11,6},//80
        {0,1,6},//81
        {6,1,11},//82
        {1,5,11},//83
        {5,10,11},//84
        {1,11,3},//85
        {1,10,11},//86
        {0,10,6},//87
        {1,2,10},//88
        {1,10,7},//89
        {7,10,11},//90
        {0,3,6},//91
        {0,4,11},//92
        {5,9,10},//93
        {1,9,2},//94
        {2,9,10},//95
        {1,9,10},//96
        {0,10,4},//97
        {0,1,10},//98
        {1,4,3},//99
        {1,10,4},//100
        {1,2,4},//101
        {1,4,6},//102
        {2,3,10},//103
        {3,9,10},//104
        {3,7,9},//105
        {4,7,10},//106
        {7,9,10},//107
        {0,7,4},//108
        {0,10,2},//109
        {0,6,10},//110
        {6,7,10},//111
        {4,6,10},//112
        {4,9,8},//113
        {4,5,9},//114
        {0,2,5},//115
        {0,5,8},//116
        {5,9,8},//117
        {2,8,6},//118
        {2,5,8},//119
        {2,6,3},//120
        {1,4,2},//121
        {1,8,4},//122
        {1,9,8},//123
        {0,1,9},//124
        {0,9,8},//125
        {0,4,2},//126
        {0,2,8},//127
        {1,2,5},//128
        {7,9,8},//129
        {2,7,9},//130
        {2,9,4},//131
        {0,7,9},//132
        {6,9,8},//133
        {6,7,9},//134
        {1,10,2},//135
        {1,9,4},//136
        {4,9,10},//137
        {1,9,3},//138
        {3,9,11},//139
        {4,8,10},//140
        {7,9,11},//141
        {1,8,10},//142
        {1,10,5},//143
        {2,8,10},//144
        {2,3,8},//145
        {3,6,8},//146
        {0,8,10},//147
        {4,9,11},//148
        {0,2,11},//149
        {2,5,11},//150
        {5,9,11},//151
        {0,4,5},//152
        {0,5,3},//153
        {3,5,11},//154
        {2,5,3},//155
        {1,9,11},//156
        {1,11,4},//157
        {1,11,6},//158
        {1,6,0},//159
        {4,5,6 },//160
        {5,9,6},//161
        {6,9,11},//162
        {0,4,1},//163
        {1,4,5},//164
        {2,3,4},//165
        {3,6,4},//166
        {7,11,9},//167
        {2,4,6},//168
        {1,3,9},//169
        {3,11,9},//170
        {1,11,9},//171
        {6,11,1},//172
        {1,2,6},//173
        {1,6,9},//174
        {6,11,9},//175
        {3,9,5},//176
        {0,3,5},//177
        {3,11,5},//178
        {5,11,9},//179
        {0,6,11},//180
        {0,11,2},//181
        {2,11,5},//182
        {4,6,5},//183
        {5,6,9},//184
        {2,10,3},//185
        {3,10,9},//186
        {3,9,7},//187
        {6,11,8},//188
        {2,1,5},//189
        {5,10,9},//190
        {1,7,3},//191
        {1,10,9},//192
        {0,3,8},//193
        {3,11,8},//194
        {1,4,10},//195
        {8,6,11},//196
        {6,8,7},//197
        {7,8,9},//198
        {3,8,9},//199
        {2,4,8},//200
        {3,8,7},//201
        {0,8,7},//202
        {0,7,3},//203
        {5,8,9},//204
        {1,8,9},//205
        {1,6,8},//206
        {1,3,6},//207
        {0,9,1},//208
        {0,8,9},//209
        {4,8,9},//210
        {1,4,9},//211
        {4,9,5},//212
        {0,8,5},//213
        {6,10,7},//214
        {7,10,9},//215
        {9,7,10},//216
        {3,10,7},//217
        {1,7,6},//218
        {6,10,9},//219
        {0,10,1},//220
        {2,6,4},//221
        {2,3,6},//222
        {5,7,10},//223
        {7,11,10},//224
        {5,11,10},//225
        {5,7,11},//226
        {3,5,7},//227
        {6,11,10},//228
        {1,11,10},//229
        {1,7,11},//230
        {2,11,10},//231
        {1,3,10},//232
        {3,11,10},//233
        {0,11,10},//234
        {0,3,11},//235
        {0,11,4},//236
        {4,11,10},//237
        {4,6,11},//238
        {4,5,8},//239
        {5,7,8},//240
        {7,11,8},//241
        {5,8,2},//242
        {0,4,3},//243
        {3,4,5},//244
        {2,5,7},//245
        {2,7,3},//246
        {1,7,8},//247
        {0,1,7},//248
        {0,7,8},//249
        {1,11,8},//250
        {1,3,11},//251
        {3,8,4},//252
        {5,7,6},//253
        {5,6,8},//254
        {5,8,10},//255
        {6,8,10},//256
        {7,8,10},//257
        {1,7,10},//258
        {0,8,2},//259
        {8,10,3},//260
        {4,5,7},//261
        {4,7,6},//262
        {0,2,7},//263
        {0,7,6},//264
        {3,4,7},//265
        {4,1,7},//266
        {1,6,4},//267
        {0,5,1},//268
        {2,1,11},//269
        {3,7,6},//270
        {6,7,11},//271
        {8,11,9},//272
        {8,9,10},//273
        {0,8,4},//274
        {0,6,8},//275
        {3,7,11},//276
        {3,11,6},//277
        {8,4,2},//278
        {8,2,1},//279
        {1,5,9},//280
        {1,9,7},//281
        {8,4,0},//282
        {8,0,6},//283
        {4,5,2},//284
        {5,4,10},//285
        {0,2,3},//286
        {2,1,3},//287
        {6,3,11},//288
        {4,0,8},//289
        {7,1,8},//290
        {10,5,9},//291
        {3,10,4},//292
        {9,10,11},//293
        {8,11,10},//294
        {0,2,1},//295
        {0,1,3},//296
        {3,10,6},//297
        {6,10,8},//298
        {1,10,3},//299
        };
        static public readonly byte[,] field230514115901_НомерВершиныКубаПоНомеруГрани = new byte[,]
        {
            { 0, 0 },
            { 2, 0 },
            { 0, 1 },
            { 1, 1 },
            { 0, 2 },
            { 2, 2 },
            { 1, 2 },
            { 3, 2 },
            { 4, 0 },
            { 6, 0 },
            { 4, 1 },
            { 5, 1 },
        };
        static public readonly ushort[][] field230514131500_БлокИзТреугольников = new ushort[][]
        {
        new ushort[] {},//0 = 0
        new ushort[] {0,},
        new ushort[] {1,},
        new ushort[] {2,3,},
        new ushort[] {4,},
        new ushort[] {5,6,},
        new ushort[] {4,1,},
        new ushort[] {7,8,9,},
        new ushort[] {10,},
        new ushort[] {0,10,},
        new ushort[] {11,12,},
        new ushort[] {13,14,15,},
        new ushort[] {16,17,},
        new ushort[] {18,19,17,},
        new ushort[] {20,21,22,},
        new ushort[] {23,14,},
        new ushort[] {24,},
        new ushort[] {25,26,},
        new ushort[] {1,24,},
        new ushort[] {27,28,29,},
        new ushort[] {4,24,},
        new ushort[] {30,31,32,},
        new ushort[] {1,4,24,},
        new ushort[] {33,34,35,36,},
        new ushort[] {10,24,},
        new ushort[] {25,26,10,},
        new ushort[] {37,38,24,},
        new ushort[] {29,39,40,13,},
        new ushort[] {21,41,24,},
        new ushort[] {17,42,43,26,},
        new ushort[] {24,12,44,45,},
        new ushort[] {46,47,48,},
        new ushort[] {49,},
        new ushort[] {0,49,},
        new ushort[] {50,51,},
        new ushort[] {2,52,51,},
        new ushort[] {4,49,},
        new ushort[] {5,6,49,},
        new ushort[] {4,50,51,},
        new ushort[] {6,53,54,51,},
        new ushort[] {10,49,},
        new ushort[] {0,10,49,},
        new ushort[] {55,56,57,},
        new ushort[] {58,59,60,61,},
        new ushort[] {16,17,49,},
        new ushort[] {62,45,63,49,},
        new ushort[] {64,21,65,66,},
        new ushort[] {67,68,69,},
        new ushort[] {70,71,},
        new ushort[] {25,72,73,},
        new ushort[] {74,75,76,},
        new ushort[] {77,78,},//51
        new ushort[] {4,79,80,},//52
        new ushort[] {81,82,83,84,},//53
        new ushort[] {4,74,75,76},//54
        new ushort[] {31,85,86,},//55
        new ushort[] {10,80,79,},//56
        new ushort[] {25,87,71,10,},//57
        new ushort[] {74,72,11,65,},//58
        new ushort[] {88,89,90,},//59
        new ushort[] {16,17,70,71,},//60
        new ushort[] {48,90,91,276,277},//61
        new ushort[] {45,65,92,79,44,},//62
        new ushort[] {48,90,},//63
        new ushort[] {93,},//64
        new ushort[] {0,93,},//65
        new ushort[] {1,93,},//66
        new ushort[] {2,9,93,},//67
        new ushort[] {94,95,},//68
        new ushort[] {96,97,98,},//69
        new ushort[] {1,94,95,},//70
        new ushort[] {3,99,100,96,},//71
        new ushort[] {93,10,},//72
        new ushort[] {0,93,10,},//73
        new ushort[] {93,12,11,},//74
        new ushort[] {93,101,102,38,},//75
        new ushort[] {103,104,105,},//76
        new ushort[] {106,107,63,108,},//77
        new ushort[] {109,110,111,107,},//78
        new ushort[] {112,107,111,},//79
        new ushort[] {113,114,},//80
        new ushort[] {115,116,117,},//81
        new ushort[] {1,113,114,},//82
        new ushort[] {118,119,117,120,},//83
        new ushort[] {121,122,123,},//84
        new ushort[] {124,125,},//85
        new ushort[] {278,279,1,123,},//86
        new ushort[] {34,123,33,},//87
        new ushort[] {10,113,114,},//88
        new ushort[] {10,127,119,117,},//89
        new ushort[] {12,11,113,114,},//90
        new ushort[] {128,46,129,280,281},//91
        new ushort[] {130,131,113,41,},//92
        new ushort[] {132,125,63,},//93
        new ushort[] {126,133,134,282,283},//94
        new ushort[] {46,129,},//95
        new ushort[] {49,93,},//96
        new ushort[] {0,49,93,},//97
        new ushort[] {93,50,51,},//98
        new ushort[] {93,52,51,2,},//99
        new ushort[] {49,135,96,},//100
        new ushort[] {49,5,136,137,},//101
        new ushort[] {135,96,50,51,},//102
        new ushort[] {138,139,140,272,273,},//103
        new ushort[] {93,10,49,},//104
        new ushort[] {0,93,10,49,},//105
        new ushort[] {69, 55,291,290,},//106
        new ushort[] {128,140,141,272,273,284, 285,280,281,},//107
        new ushort[] {105,103,49,104,},//108
        new ushort[] {91,140,141, 272,273,274,275,276,288, },//109
        new ushort[] {141,109,147,293,294,},//110
        new ushort[] {140,141,293,294,},//111
        new ushort[] {114,148,80,},//112
        new ushort[] {149,150,151,73,},//113
        new ushort[] {152,153,154,151,},//114
        new ushort[] {155,154,151,},//115
        new ushort[] {80,156,157,121,},//116
        new ushort[] {156,158,159,},//117
        new ushort[] {139,138,126,295,296,},//118
        new ushort[] {139,138,},//119
        new ushort[] {10,160,161,162,},//120
        new ushort[] {141,128,91,270,271,280,281,295, 296,},//121
        new ushort[] {163,164,141,280,281,},//122
        new ushort[] {128,141,280,281,},//123
        new ushort[] {165,166,141,270,271,},//124
        new ushort[] {91,141,270,271,},//125
        new ushort[] {126,141,},//126
        new ushort[] {141,},//127
        new ushort[] {167,},//128
        new ushort[] {0,167,},//129
        new ushort[] {1,167,},//130
        new ushort[] {120,168,167,},//131
        new ushort[] {4,167,},//132
        new ushort[] {5,6,167,},//133
        new ushort[] {1,4,167,},//134
        new ushort[] {6,3,99,167,},//135
        new ushort[] {169,170,},//136
        new ushort[] {0,169,170,},//137
        new ushort[] {171,37,172,},//138
        new ushort[] {173,174,175,168,},//139
        new ushort[] {16,176,170,},//140
        new ushort[] {62,177,178,179,},//141
        new ushort[] {180,181,182,179,},//142
        new ushort[] {183,184,175,},//143
        new ushort[] {24,167,},//144
        new ushort[] {25,26,167,},//145
        new ushort[] {1,24,167,},//146
        new ushort[] {167,185,297,298,},//147
        new ushort[] {189,24,167,},//148
        new ushort[] {26,98,31,167,},//149
        new ushort[] {1,4,24,167, },//150
        new ushort[] {31,167,297,298,299},//151
        new ushort[] {169,170,24,},//152
        new ushort[] {169,170,25,26,},//153
        new ushort[] {272,273,274,275,163,192,188,195,},//154
        new ushort[] {88,192,188,272,273,},//155
        new ushort[] {16,176,170,24,},//156
        new ushort[] {193,194,190,272,273,},//157
        new ushort[] {126,190,196,272,273,274,275,284, 285,},//158
        new ushort[] {190,188,272,273},//159
        new ushort[] {197,198,},//160
        new ushort[] {0,197,198,},//161
        new ushort[] {187,50,199,},//162
        new ushort[] {27,200,201,198,},//163
        new ushort[] {4,197,198,},//164
        new ushort[] {5,6,197,198,},//165
        new ushort[] {4,198,202,203,},//166
        new ushort[] {191,67,204,280,281,},//167
        new ushort[] {205,206,207,},//168
        new ushort[] {0,205,206,207,},//169
        new ushort[] {208,209,},//170
        new ushort[] {210,211,101,},//171
        new ushort[] {16,176,199,146,},//172
        new ushort[] {91,210,212,274,275, },//173
        new ushort[] {44,213,204,},//174
        new ushort[] {210,212,},//175
        new ushort[] {70,214,215,},//176
        new ushort[] {216,25,87,214,},//177
        new ushort[] {74,75,217,215,},//178
        new ushort[] {185,217,215,},//179
        new ushort[] {4,70,214,215,},//180
        new ushort[] {81,190,218,280,281,},//181
        new ushort[] {191,126,190,280,281,295,284,285,296},//182
        new ushort[] {190,191,280,281,},//183
        new ushort[] {70,207,219,174,},//184
        new ushort[] {91,88,192,295,296,},//185
        new ushort[] {74,220,192,},//186
        new ushort[] {88,192,},//187
        new ushort[] {190,221,222,284,285, },//188
        new ushort[] {91,190,},//189
        new ushort[] {126,190,284,285,},//190
        new ushort[] {190,},//191
        new ushort[] {223,224,},//192
        new ushort[] {0,225,226,},//193
        new ushort[] {1,225,226,},//194
        new ushort[] {120,168,225,226},//195
        new ushort[] {135,229,230,},//196
        new ushort[] {230,229,5,100,},//197
        new ushort[] {1, 230, 231, 269,},//198
        new ushort[] {270,271, 191, 112,228,},//199
        new ushort[] {232,143,233,},//200
        new ushort[] {0,143,232,233,225,},//201
        new ushort[] {143,220,234,180,},//202
        new ushort[] {128,112,228,284,285,},//203
        new ushort[] {103,233,},//204
        new ushort[] {235,236,237,},//205
        new ushort[] {109,110,228,},//206
        new ushort[] {237,238,},//207
        new ushort[] {239,240,241,},//208
        new ushort[] {127,242,240,241,},//209
        new ushort[] {188,243,244,227,276,277,274,275,},//210
        new ushort[] {188,245,246,270,271,},//211
        new ushort[] {121,122,247,241,},//212
        new ushort[] {248,249,241,},//213
        new ushort[] {126,188,191,286,287,276,288,289,283,},//214
        new ushort[] {188,191,276,277,},//215
        new ushort[] {164,122,250,251,},//216
        new ushort[] {128,193,194,286,287, },//217
        new ushort[] {163,164,188,289,283,},//218
        new ushort[] {128,188,},//219
        new ushort[] {165,252,194,},//220
        new ushort[] {193,194,},//221
        new ushort[] {126,188,289,275,},//222
        new ushort[] {188,},//223
        new ushort[] {253,254,255,},//224
        new ushort[] {0,223,214,256,},//225
        new ushort[] {50,240,201,255,},//226
        new ushort[] {140,245,246,284,285, },//227
        new ushort[] {206,218,142,135,},//228
        new ushort[] {5,197,257,100,258,},//229
        new ushort[] {259,144,191,286,287,},//230
        new ushort[] {191,140,},//231
        new ushort[] {207,206,143,142,},//232
        new ushort[] {91,128,140,284,285,286,287,289,275,},//233
        new ushort[] {147,220,143,},//234
        new ushort[] {128,140,284,285, },//235
        new ushort[] {103,260,146,},//236
        new ushort[] {91,140,289,275,},//237
        new ushort[] {109,147,},//238
        new ushort[] {140,},//239
        new ushort[] {261,262,},//240
        new ushort[] {245,263,264,},//241
        new ushort[] {261,265,243,},//242
        new ushort[] {245,246,},//243
        new ushort[] {121,266,262,},//244
        new ushort[] {248,264,},//245
        new ushort[] {126,191,286,287,},//246
        new ushort[] {191,},//247
        new ushort[] {164,267,207,},//248
        new ushort[] {128,91,286,287,},//249
        new ushort[] {268,152,},//250
        new ushort[] {128,},//251
        new ushort[] {165,166,},//252
        new ushort[] {91,},//253
        new ushort[] {126,},//254
        new ushort[] {},//255 = 2^0 + 2^1 + 2^2 + 2^3 + 2^4 + 2^5 + 2^6+ 2^7
        };
        static public GameObject prop230625163904_НовыйОбъектВКорнеМира(string name = "empty")
        {
            GameObject go = new GameObject();
            go.transform.SetParent(prop230625163901_ОбъектКореньМира.transform);
            go.name = name;
            return go;
        }
        static public GameObject prop230625163901_ОбъектКореньМира
        {
            get
            {
                if (field230625163902_ROOT == null) field230625163902_ROOT = GameObject.Find("Root");
                return field230625163902_ROOT;
            }
        }
        static private GameObject field230625163902_ROOT;
        static public void fun230516171601_ПереСохранитьМешОбъекта(this GameObject go)
        {
            go.GetComponent<MeshFilter>().sharedMesh.fun230516171600_СохранитьМеш(st.Class.fun230518153802_ПолучитьФайлМешаПоОбъекту(go));
        }
        static public void fun230516171600_СохранитьМеш(this Mesh M,string asset)
        {
            if (System.IO.File.Exists(asset))
                AssetDatabase.SaveAssets();
            else
                AssetDatabase.CreateAsset(M, asset);
        }
        static public string fun230518153802_ПолучитьФайлМешаПоОбъекту(this GameObject go) => st.Class.fun230516161700_ПолучитьФайлПоАргументам(st.Class.field230516161900_РазделМешей, go.name, "asset");
        static public string fun230516161700_ПолучитьФайлПоАргументам(string path, string id, string exe) => path + id + "." + exe;
        static public string field230516161900_РазделМешей => "Assets/Resources/MESHES/";
        static public void fun230507204600_ПривязатьМешКОбъекту(this Mesh m, GameObject go)
        {
            if (go == null) return;
            var filter = go.GetComponent<MeshFilter>();
            if (filter == null)
                filter = go.AddComponent<MeshFilter>();
            var col = go.GetComponent<MeshCollider>();
            if (col == null)
                col = go.AddComponent<MeshCollider>();
            var ren = go.GetComponent<MeshRenderer>();
            if (ren == null)
                ren = go.AddComponent<MeshRenderer>();
            if (ren.sharedMaterial == null)
                ren.sharedMaterial = Resources.Load("MATERIALS/default", typeof(Material)) as Material;
            filter.sharedMesh = m;
            col.sharedMesh = m;
        }
        static public byte fun230627120900_СформироватьКодБлока(Vector3 v, System.Func<Vector3,bool> СуществуетВершина)
        {
                float code = 0;
                var arr = st.Class.field230515154300_ВекторОтЦентраКубаПоНомеруВершины;
                for (var i = 0; i < arr.Length; i++)
                    code += СуществуетВершина(v + arr[i]) ? Mathf.Pow(2, i) : 0;
                return (byte)code;
        }
        static public bool fun230514135400_slider_int(ref int i, string name = "default", int min = 1, int max = 5)
        {
            GUILayout.BeginHorizontal();
            st.Class.fun230508154400_lab(name);
            var b = st.Class.fun230514135805(ref i, min, max);
            GUILayout.EndHorizontal();
            return b;
        }
        static public void fun230508154400_lab(string text = "lab") => GUILayout.Label(text);
        static public bool fun230514135805(this ref int i, int min = 1, int max = 5)
        {
            int new_lv = EditorGUILayout.IntSlider(i, min, max);
            if (new_lv != i)
            {
                i = new_lv;
                return true;
            }
            return false;
        }
        static public bool fun230516124600(System.Action выполнить, string Заголовок, ref bool but)
        {
            var b = EditorGUILayout.Foldout(but, Заголовок) != but;
            if (b)
            {
                but = !but;
            }
            if (but)
                if (Selection.activeTransform)
                    выполнить();
            if (!Selection.activeTransform)
                but = false;
            return b;
        }
        static public cs2305161108.Mono fun230514161407_ПривязатьМоноКОбъекту(GameObject go,uint number = 2305081120)
        {
            var scr = go.AddComponent<cs2305161108.Mono>();
            scr.ИзменитьМир(number);
            return scr;
        }
}
}
