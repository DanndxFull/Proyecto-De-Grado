using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Password
{
    public static string LoadPassword()
    {
        string dataPath = Application.persistentDataPath + "/PassWordTeacher.save";
        if (File.Exists(dataPath))
        {
            FileStream fileStream = new FileStream(dataPath, FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            string password = (string) binaryFormatter.Deserialize(fileStream);
            fileStream.Close();
            return password;
        }
        else
        {
            Debug.Log("No se encontro el archivo de guardado");
            return null;
        }
    }

    public static void ChangePassword(string newPassword)
    {
        string dataPath = Application.persistentDataPath + "/PassWordTeacher.save";
        FileStream fileStream;
        Debug.Log("Contraseña Guardada");
        fileStream = new FileStream(dataPath, FileMode.Create);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        binaryFormatter.Serialize(fileStream, newPassword);
        fileStream.Close();
    }

}
