using System.Collections.Generic;

namespace LinkedInChecker
{
    /// <summary>
    /// The factory allows to create entities or gets a generic Entity's list
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EntityFactory<T> where T : IDataParser, new()
    {

        public static T CreateEntity()
        {
            return new T();
        }

        public static List<T> GetEntityList(string[] strRowData)
        {
            var entityList = new List<T>();
            foreach (var currItem in strRowData)
            {
                T entity = new T();
                entity.Parse(currItem.Split(Global.THIRDLEVEL));
                entityList.Add(entity);
            }

            return entityList;
        }
    }
}
