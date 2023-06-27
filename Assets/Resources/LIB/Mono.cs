//empty
//empty
//empty
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;
//empty
//empty
//empty
namespace LIB.go2305271030
{
    public interface IInspector : go2305081120.IInspector
    {
        new IScene СЦЕНА { get; }
    }
    public class Inspector : go2305081120.Inspector, IInspector
    {
        new public IScene СЦЕНА => объектСЦЕНА as IScene;
        private cs2306221522.IClass Редактор = new cs2306221522.Class();

        public override bool Тест()
        {
            //st.Class.fun230626220600_ПостроитьОдинЧанкЗемлиПоУмолчанию(this.Моно.gameObject);
            return false;
        }
        override public bool Выполнить()
        {
            Редактор.ИнтерфейсПостроитьПоВДШ(this.Моно.gameObject);
            return base.Выполнить();
        }
    }
}
//empty
//empty
//empty
/// <summary>
/// 
/// </summary>
namespace LIB.go2305081120
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEvent
    {
        IInspector ОбъктМира { get; set; }
        bool Выполнить();
    }
    /// <summary>
    /// 
    /// </summary>
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
//empty
//empty
//empty
/// <summary>
/// 
/// </summary>
namespace LIB.go2305081120
{
/// <summary>
/// 
/// </summary>
public interface IInspector : go2305082132.IInspector
{
    IScene СЦЕНА { get; }
}
/// <summary>
/// 
/// </summary>
public class Inspector : go2305082132.Inspector, IInspector
{
    public IScene СЦЕНА => объектСЦЕНА as IScene;
    private Object Scene;
    public Object объектСЦЕНА
    {
        get
        {
            if (Scene == null) Scene = st.Class.fun230514161403(this,"Scene");
            return Scene;
        }
    }
    public override bool Выполнить()
    {
        GUILayout.Label("КлассМира=" + this.GetType().ToString());
        return base.Выполнить();
    }
}
}
//empty
//empty
//empty
/// <summary>
/// 
/// </summary>
namespace LIB.go2305082132
{
    /// <summary>
    /// 
    /// </summary>
    public interface IInspector
    {
    MonoBehaviour Моно { get; set; }
        bool Выполнить();
        T field<T>(ref T val) where T : class, new();
    }
    /// <summary>
    /// 
    /// </summary>
    public class Inspector : Object, IInspector
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
            //если класс не найден
            if (TestType == null) return null;
            //получаем конструктор
            var ts = new List<System.Type>();
            foreach (var arg in args) ts.Add(arg.GetType());

