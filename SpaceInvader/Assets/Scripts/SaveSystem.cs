using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Application = UnityEngine.Device.Application;


namespace Script
{
    public static class SaveSystem
    {
        public static void SaveGame(GameManager gameManager)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/savefile";
            FileStream file = File.Open(path, FileMode.Create);
            PlayerData data = new PlayerData(gameManager);
            binaryFormatter.Serialize(file, data);
            file.Close();
        }

        public static PlayerData LoadSave()
        {
            string path = Application.persistentDataPath + "/savefile";
            if (File.Exists(path))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                FileStream file = File.Open(path, FileMode.Open);
                PlayerData data = binaryFormatter.Deserialize(file) as PlayerData;
                file.Close();
                return data;

            }

            throw new FileNotFoundException("save file not found in " + path);
        }
    }
}
