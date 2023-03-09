using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public static class SaveManager
{
    public static void SavePlayerProfile(PlayerProfiles profiles)
    {
        //PlayerProfile playerProfile = new PlayerProfile(name,score);
        //PlayerProfiles profiles = new PlayerProfiles(playerProfiles);
        string dataPath = Application.persistentDataPath + "/playerProfiles.save";
        FileStream fileStream;
        Debug.Log("Perfil añadido a archivo nuevo");
        fileStream = new FileStream(dataPath, FileMode.Create);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        binaryFormatter.Serialize(fileStream, profiles);
        fileStream.Close();
    }

    public static PlayerProfiles LoadPlayerProfile()
    {
        string dataPath = Application.persistentDataPath + "/playerProfiles.save";
        if (File.Exists(dataPath))
        {
            FileStream fileStream = new FileStream(dataPath, FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            PlayerProfiles playerProfile = (PlayerProfiles) binaryFormatter.Deserialize(fileStream);
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
