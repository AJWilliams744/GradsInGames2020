using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[Serializable]
public class Instruction
{
    [SerializeField] private TravelInstructions _Instruction;
    [SerializeField] private TravelLocations _Locations;
    [SerializeField] private WorldChoiceTriggers _ChoiceTriggers;

    public TravelInstructions TravelInstruction { get { return _Instruction; } }
    public TravelLocations Location { get { return _Locations; } }

    public WorldChoiceTriggers ChoiceTriggers { get { return _ChoiceTriggers; } }
}
