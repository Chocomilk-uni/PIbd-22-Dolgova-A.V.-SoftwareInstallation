using SoftwareInstallationBusinessLogic.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SoftwareInstallationDatabaseImplement.Implementations
{
    public class BackUpLogic : BackUpAbstractLogic
    {
        protected override Assembly GetAssembly()
        {
            return typeof(BackUpLogic).Assembly;
        }

        protected override List<PropertyInfo> GetFullList()
        {
            using (var context = new SoftwareInstallationDatabase())
            {
                Type type = context.GetType();

                return type.GetProperties().Where(x => x.PropertyType.FullName.StartsWith("Microsoft.EntityFrameworkCore.DbSet")).ToList();
            }
        }

        protected override List<T> GetList<T>()
        {
            using (var context = new SoftwareInstallationDatabase())
            {
                return context.Set<T>().ToList();
            }
        }
    }
}