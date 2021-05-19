using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Xml.Serialization;

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
            XmlSerializer jsonFormatter = new XmlSerializer(typeof(List<T>));
            using (FileStream fs = new FileStream(string.Format("{0}/{1}.xml", folderName, obj.GetType().Name), FileMode.OpenOrCreate))
            {
                jsonFormatter.Serialize(fs, records);
            }
        }

        //Получение сборки
        protected abstract Assembly GetAssembly();

        //Получение списка классов-моделей
        protected abstract List<PropertyInfo> GetFullList();

        //Получение списка записей для каждого класса-модели
        protected abstract List<T> GetList<T>() where T : class, new();
    }
}