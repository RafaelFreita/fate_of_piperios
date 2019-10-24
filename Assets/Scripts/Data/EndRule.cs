using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable, CreateAssetMenu(fileName = "EndRule")]
public class EndRule : ScriptableObject
{
    public string message;

    public List<StoryNode> activeNodes;
    public List<StoryNode> unactiveNodes;
}
