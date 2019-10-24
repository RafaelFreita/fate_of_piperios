using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadTest : MonoBehaviour
{

    public RootNode node;

    private void Start()
    {
        foreach(PathRoot pathRoot in node.paths)
        {
            Debug.Log(pathRoot.name);

            foreach (StoryNode storyNode in pathRoot.nodes)
            {
                Debug.Log(storyNode.title);
            }
        }
    }

}
