using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace WarGames.Data.IO
{
    public static class Utilities
    {

        /// <summary>
        /// Takes a List of a type of data and saves it as JSON
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool Save<T>(List<T> data)
        {
            try
            {
                string name = typeof(T).Name;
                ;
                BinaryFormatter bf = new BinaryFormatter();

                // serialize JSON to file
                using (FileStream file = File.Create($@"{name}.gd"))
                {
                    bf.Serialize(file, data);
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Could not save. {e}");
                return false;
            }
        }

        /// <summary>
        /// Loads all saved data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> Load<T>()
        {
            List<T> deserializedData = new List<T>();

            try
            {
                string name = typeof(T).Name;

                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open($@"{name}.gd", FileMode.Open);
                deserializedData = (List<T>)bf.Deserialize(file);
                file.Close();

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