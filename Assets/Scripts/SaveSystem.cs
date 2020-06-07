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
        string path;

        if (song.artist.Length > 1)
        {
            path = Application.persistentDataPath + "/" + song.artist + " - " + song.title + ".data";
        }
        else
        {
            path = Application.persistentDataPath + "/" + song.title + ".data";
        }

        FileStream stream = new FileStream(path, FileMode.Create);

        SongData data = new SongData(song);

        formatter.Serialize(stream, data);
        stream.Close();
        Debug.Log("File saved to " + path);
    }

    public static SongData LoadSong(string title, string artist)
    {
        string path;

        if (artist.Length > 1)
        {
            path = Application.persistentDataPath + "/" + artist + " - " + title + ".data";
        }
        else
        {
            path = Application.persistentDataPath + "/" + title + ".data";
        }
        
        
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SongData data = formatter.Deserialize(stream) as SongData;

            stream.Close();
            Debug.Log("File Loaded From" + path);
            return data;
        }
        else
        {
            Song defaultFile = new Song();
            defaultFile.title = title;
            defaultFile.artist = artist;
            SaveSong(defaultFile);

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SongData data = formatter.Deserialize(stream) as SongData;

            stream.Close();
            Debug.Log("File Loaded From" + path);

            return data;
        }

        
    }
}
