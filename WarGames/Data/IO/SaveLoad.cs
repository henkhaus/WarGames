using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using WarGames.Events;
using WarGames.Art;
using Console = Colorful.Console;
using System.Threading;

namespace WarGames.Data.IO
{
    public static class SaveLoad
    {

        public static bool SaveGame(Game game)
        {
            AsciiGenerator ascii = new AsciiGenerator();
            try
            {
                List<Game> gameList = new List<Game>();
                gameList.Add(game);
                Save<Game>(gameList);
                ascii.Info("Game Saved");
                Thread.Sleep(1 * 1000);
                return true;

            }
            catch (Exception e)
            {
                ascii.Warn($"Could not save game. {e}");
                return false;
            }
        }


        
        /// <summary>
        /// Takes a List of a type of data and saves it as JSON
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool Save<T>(List<T> data)
        {
            AsciiGenerator ascii = new AsciiGenerator();
            try
            {
                string name = typeof(T).Name;
                string path = $@"{name}.gd";
                BinaryFormatter bf = new BinaryFormatter();

                // serialize JSON to file
                if (File.Exists(path))
                {
                    // if saves thing exists, add it to the data
                    List<T> oldData = Load<T>();
                    data.AddRange(oldData);
                }

                using (FileStream file = File.Create(path))
                {
                    bf.Serialize(file, data);
                }

                return true;
            }
            catch (Exception e)
            {
                ascii.Warn($"Could not save. {e}");
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
            AsciiGenerator ascii = new AsciiGenerator();
            List<T> deserializedData = new List<T>();

            try
            {
                string name = typeof(T).Name;

                try
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    FileStream file = File.Open($@"{name}.gd", FileMode.Open);
                    deserializedData = (List<T>)bf.Deserialize(file);
                    file.Close();
                }
                catch (FileNotFoundException)
                {
                    ascii.Info($"No previouly saved {name}.");
                }

                return deserializedData;

            }
            catch (Exception e)
            {
                ascii.Warn($"Could not load. {e}");
                return deserializedData;
            }

        }
    }
}