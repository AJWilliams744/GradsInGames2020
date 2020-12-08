using System;
using UnityEngine;

[Serializable]
public class Note
{
    [SerializeField] private int _iD;
    [SerializeField] private bool _collected;
    [SerializeField] private string _title;
    [SerializeField] private string _contents;
    
    public int ID { get { return _iD; } set { _iD = value; } }
    public bool Collected { get { return _collected; } set { _collected = value; } }
    public string Title { get  { return _title; } set { _title = value; } }
    public string Contents { get { return _contents; } set { _contents = value; } }


}
