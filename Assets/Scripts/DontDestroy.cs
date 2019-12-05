using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{

    static bool exist = false;

    // Start is called before the first frame update
    private void Awake()
    {
        if (!exist)
        {
            exist = true;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
