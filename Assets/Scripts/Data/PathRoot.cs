using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable, CreateAssetMenu(fileName = "PathRoot")]
public class PathRoot : ScriptableObject
{
    public List<StoryNode> nodes;
}
