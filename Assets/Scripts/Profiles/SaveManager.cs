using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public static class SaveManager
{
    public static void SavePlayerProfile(string name, int score, int saveIndex)
    {
        PlayerProfile playerProfile = new PlayerProfile(name,score);
        string dataPath = Application.persistentDataPath + "/playerProfiles"+ saveIndex +".save";
        FileStream fileStream;
        Debug.Log("Perfil añadido a archivo nuevo");
        fileStream = new FileStream(dataPath, FileMode.Create);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        binaryFormatter.Serialize(fileStream, playerProfile);
        fileStream.Close();
    }

    public static PlayerProfile LoadPlayerProfile(int saveIndex)
    {
        string dataPath = Application.persistentDataPath + "/playerProfiles" + saveIndex + ".save";
        if (File.Exists(dataPath))
        {
            FileStream fileStream = new FileStream(dataPath, FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            PlayerProfile playerProfile = (PlayerProfile) binaryFormatter.Deserialize(fileStream);
            fileStream.Close();
            return playerProfile;
        }
        else
        {
            Debug.Log("No se encontro el archivo de guardado");
            return null;
        }
    }
}
