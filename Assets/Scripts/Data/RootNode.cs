using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable, CreateAssetMenu(fileName = "RootNode")]
public class RootNode : ScriptableObject
{
    public List<PathRoot> paths;
}
