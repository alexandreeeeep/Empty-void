using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePlayer(buttonFunctions stateNameControlerSave)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/EmptyVoidData.data";
        //Debug.Log(path);
        FileStream stream = new FileStream(path, FileMode.Create);
        StateNameControlerSave data = new StateNameControlerSave(stateNameControlerSave);

        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static StateNameControlerSave LoadData()
    {
        string path = Application.persistentDataPath + "/EmptyVoidData.data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            StateNameControlerSave Data = formatter.Deserialize(stream) as StateNameControlerSave;
            stream.Close();
            return Data;
        }
        else
        {
            Debug.Log("File not found");
            return null;
        }
    }
}
