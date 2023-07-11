using System.Collections.Generic;
using System.IO;
namespace UnityEditor.TreeViewExamples
{
    static class Section_MyTreeElementGenerator
    {
        static int IDCounter;

        public static List<T> GenerateRandomTree<T>(string PATH) where T: TreeElementProp, new()
        {
            IDCounter = 0;
            var treeElements = new List<T>();
            //var PATH = stModule.path.Class.����������;
            var root = stExemple.����������������<T>(new object[] { PATH, false, "Root", "����������", -1, IDCounter });
            treeElements.Add(root);
            AddChildrenRecursive(PATH, root, treeElements);

            return treeElements;
        }
        static void AddChildrenRecursive<T>(string PATH, TreeElement element, List<T> treeElements) where T : TreeElementProp, new()
        {
            foreach (string d in Directory.GetDirectories(PATH))
            {

                var child = stExemple.����������������<T>(new object[] {d, stModule.join.Class.����������(d), Path.GetFileName(d), "empty", element.depth + 1, ++IDCounter });
                treeElements.Add(child);
                AddChildrenRecursive(d, child, treeElements);
            }
        }

    }
}