using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewRiddleData", menuName = "Riddle Data", order = 51)]
public class RiddleData : ScriptableObject
{
    public string riddleText;
    public List<string> riddleSolutions; // List of possible solutions
    public int riddleValue;
}
