using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RandomJunk
{
    public static class AutoMapper
    {
        private static IEnumerable<Type> CollectionTypes = new List<Type>() 
        { 
            typeof(IList),
            typeof(ICollection),
            typeof(IEnumerable),
            typeof(IDictionary),
            typeof(List<>),
            typeof(Collection<>),
        };

        public static void Map(this object obj, object mapTo)
        {
            //if (obj.GetType().IsGenericType)
            //{
            //    AutoMapper.MapCollection(obj, mapTo);
            //}
            //else
            //{
            AutoMapper.MapFields(obj, mapTo);
            //}
        }

        /// <summary>
        /// Map to collection object not yet implemented
        /// </summary>
        /// <param name="source"></param>
        /// <param name="mapTo"></param>
        public static void MapCollection(object source, object mapTo)
        {
            //if (source.GetType() != mapTo.GetType())
            //{
            //    return;
            //}

            var sourceProperties = source.GetType().GetProperties();
            
            if (sourceProperties != null)
            {
                var count = (int)sourceProperties[1].GetValue(source);
                //var collection = sourceProperties[2];
                //var val = collection.GetValue(0);

                if (count == 0)
                {
                    return;
                }                
            }
        }

        public static void MapFields(object source, object mapTo)
        {
            var sourceProperties = source.GetType().GetProperties();

            foreach (var prop in sourceProperties)
            {
                var propertyName = prop.Name;
                var propertyValue = prop.GetValue(source);

                var mapToProperty = AutoMapper.IsValid(mapTo, propertyName, prop.GetType());
                mapTo.GetType().GetProperty(propertyName).SetValue(mapTo, propertyValue);
            }
        }

        private static bool IsValid(object obj, string name, Type type)
        {            
            var property = obj.GetType().GetProperty(name);
            return property != null && property.GetType() == type;
        }
    }
}
