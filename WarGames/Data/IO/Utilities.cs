using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace WarGames.Data.IO
{
    public static class Utilities
    {

        public static bool Save<T>(List<T> data)
        {
            try
            {
                string name = typeof(T).Name;

                // serialize JSON to file
                using (StreamWriter file = File.CreateText($@"{name}.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, data);
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Could not save. {e}");
                return false;
            }
        }


        public static List<T> Load<T>()
        {
            List<T> deserializedData = new List<T>();

            try
            {
                string name = typeof(T).Name;
                deserializedData = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText($@"{name}.json"));
                // deserialize JSON from file

                return deserializedData;

            }
            catch (Exception e)
            {
                Console.WriteLine($"Could not load. {e}");
                return deserializedData;
            }

        }

    }
}