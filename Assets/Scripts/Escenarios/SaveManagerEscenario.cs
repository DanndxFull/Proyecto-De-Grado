using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveManagerEscenario
{
    public static void SavePlayerProfile(Escenarios escenario)
    {
        string dataPath = Application.persistentDataPath + "/escenarios.save";
        FileStream fileStream;
        Debug.Log("Perfil añadido a archivo nuevo");
        fileStream = new FileStream(dataPath, FileMode.Create);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        binaryFormatter.Serialize(fileStream, escenario);
        fileStream.Close();
    }

    public static Escenarios LoadPlayerProfile()
    {
        string dataPath = Application.persistentDataPath + "/escenarios.save";
        if (File.Exists(dataPath))
        {
            FileStream fileStream = new FileStream(dataPath, FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            Escenarios playerProfile = (Escenarios)binaryFormatter.Deserialize(fileStream);
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
