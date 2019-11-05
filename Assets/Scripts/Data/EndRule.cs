using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable, CreateAssetMenu(fileName = "EndRule")]
public class EndRule : ScriptableObject
{
    public string triggeredMessage;
    public string untriggeredMessage;

    public List<StoryNode> activeNodes;
    public List<StoryNode> unactiveNodes;

    public bool Check()
    {
        foreach(StoryNode node in activeNodes)
        {
            if (!node.isActive) return true;
        }

        foreach (StoryNode node in unactiveNodes)
        {
            if (node.isActive) return true;
        }

        return false;
    }
}
