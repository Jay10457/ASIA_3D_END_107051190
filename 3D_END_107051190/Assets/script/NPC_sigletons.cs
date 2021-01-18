using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NPC Data", menuName = "singletons/NPC Data")]

public class NPC_sigletons : ScriptableObject
{
    [Header("Text1"), TextArea(1, 5)]
    public string textA;
    [Header("Text2"), TextArea(1, 5)]
    public string textB;
    [Header("Text3"), TextArea(1, 5)]
    public string textC;
    [Header("MissionCount")]
    public int count;
    [Header("CountCurrent")]
    public int countCurrent;
}
   
