using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace U01_Utility
{
    public static class JsonUtils
    {
        public static async Task CreateJson<T>(T classToJson, string filePath)
        {
            using (FileStream file = File.Create(filePath))
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                JsonSerializer.Serialize(file, classToJson, options);
            }
        }
            
        public static T ReadJson<T>(string filePath, T typ) 
        {
            using (FileStream file = File.OpenRead(filePath))
            {
                T obj = JsonSerializer.Deserialize<T>(file);
                return obj;
            }
        }
    }
}
