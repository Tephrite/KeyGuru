using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveSong(Song song)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/" +song.artist+" - "+song.title+".data";
        FileStream stream = new FileStream(path, FileMode.Create);

        SongData data = new SongData(song);

        formatter.Serialize(stream, data);
        stream.Close();
        Debug.Log(path);
    }

    public static SongData LoadSong(string title, string artist)
    {


        string path = Application.persistentDataPath + "/" + artist + " - " + title + ".data";
        
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SongData data = formatter.Deserialize(stream) as SongData;

            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("File Not Found - " + path);
            return null;
        }
    }
}
