using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartStates : MonoBehaviour
{

    public RootNode node;

    private void Start()
    {
        foreach (PathRoot pathRoot in node.paths)
        {
            foreach (StoryNode storyNode in pathRoot.nodes)
            {
                IterateNode(storyNode);
            }
        }
    }

    private void IterateNode(StoryNode node)
    {
        node.isActive = false;
        if (node.nextNode) IterateNode(node.nextNode);
    }

}
