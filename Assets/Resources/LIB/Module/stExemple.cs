using System.Collections.Generic;
static public class stExemple
{
    static public T СоздатьЭкземпляр<T>(object[] args) where T : class
    {
        System.Type TestType = typeof(T);
        if (TestType == null) return null;
        var ts = new List<System.Type>();
        foreach (var arg in args) ts.Add(arg.GetType());
        System.Reflection.ConstructorInfo ci = TestType.GetConstructor(ts.ToArray());
        return ci.Invoke(args) as T;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="arg"></param>
    /// <returns></returns>
    static public T СоздатьЭкземпляр<T>(object arg) where T : class => СоздатьЭкземпляр<T>(new object[] { arg });
}
