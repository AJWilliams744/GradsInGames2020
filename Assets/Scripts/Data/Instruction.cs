using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Instruction
{
    [SerializeField] private TravelInstructions _Instruction;
    [SerializeField] private TravelLocations _Locations;

    public TravelInstructions TravelInstruction{ get { return _Instruction; } }
    public TravelLocations Location { get { return _Locations; } }
}
