using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;



static  class SaveSystem
{
   public static void SavePlayer(PlayerController player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.FUN";
        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerSaveData data = new PlayerSaveData(player);
        formatter.Serialize(stream, data);
        stream.Close();
        Debug.Log("Saved :)");
        
   }

    public static PlayerSaveData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.FUN";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerSaveData data=  formatter.Deserialize(stream) as PlayerSaveData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save File Not Found in " + path);
            return null;
        }

    }

}
