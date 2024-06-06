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
        /* Create */
        public static async Task CreateJson<T>(T classToJson, string filePath)
        {
            using (FileStream file = File.Create(filePath))
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                JsonSerializer.Serialize(file, classToJson, options);
            }
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



        /* Read */
        public static T EditJson<T>(string filePath, T typ, string property, string newValue)
        {
            using (FileStream file = File.Create(filePath))
            {
                T obj = JsonSerializer.Deserialize<T>(file);
                PropertyInfo[] properties = typeof(T).GetProperties();

                Type type = typeof(T);
                PropertyInfo propInfo = type.GetProperty(property);
                propInfo.SetValue(typ, "Ten", null);

               
                var options = new JsonSerializerOptions { WriteIndented = true };
                JsonSerializer.Serialize(file, typ, options);
                return typ;
            }
        }
    }
}
