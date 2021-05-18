using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace SoftwareInstallationBusinessLogic.BusinessLogic
{
    public abstract class BackUpAbstractLogic
    {
        public object Assemply { get; private set; }

        public void CreateArchive(string folderName)
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(folderName);

                if (dirInfo.Exists)
                {
                    foreach (FileInfo file in dirInfo.GetFiles())
                    {
                        file.Delete();
                    }
                }

                string fileName = $"{folderName}.zip";

                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }

                Assembly assem = GetAssembly();
                var dbsets = GetFullList();
                MethodInfo method = GetType().BaseType.GetTypeInfo().GetDeclaredMethod("SaveToFile");

                foreach (var set in dbsets)
                {
                    var elem = assem.CreateInstance(set.PropertyType.GenericTypeArguments[0].FullName);
                    MethodInfo generic = method.MakeGenericMethod(elem.GetType());
                    generic.Invoke(this, new object[] { folderName });
                }

                ZipFile.CreateFromDirectory(folderName, fileName);

                dirInfo.Delete(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void SaveToFile<T>(string folderName) where T : class, new()
        {
            var records = GetList<T>();
            T obj = new T();
            var typeName = obj.GetType().Name;
            if (records != null)
            {
                var root = new XElement(typeName + 's');

                foreach (var record in records)
                {
                    var elem = new XElement(typeName);
                    foreach (var member in obj.GetType().GetMembers()
                        .Where(rec => rec.MemberType != MemberTypes.Method &&
                        rec.MemberType != MemberTypes.Constructor &&
                        !rec.ToString().Contains(".Models.")))
                    {
                        elem.Add(new XElement(member.Name, record.GetType().GetProperty(member.Name)?.GetValue(record) ?? "null"));
                    }
                    root.Add(elem);
                }
                XDocument xDocument = new XDocument(root);
                xDocument.Save(string.Format("{0}/{1}.xml", folderName, typeName));
            }
        }

        //Получение сборки
        protected abstract Assembly GetAssembly();

        //Получение списка записей для каждого класса-модели
        protected abstract List<PropertyInfo> GetFullList();

        //Получение списка классов-моделей
        protected abstract List<T> GetList<T>() where T : class, new();
    }
}