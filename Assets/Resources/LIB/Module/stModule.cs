using System.IO;

namespace stModule
{
    public class Class
    {
        public static void Сохранить(uint Index, string info)
        {
            using (var stream = new FileStream(path.Class.РазделСкриптов + "module.txt", FileMode.OpenOrCreate))
            {
                var sw = new StreamWriter(stream, new System.Text.UTF8Encoding(true));
                //StreamWriter sw = new StreamWriter(path.Class.РазделСкриптов+"module.txt");
                sw.WriteLine(Index);
                sw.WriteLine(info);
                sw.Close();
            }
        }
        public static uint Загрузить(ref string info)
        {
                var sr = new StreamReader(path.Class.РазделСкриптов + "module.txt");
                var num = sr.ReadLine();
            var line = sr.ReadLine();
            info = "";
            while (line != null)
            {
                info = line + "\n" + info;
                line = sr.ReadLine();
            }
            sr.Close();

                return System.Convert.ToUInt32(num);
        }
    }
}
