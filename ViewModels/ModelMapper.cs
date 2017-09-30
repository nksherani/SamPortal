using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Models;

namespace ViewModels
{
    public class ModelMapper<Entity,Model>
    {
        //public string ViewModelAssemblyName = typeof(LoginModel).Assembly.GetName().Name;
        //public string DataModelAssemblyName = typeof(USER).Assembly.GetName().Name;
        public static Entity ToEntity(Model model)
        {
            Type ModelType = Type.GetType( typeof(Model).AssemblyQualifiedName);
            Type EntityType = Type.GetType(typeof(Entity).AssemblyQualifiedName);
            Object entityObject = Activator.CreateInstance(EntityType);
            var modelProperties = ModelType.GetProperties();
            var entityProperties = EntityType.GetProperties();
            foreach(var ModelProperty in modelProperties)
            {
                string ModelPropertyName = ModelProperty.Name.ToString().Replace("-",string.Empty).ToLower();
                foreach(var EntityProperty in entityProperties)
                {
                    string EntityPropertyName = EntityProperty.Name.ToString().Replace("_", string.Empty).ToLower();
                    if(ModelPropertyName==EntityPropertyName)
                    {
                        EntityProperty.SetValue(entityObject, ModelProperty.GetValue(model));
                        break;
                    }
                }
            }
            return (Entity)entityObject;
        }
    }
}
