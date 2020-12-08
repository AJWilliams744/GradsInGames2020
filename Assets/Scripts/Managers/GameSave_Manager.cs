using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class GameSave_Manager
{
    public static DimensionStorage CreateDimensionSaveGameObject(int inCurrentCheckPoint, List<Note> inNotes, bool inCompleted, bool inHasGift)
    {
        DimensionStorage dimensionSave = new DimensionStorage();

        dimensionSave.currentCheckPoint = inCurrentCheckPoint;

        dimensionSave.notes = inNotes;

        dimensionSave.completed = inCompleted;

        dimensionSave.hasGift = inHasGift;

        return dimensionSave;
    }

    public static void SaveDimension(DimensionStorage dimensionSave, string name)
    {
        BinaryFormatter bf = new BinaryFormatter();

        FileStream file = File.Create(Application.persistentDataPath + "/" + name + ".dimensionSave");

        bf.Serialize(file, dimensionSave);

        file.Close();

        Debug.Log("Dimension Saved");

    }

    public static DimensionStorage LoadDimension(string name)
    {
        string filePath = Application.persistentDataPath + "/" + name + ".dimensionSave";

        if (!File.Exists(filePath)) { Debug.LogError("No Save"); return null; }        

        BinaryFormatter bf = new BinaryFormatter();

        FileStream file = File.Open(filePath, FileMode.Open);

        DimensionStorage dimension = (DimensionStorage)bf.Deserialize(file);

        file.Close();

        Debug.Log("Save Loaded");

        return dimension;
    }

    public static bool DeleteDimension(string name)
    {
        File.Delete(Application.persistentDataPath + "/" + name + ".dimensionSave");

        return File.Exists(Application.persistentDataPath + "/" + name + ".dimensionSave");
    }

    //public static GlobalStorage CreateGlobalSaveGameObject(bool[] inCompletedLevels, bool[] inCollectedNotes)
    //{
    //    GlobalStorage globalSave = new GlobalStorage();

    //    globalSave.completedLevels = inCompletedLevels;

    //    globalSave.collectedNotes = inCollectedNotes;

    //    return globalSave;
    //}

    //public static void SaveGlobal(GlobalStorage globalSave)
    //{
    //    BinaryFormatter bf = new BinaryFormatter();

    //    FileStream file = File.Create(Application.persistentDataPath + "/GlobalSave.globalSave");

    //    bf.Serialize(file, globalSave);

    //    file.Close();

    //    Debug.Log("Game Saved");

    //}

    //public static GlobalStorage LoadGlobal(string name, string fileType)
    //{
    //    string filePath = Application.persistentDataPath + "/GlobalSave.globalSave";

    //    if (!File.Exists(filePath)) { Debug.LogError("No Save"); return null; }

    //    BinaryFormatter bf = new BinaryFormatter();

    //    FileStream file = File.Open(filePath, FileMode.Open);

    //    GlobalStorage globalSave = (GlobalStorage)bf.Deserialize(file);

    //    file.Close();

    //    Debug.Log("Save Loaded");

    //    return globalSave;
    //}

}

[System.Serializable]
public class DimensionStorage
{
    public bool hasGift = false;

    public int currentCheckPoint = 0;

    public List<Note> notes = null;

    public bool completed = false;

}

//[System.Serializable]
//public class GlobalStorage
//{
//    public bool[] completedLevels;
//    public bool[] collectedNotes;
//}
