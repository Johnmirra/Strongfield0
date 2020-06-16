using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class DataWork
{
    public static void SaveMusic(float musicV, float effectsV)
    {

        //DataBase data = Load();
        //data.musicVolume = musicV;
        //data.effectsVolume = effectsV;

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Sound.vol";
        FileStream stream = new FileStream(path, FileMode.Create);

        DataBaseMusic data = new DataBaseMusic(musicV, effectsV);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void SaveLevel(int progress)
    {
        //DataBase data = Load();
        //data.levelProgress = progress;

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Data0.da";
        FileStream stream = new FileStream(path, FileMode.Create);

        DataBaseLevel data = new DataBaseLevel(progress);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static DataBaseMusic LoadMusic()
    {
        string path = Application.persistentDataPath + "/Sound.vol";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            DataBaseMusic data = formatter.Deserialize(stream) as DataBaseMusic;
            stream.Close();
            return data;
        }
        else
        {
            SaveMusic(0.7f, 0.7f);
            DataBaseMusic data = new DataBaseMusic(0.7f, 0.7f);
            return data;
        }
    }

    public static DataBaseLevel LoadLevel()
    {
        string path = Application.persistentDataPath + "/Data0.da";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            DataBaseLevel data = formatter.Deserialize(stream) as DataBaseLevel;
            stream.Close();
            return data;
        }
        else
        {
            SaveLevel(0);
            DataBaseLevel data = new DataBaseLevel(0);
            return data;
        }
    }

}

[System.Serializable]
public class DataBaseLevel
{
    public int levelProgress;

    public DataBaseLevel(int progress)
    {
        levelProgress = progress;
    }
}

[System.Serializable]
public class DataBaseMusic
{
    public float musicVolume;
    public float effectsVolume;

    public DataBaseMusic( float mv, float ev)
    {
        musicVolume = mv;
        effectsVolume = ev;
    }
}
