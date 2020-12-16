using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class GameSave_Manager
{
    public static DimensionStorage CreateDimensionSaveGameObject(int inCurrentCheckPoint, List<Note> inNotes, bool inCompleted, bool inHasGift, int inBuildIndex)
    {
        DimensionStorage dimensionSave = new DimensionStorage();

        dimensionSave.currentCheckPoint = inCurrentCheckPoint;

        dimensionSave.notes = new List<Note>(inNotes);

        dimensionSave.completed = inCompleted;

        dimensionSave.hasGift = inHasGift;

        dimensionSave.buildIndex = inBuildIndex;

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

    public static void DeleteAllDimensions()
    {
        List<string> allNames = GetAllDimensionNames();

        foreach(string name in allNames)
        {
            File.Delete(Application.persistentDataPath + "/" + name + ".dimensionSave");
        }
    }

    public static List<string> GetAllDimensionNames()
    {
        List<string> allNames = new List<string>();

        DirectoryInfo dir = new DirectoryInfo(Application.persistentDataPath);
        FileInfo[] info = dir.GetFiles("*.dimensionSave*");
        foreach (FileInfo f in info)
        {
            string[] splitString = f.Name.Split('.');
            allNames.Add(splitString[0]);
        }

        return allNames;
    }
    //    public static GlobalStorage CreateGlobalSaveGameObject(int inCurrentSceneInt, List<Note> inCollectedNotes)
    //    {
    //        GlobalStorage globalSave = new GlobalStorage();

    //        globalSave.currnetSceneInt = inCurrentSceneInt;

    //        globalSave.collectedNotes = inCollectedNotes;

    //        return globalSave;
    //    }

    //    public static void SaveGlobal(GlobalStorage globalSave)
    //    {
    //        BinaryFormatter bf = new BinaryFormatter();

    //        FileStream file = File.Create(Application.persistentDataPath + "/GlobalSave.globalSave");

    //        bf.Serialize(file, globalSave);

    //        file.Close();

    //        Debug.Log("Game Saved");

    //    }

    //    public static GlobalStorage LoadGlobal(string name, string fileType)
    //    {
    //        string filePath = Application.persistentDataPath + "/GlobalSave.globalSave";

    //        if (!File.Exists(filePath)) { Debug.LogError("No Save"); return null; }

    //        BinaryFormatter bf = new BinaryFormatter();

    //        FileStream file = File.Open(filePath, FileMode.Open);

    //        GlobalStorage globalSave = (GlobalStorage)bf.Deserialize(file);

    //        file.Close();

    //        Debug.Log("Save Loaded");

    //        return globalSave;
    //    }

    }

    [System.Serializable]
    public class DimensionStorage
    {
        public bool hasGift = false;

        public int currentCheckPoint = 0;

        public List<Note> notes = null;

        public bool completed = false;

        public int buildIndex = 0;

    }

//[System.Serializable]
//public class GlobalStorage
//{
//    public int currnetSceneInt;
//    public List<Note> collectedNotes;
//}
