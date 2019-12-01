using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Interaction
{
    public List<StoryNode> nodes;
    public string message;
}

[System.Serializable, CreateAssetMenu(fileName="StoryNode")]
public class StoryNode : ScriptableObject
{
    public string title;
    public string message;

    public bool isActive = false;
    public bool isFinal = false;

    public StoryNode nextNode;

    public List<Interaction> interactions;

    public EndRule endRule;

    public GameObject iconPrefab;
}
