using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem 
{
    public static void SaveData(SaveScores score)
    {
        BinaryFormatter binary = new BinaryFormatter();
        string path = Application.persistentDataPath + "DataScore.txt";
        FileStream fileStream = new FileStream(path, FileMode.Create);
        RecordData recordData = new RecordData(score);
        binary.Serialize(fileStream, recordData);
        fileStream.Close();
    }

    public static RecordData LoadData()
    {
        string path = Application.persistentDataPath + "DataScore.txt";
        if (File.Exists(path))
        {
            BinaryFormatter binary = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);
            RecordData data = binary.Deserialize(fileStream) as RecordData;
            fileStream.Close();
            return data;
        }
        else
        {
            Debug.Log("return null");
            return null;
        }

    }
}