            System.Reflection.ConstructorInfo ci = TestType.GetConstructor(ts.ToArray());
            //вызываем конструтор
            return ci.Invoke(args) as T;
        }
    }
}
//empty
//empty
//empty
/// <summary>
/// 
/// </summary>
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
            //Манипуляция в Событии на Сцене OnSceneGUI
            public virtual void OnSceneGUI()
            {
                if (target is IMono)
                {
                    Repaint();
                    ((IMono)target).ОбъектМира?.СЦЕНА.Выполнить();
                }
            }
            //Манипуляция в Событии в Инспекторе OnInspectorGUI
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
//empty
//empty
//empty
/// <summary>
/// 
/// </summary>
namespace LIB.go2305081120
{
    /// <summary>
    /// 
    /// </summary>
    public interface IScene : IEvent
    {
    }
    /// <summary>
    /// 
    /// </summary>
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
//empty
//empty
//empty
namespace LIB.cs2306221522
{
    /// <summary>
    ///
    /// </summary>
    public interface IClass
    {
        void ИнтерфейсПостроитьПоВДШ(GameObject go);
    }
    /// <summary>
    /// рекурсивный куб с координатой
    /// </summary>
    public class Class : IClass
    {
        static public string INFO = "INFO";
        Vector3 hlw = Vector3.one;
        bool hlw_btn = false;
        Vector3 v0 = Vector3.zero;
        bool v0_btn = false;
        public void ИнтерфейсПостроитьПоВДШ(GameObject go) => ИнтерфейсПостроитьПоВДШ(go, st.Class.field230626220601_Chunk_R);
        public void ИнтерфейсПостроитьПоВДШ(GameObject go, byte R)
        {
            GUILayout.BeginVertical();
            var b_hlw = st.Class.fun230514135401_Вектор(ref hlw, ref hlw_btn, "hlw", 0, R);
            var b_v0 = st.Class.fun230514135401_Вектор(ref v0, ref v0_btn, "v0", 0, R);
            GUILayout.EndVertical();
            if (b_hlw || b_v0) ПостроитьПоВДШ(go, R);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="go"></param>
        /// <param name="h"></param>
        /// <param name="l"></param>
        /// <param name="w"></param>
        /// <param name="v0"></param>
        public void ПостроитьПоВДШ(GameObject go, byte R)
        {
            var s = new cs2306271146.Class(R, new cs2306271320.Class(hlw), v0);
            s.СобратьЧанк(go);
        }
    }
}
//empty
//empty
//empty
namespace LIB.cs2306271146
{
    /// <summary>
    ///
    /// </summary>
    public struct Class
    {
        static public string INFO = "INFO";
        public Vector3 v0;
        public cs2306271320.Class hlw;
        public byte R;
        public Class(byte R, cs2306271320.Class hlw, Vector3 v0)
        {
            this.R = R;
            this.v0 = v0;
            this.hlw = hlw;
        }
        private bool СуществуетВершина(Vector3 v)
        {
            if (v.x < v0.x || v.x > v0.x + hlw.Длинна) return false;
            if (v.y < v0.y || v.y > v0.y + hlw.Высота) return false;
            if (v.z < v0.z || v.z > v0.z + hlw.Ширина) return false;
            return true;
        }
        //собрать
        public void СобратьЧанк(GameObject go, bool Сохранить = false)
        {
            Vector3 v;
            byte code;
            var edit = new cs2305141202.Class(go);
            for (var x = 0; x <= R; x++)
                for (var y = 0; y <= R; y++)
                    for (var z = 0; z <= R; z++)
                    {
                        //получитьКод
                        v = new Vector3(x, y, z);
                        code = st.Class.fun230627120900_СформироватьКодБлока(v, СуществуетВершина);
                        edit.ИзменитьТекущийБлокИПостроить(new cs2306262134.Class(v, code));
                    }
            //hlw.ИмяЧанка, hlw.PATH + "/"
            if (Сохранить)
                st.Class.fun230516171605_СохранитьМешПоИмениОтРедактора(edit, hlw.ИмяЧанка, hlw.PATH + "/");
            else st.Class.fun230507204601_ПривязатьМешОтРедактора(edit);
        }
    }
}
//empty
//empty
//empty
namespace LIB.cs2306271320
{
    /// <summary>
    ///
    /// </summary>
    public struct Class
    {
        static public string INFO = "INFO";
        public byte Высота;//y
        public byte Длинна;//x
        public byte Ширина;//z
        public Class(byte Высота, byte Длинна, byte Ширина)
        {
            this.Высота = Высота;
            this.Длинна = Длинна;
            this.Ширина = Ширина;
        }
        public Class(Vector3 v)
        {
            this.Высота = (byte)v.y;
            this.Длинна = (byte)v.x;
            this.Ширина = (byte)v.z;
        }
        public string PATH => "chunk.hlw";
        public string ИмяЧанка => PATH + "." + Высота + "." + Длинна + "." + Ширина;
    }
}
//empty
//empty
//построить куб
namespace LIB.cs2305141202
{
    /// <summary>
    /// interface постройки куба
    /// </summary>
    public interface IClass : cs2305141208.IClass
    {
        void СобратьВертекс(byte КодБлока);
        void ИзменитьТекущийБлокИПостроить(cs2306262134.Class b);
    }
    public class Class : cs2305141208.Class, IClass
    {
        public Class(GameObject go): base(go)
        {
        }
        /// <summary>
        /// Одинаковые методы класса и интерфейса зацикливают выполнение метода класса
        /// при вызове интерфейсного метода в методе класса
        /// </summary>
        /// <param name="КодБлока"></param>
        public virtual void СобратьВертекс(byte КодБлока) {
            ИзменитьТекущийБлокИПостроить(new cs2306262134.Class(this.ТекущийБлок.Центр, КодБлока));
            Закрыть();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="b"></param>
        public void ИзменитьТекущийБлокИПостроить(cs2306262134.Class b)
        {
            this.ТекущийБлок = b;
            st.Class.fun230520204100_СобратьБлок(this);
        }
    }
}
//empty
//empty
//vertices.close закрытие вертексов(stMesh.build.vertices.close.cs2305141208)
namespace LIB.cs2305141208
{
    /// <summary>
    /// stMesh.build.vertices.close.cs2305141208
    /// </summary>
    public interface IClass : cs2305141215.IClass
    {
        GameObject GO { get; }
        Mesh ПолучитьМеш();
        void Закрыть();
    }
    public class Class : cs2305141215.Class, IClass
    {
        private GameObject _go;  public GameObject GO => _go;
        public Class(GameObject go) => this._go = go;
        public virtual void Закрыть()
        {
            var M = ПолучитьМеш();
            var Меш = new cs2305182039.Class(M, GO);
            Меш.Связать();
        }
        public Mesh ПолучитьМеш()
        {
            var M = new Mesh();
            M.vertices = vs.ToArray();

            var uvs = (this as cs2305141222.IClass);
            M.uv = uvs.Развёртка[0].ToArray();
            M.uv2 = uvs.Развёртка[1].ToArray();
            M.uv3 = uvs.Развёртка[2].ToArray();
            M.uv4 = uvs.Развёртка[3].ToArray();
            M.uv5 = uvs.Развёртка[4].ToArray();
            M.uv6 = uvs.Развёртка[5].ToArray();
            M.uv7 = uvs.Развёртка[6].ToArray();
            M.uv8 = uvs.Развёртка[7].ToArray();

            M.triangles = ts.ToArray();
            M.normals = ns.ToArray();
            M.RecalculateNormals();
            M.RecalculateBounds();
            Очистить();
            return M;
        }
    }
}
//empty
//empty
//IVertices строим по вертексу
namespace LIB.cs2305141215
{
    /// <summary>
    /// stMesh.build.vertices.cs2305141215
    /// строим по вертексу
    /// </summary>
    public interface IClass : cs2305141222.IClass
    {
        /// <summary>
        /// блок
        /// </summary>
        cs2306262134.Class ТекущийБлок { get; set; }
        /// <summary>
        /// набор вершин
        /// </summary>
        List<Vector3> vs{get;}
        /// <summary>
        /// нумерация вершин
        /// </summary>
        List<int> ts{get;}
        /// <summary>
        /// нормали
        /// </summary>
        List<Vector3> ns{get;}
        public virtual Vector3 ВычислениеВектора(Vector3 dv)=> ТекущийБлок.Центр + dv;
        /// <summary>
        /// Добавить вершину для постройки куба
        /// </summary>
        /// <param name="dv"></param>
        /// <param name="ФункцияВерстки"></param>
        public void ДобавитьВершинуДляБлока(Vector3 dv)
        {
            var v = ВычислениеВектора(dv);
            //новый вертекс
            vs.Add(v);
            //индексы вертексов
            ts.Add(vs.Count - 1);
            //нормали
            ns.Add(v.normalized);
            Треугольник(this);
        }
        public new void Очистить()
        {
            vs.Clear();
            ts.Clear();
            ns.Clear();
            (this as cs2305141222.IClass).Очистить();
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class Class : cs2305141222.Class, IClass
    {
        private cs2306262134.Class _b; public cs2306262134.Class ТекущийБлок { get => _b; set => _b=value; }
        /// <summary>
        /// вертексы
        /// </summary>
        private List<Vector3> _vs = new List<Vector3>(); public List<Vector3> vs => _vs;
        /// <summary>
        /// индексы
        /// </summary>
        private List<int> _ts = new List<int>(); public List<int> ts => _ts;
        /// <summary>
        /// нормали
        /// </summary>
        private List<Vector3> _ns = new List<Vector3>(); 
        public List<Vector3> ns => _ns;
    }
}
//empty
//empty
//Mesh.uv развертка текстуры
namespace LIB.cs2305141222
{
    /// <summary>
    /// stMesh.build.uv.cs2305141222
    /// </summary>
    public interface IClass
    {
        System.Func<cs2305141215.IClass, Vector2[]> ФункцияВерстки { get; set; }
        List<Vector2>[] Развёртка { get; }
        void Треугольник(cs2305141215.IClass Редактор);
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
        /// <summary>
        /// 
        /// </summary>
        private System.Func<cs2305141215.IClass, Vector2[]> fun; public System.Func<cs2305141215.IClass, Vector2[]> ФункцияВерстки { get => fun; set => fun = value; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Редактор"></param>
        public virtual void Треугольник(cs2305141215.IClass Редактор)
        {
            var arr = ФункцияВерстки == null ? st.Class.fun230626171800_ВерсткаБлока(Редактор) : ФункцияВерстки(Редактор);
            for (int i = 0; i < arr.Length; i++)
                Развёртка[i].Add(arr[i]);
        }
        /// <summary>
        /// 
        /// </summary>
        public virtual void Очистить()
        {
            for (var i = 0; i < Развёртка.Length; i++)
                Развёртка[i].Clear();
        }
    }
}
//empty
//empty
//empty
namespace LIB.cs2306262134
{
    /// <summary>
    /// блок из координаты и кода
    /// </summary>
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
//empty
//empty
//структура из Меш и Go (без файла)
namespace LIB.cs2305182039
{
    /// <summary>
    ///
    /// </summary>
    public struct Class
    {
        static public string INFO = "INFO";
        public GameObject go;
        public Mesh m;
        public Class(Mesh m, GameObject go = null)
        {
            this.m = m;
            this.go = go;
        }
        public void Связать() => st.Class.fun230507204600_ПривязатьМешКОбъекту(m, go);
    }
}
//empty
//empty
//empty
namespace LIB.go2305271030
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
        /// <summary>
        /// СоздатьОбъектПоИмени
        /// </summary>
        /// <param name="INS"></param>
        /// <param name="ev"></param>
        /// <returns></returns>
        static public Object fun230514161403(go2305081120.IInspector INS, string ev)
        {
            var mb = INS.Моно as cs2305161108.IMono;
            var obj = fun230514161402_СоздатьОбъектПоИмени("LIB.go" + mb.НомерМира.ToString() + "." + ev);
            (obj as go2305081120.IEvent).ОбъктМира = INS;
            return obj;
        }
        /// <summary>
        /// СоздатьОбъектПоИмени(Инспектор)
        /// </summary>
        /// <param name="mb"></param>
        /// <returns></returns>
        static public go2305081120.IInspector fun230514161404(cs2305161108.IMono mb)
        {
                var obj = fun230514161402_СоздатьОбъектПоИмени("LIB.go" + mb.НомерМира.ToString() + ".Inspector");
                mb.ОбъектМира = obj as go2305081120.IInspector;
                mb.ОбъектМира.Моно = mb as MonoBehaviour;
                return mb.ОбъектМира;
        }
        /// <summary>
        /// СоздатьОбъектПоИмени
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        static public Object fun230514161402_СоздатьОбъектПоИмени(this string name)
        {
            System.Type TestType = System.Type.GetType(name, false, true);
            //если класс не найден
            if (TestType == null) return null;
            //получаем конструктор
            System.Reflection.ConstructorInfo ci = TestType.GetConstructor(new System.Type[] { });

            //вызываем конструтор
            var obj = ci.Invoke(new object[] { });
            return obj as Object;
        }
        /// <summary>
        /// 
        /// </summary>
        static public byte field230626220601_Chunk_R = 64;
        /// <summary>
        /// ПолзунокВектор
        /// </summary>
        /// <param name="i"></param>
        /// <param name="B"></param>
        /// <param name="name"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="fun"></param>
        /// <returns></returns>
        static public bool fun230514135401_Вектор(this ref Vector3 i, ref bool B, string name = "default", int min = 1, int max = 5, System.Action<Vector3> fun = null)
        {
            var b = false;
            var v = i;
            st.Class.fun230516124600(() =>
            {
                var x = (int)v.x;
                var y = (int)v.y;
                var z = (int)v.z;
                GUILayout.BeginVertical();
                st.Class.fun230508154400(name);
                var X = fun230514135400_slider_int(ref x, "x", min, max);
                var Y = fun230514135400_slider_int(ref y, "y", min, max);
                var Z = fun230514135400_slider_int(ref z, "z", min, max);
                GUILayout.EndVertical();
                if (X || Y || Z)
                {
                    v = new Vector3(x, y, z);
                    b = true;
                    return;
                }
                b = false;
            }, "Векторы", ref B);
            if (b)
            {
                i = v;
                fun?.Invoke(v);
            }
            return b;
        }
        /// <summary>
        /// Foldout
        /// </summary>
        /// <param name="выполнить"></param>
        /// <param name="Заголовок"></param>
        /// <param name="but"></param>
        /// <returns></returns>
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
        /// <summary>
        /// lab
        /// </summary>
        /// <param name="text"></param>
        static public void fun230508154400(string text = "lab") => GUILayout.Label(text);
        /// <summary>
        /// ползунок
        /// </summary>
        /// <param name="i"></param>
        /// <param name="name"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        static public bool fun230514135400_slider_int(ref int i, string name = "default", int min = 1, int max = 5)
        {
            GUILayout.BeginHorizontal();
            st.Class.fun230508154400(name);
            var b = st.Class.fun230514135805(ref i, min, max);
            GUILayout.EndHorizontal();
            return b;
        }
        /// <summary>
        /// ползунок
        /// </summary>
        /// <param name="i"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
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
        /// <summary>
        ///
        /// </summary>
        static public Vector2[] fun230626171800_ВерсткаБлока(this cs2305141215.IClass Редактор)
        {
            return new Vector2[8]
            {
                Vector2.zero,
                //uv2 Координата вершины блока
                new Vector2(Редактор.ТекущийБлок.Центр.x,Редактор.ТекущийБлок.Центр.y),
                //uv3 Координата вершины блока и КодВешиныБлока
                new Vector2(Редактор.ТекущийБлок.Центр.z,Редактор.ТекущийБлок.Код),
                Vector2.zero,
                Vector2.zero,
                Vector2.zero,
                Vector2.zero,
                Vector2.zero,
            };
        }
        /// <summary>
        /// НастроитьИгровойОбъект
        /// </summary>
        /// <param name="m"></param>
        /// <param name="go"></param>
        static public void fun230507204600_ПривязатьМешКОбъекту(this Mesh m, GameObject go)
        {
            //GameObject
            if (go == null) return;
            //{
            //go = new GameObject();
            //go.transform.SetParent(GameObject.Find("contnent").transform);
            //}

            //MeshFilter
            var filter = go.GetComponent<MeshFilter>();
            if (filter == null)
                filter = go.AddComponent<MeshFilter>();
            //MeshCollider
            var col = go.GetComponent<MeshCollider>();
            if (col == null)
                col = go.AddComponent<MeshCollider>();
            //MeshRenderer
            var ren = go.GetComponent<MeshRenderer>();
            if (ren == null)
                ren = go.AddComponent<MeshRenderer>();
            //sharedMaterial
            if (ren.sharedMaterial == null)
                ren.sharedMaterial = Resources.Load("MATERIALS/default", typeof(Material)) as Material;

            filter.sharedMesh = m;
            col.sharedMesh = m;
        }
        /// <summary>
        ///собрать куб в списки vs,ns,uvs
        /// </summary>
        static public void fun230520204100_СобратьБлок(this cs2305141202.IClass Редактор)
        {
            if (Редактор.ТекущийБлок.Код == 0) return;
            //треугольники
            foreach (var ИндексУникальногоТреугольника in st.Class.field230514131500_БлокИзТреугольников[Редактор.ТекущийБлок.Код])
            {
                //треугольник
                for (byte i = 0; i < 3; i++)
                {
                    Редактор.ДобавитьВершинуДляБлока(st.Class.fun230514115903_ТочкаУникальногоТреугольника(ИндексУникальногоТреугольника, i));
                }
            }
        }
        /// <summary>
        /// УникальныеТриангуляционныеБлоки
        /// </summary>
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
        /// <summary>
        /// ВекторТреугольника
        /// </summary>
        /// <param name="ИндексУникальногоТреугольника"></param>
        /// <param name="НомерОсиУникальногоТреугольника"></param>
        /// <returns></returns>
        static public Vector3 fun230514115903_ТочкаУникальногоТреугольника(ushort ИндексУникальногоТреугольника, byte НомерОси)
        {
            var НомерГрани = st.Class.fun230514115300_НомерГраниКуба(ИндексУникальногоТреугольника, НомерОси);
            return fun230514115902(field230514115901_НомерВершиныКубаПоНомеруГрани[НомерГрани, 0], field230514115901_НомерВершиныКубаПоНомеруГрани[НомерГрани, 1]);
        }
        /// <summary>
        /// ТочкаТреугольника
        /// </summary>
        /// <param name="ИндексУникальногоТреугольника"></param>
        /// <param name="НомерОси"></param>
        /// <returns></returns>
        static public byte fun230514115300_НомерГраниКуба(this ushort ИндексУникальногоТреугольника, byte НомерОси) => field230514115301[ИндексУникальногоТреугольника, НомерОси];
        /// <summary>
        /// УниикальныеТреугольники
        /// индекс строки массива - уникальная комбинация точек граней куба  
        /// 0 - 11 индексы граней куба
        /// </summary>
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
        /// <summary>
        /// ВершинаГраниБлокаОси
        /// </summary>
        /// <param name="ИндексВершины"></param>
        /// <param name="НомерОсиБлока"></param>
        /// <returns></returns>
        static public Vector3 fun230514115902(byte ИндексВершины, byte НомерОсиБлока)
        {
            var v = st.Class.fun230515154302_ВекторВершиныПоЦентруКуба(ИндексВершины);
            if (НомерОсиБлока != byte.MaxValue)
                v += 0.5f * field230514115900_ВекторПоТремОсям[НомерОсиБлока];
            return v;
        }
        /// <summary>
        /// ВекторПоЦентруКуба
        /// </summary>
        /// <param name="ИндексВершины"></param>
        /// <returns></returns>
        static public Vector3 fun230515154302_ВекторВершиныПоЦентруКуба(byte ИндексВершины)
        {
            return field230515154300_ВекторОтЦентраКубаПоНомеруВершины[ИндексВершины] - 0.5f * Vector3.one;
        }
        /// <summary>
        /// ВершиныОтносительноКоординатыБлока
        /// 8 вершин как куб. Vector3.zero = new Vector3(-1,-1,-1)
        /// </summary>
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
        /// <summary>
        /// ТриОси
        /// три направленные оси точки (для определения граневая точка куба)
        /// </summary>
        static public readonly Vector3[] field230514115900_ВекторПоТремОсям = new Vector3[3]
        {
            Vector3.right,
            Vector3.up,
            Vector3.forward
        };
        /// <summary>
        /// ИндексВершиныИНомерОси
        /// строка - ребро куба или линия
        /// x - по номеру грани определить связанную ОтносительнуюВершинуКуба или точку
        /// y - номеру ОСИ, где располагается точка ребра куба, которая связана с ВершинойКуба (0..7)
        /// </summary>
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
        /// <summary>
        /// СформироватьКодБлока по функции
        /// </summary>
        static public byte fun230627120900_СформироватьКодБлока(Vector3 v, System.Func<Vector3,bool> СуществуетВершина)
        {
                float code = 0;
                var arr = st.Class.field230515154300_ВекторОтЦентраКубаПоНомеруВершины;
                for (var i = 0; i < arr.Length; i++)
                    code += СуществуетВершина(v + arr[i]) ? Mathf.Pow(2, i) : 0;
                return (byte)code;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="edit"></param>
        /// <param name="namefile"></param>
        /// <param name="path"></param>
        static public void fun230516171605_СохранитьМешПоИмениОтРедактора(this cs2305141202.Class edit, string namefile, string path = "default/")
        {
            var M = edit.ПолучитьМеш();
            st.Class.fun230516171604_СохранитьМешПоИмени(M, namefile, path);
            if (edit.GO != null)
            {
                st.Class.fun230507204600_ПривязатьМешКОбъекту(M, edit.GO);
            }
        }
        /// <summary>
        /// СохранитьМешПоИмени
        /// </summary>
        /// <param name="M"></param>
        /// <param name="id"></param>
        /// <param name="path"></param>
        static public void fun230516171604_СохранитьМешПоИмени(Mesh M, string id,string path="")
        {
            M.fun230516171600_СохранитьМеш(st.Class.fun230518153801_ПолучитьФайлМешаПоИмени(id, path));
        }
        /// <summary>
        /// 
        /// </summary>
        static public void fun230516171600_СохранитьМеш(this Mesh M,string asset)
        {
            if (System.IO.File.Exists(asset))
                AssetDatabase.SaveAssets();
            else
                AssetDatabase.CreateAsset(M, asset);
        }
        /// <summary>
        /// mesh_path_asset
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        static public string fun230518153801_ПолучитьФайлМешаПоИмени(this string id, string path = "") => st.Class.fun230516161700_ПолучитьФайлПоАргументам(st.Class.field230516161900_РазделМешей + path, id, "asset");
        /// <summary>
        /// PATH_id_exe
        /// </summary>
        /// <param name="path"></param>
        /// <param name="id"></param>
        /// <param name="exe"></param>
        /// <returns></returns>
        static public string fun230516161700_ПолучитьФайлПоАргументам(string path, string id, string exe) => path + id + "." + exe;
        /// <summary>
        /// PATH_mesh
        /// </summary>
        static public string field230516161900_РазделМешей => Application.dataPath + "/Resources/MESHES/";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="edit"></param>
        static public void fun230507204601_ПривязатьМешОтРедактора(this cs2305141202.Class edit)
        {
            var M = edit.ПолучитьМеш();
            if (edit.GO != null)
            {
                st.Class.fun230507204600_ПривязатьМешКОбъекту(M, edit.GO);
            }
        }
        /// <summary>
        ///
        /// </summary>
        static public void fun230626220600_ПостроитьОдинЧанкЗемлиПоУмолчанию(GameObject go)
        {
            var edit = new cs2305141202.Class(go);
            Vector3 v;
            for (var z = 0; z <= field230626220601_Chunk_R; z++)
            {
                for (var x = 0; x <= field230626220601_Chunk_R; x++)
                {
                    v = new Vector3(x, field230626220602_y_zero, z);
                    edit.ИзменитьТекущийБлокИПостроить(new cs2306262134.Class(v, field230626220603_code));
                }
            }
            st.Class.fun230507204601_ПривязатьМешОтРедактора(edit);
        }
        /// <summary>
        /// координата по оси y по умолчанию земли
        /// </summary>
        static public int field230626220602_y_zero = 1;
        /// <summary>
        /// код земли
        /// </summary>
        static public byte field230626220603_code = 51;
}
}
