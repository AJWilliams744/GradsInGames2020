using System;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[Serializable]
public class StoryData : ScriptableObject
{
    [SerializeField] private string _dimensionName;

    [SerializeField] private List<BeatData> _beats;

    [SerializeField] private List<Note> _notes;
 
    public BeatData GetBeatById( int id )
    {
        return _beats.Find(b => b.ID == id);
    }

    public List<Note> GetNotes()
    {
        return _notes;
    }

    public string GetDimensionName()
    {
        return _dimensionName;
    }

#if UNITY_EDITOR
    public const string PathToAsset = "Assets/Data/BaseStory.asset";

    public static StoryData LoadData()
    {
        StoryData data = AssetDatabase.LoadAssetAtPath<StoryData>(PathToAsset);
        if (data == null)
        {
            data = CreateInstance<StoryData>();
            AssetDatabase.CreateAsset(data, PathToAsset);
        }

        return data;
    }
#endif
}

