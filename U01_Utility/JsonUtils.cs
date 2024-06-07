using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace U01_Utility
{
    public static class JsonUtils
    {
        /* Create Json File*/
        public async static Task CreateJson<T>(T classToJson, string filePath)
        {
            using (FileStream file = File.Create(filePath))
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                JsonSerializer.Serialize(file, classToJson, options);
                file.Close();
            }
            return;
        }

        /* Create */
        public static void CreateItemInJson<T>(string filePath, T obj)
        {
            List<T> jsonObjList = ReadJson<List<T>>(filePath);
            jsonObjList.Add(obj);
            CreateJson(jsonObjList, filePath);
        }

        /* Read */
        public static T ReadJson<T>(string filePath)
        {
            using (FileStream file = File.OpenRead(filePath))
            {
                T obj = JsonSerializer.Deserialize<T>(file);
                return obj;
            }
        }

        /* Update */
        public static void EditItemInJson<T>(string filePath, string property, string oldValue, string newValue)
        {
            List<T> jsonObjList = ReadJson<List<T>>(filePath);
            foreach (T obj in jsonObjList)
            {
                if (obj.GetType() == typeof(T))
                {
                    foreach (PropertyInfo p in typeof(T).GetProperties())
                    {
                        if (p.Name == property & p.GetValue(obj).ToString() == oldValue)
                        {
                            p.SetValue(obj, newValue, null);
                        }
                    }
                }
            }
            CreateJson(jsonObjList, filePath);
        }

        /* Delete */
        public async static void DeleteItemInJson<T>(string filePath, T obj, string property, string value) // Method needs to solve on how to deal with list props
        {
            /* Creating Comparable objects */
            List<T> objList = new List<T>();

            Dictionary<string, T> objectsL = new Dictionary<string, T>();
            Dictionary<string, string[]> propertiesL = new Dictionary<string, string[]>();

            Dictionary<string, string[]> propertiesR = new Dictionary<string, string[]>();


            using (FileStream file = File.OpenRead(filePath))
            {
                objList = JsonSerializer.Deserialize<List<T>>(file).ToList();

                /* Seeding list dict */
                foreach(T o in objList)
                {
                    string[] props = new string[typeof(T).GetProperties().Count()];
                    string key = typeof(T).GetProperties()[0].GetValue(o).ToString();

                    for (int i = 0; i < typeof(T).GetProperties().Count(); i++)
                    {
                        props[i] = typeof(T).GetProperties()[i].GetValue(o).ToString();
                    }
                    propertiesL[key] = props;
                    objectsL[key] = o;

                }

                string[] objProp = new string[typeof(T).GetProperties().Count()];
                string objKey = typeof(T).GetProperties()[0].GetValue(obj).ToString();

                /* Seeding obj to remove dict */
                for (int i = 0; i < typeof(T).GetProperties().Count(); i++)
                {
                    objProp[i] = typeof(T).GetProperties()[i].GetValue(obj).ToString();
                }
                propertiesR[objKey] = objProp;

                /* Comparing dictionaries */
                foreach (KeyValuePair<string, string[]> kvp in propertiesL)
                {
                    int sameCount = 0;
                    for(int i = 0; i < kvp.Value.Count()-1 ;i++)
                    {
                        if (kvp.Value[i] == propertiesR[objKey][i])
                        {
                            sameCount++;
                        }
                    }

                    /* Removing object */
                    if (sameCount == kvp.Value.Count()-1)
                    {
                        objList.Remove(objectsL[kvp.Key]);
                    }    
                }
            }

            /* Saving */
            _ = CreateJson(objList, filePath);
        }
    }
}
