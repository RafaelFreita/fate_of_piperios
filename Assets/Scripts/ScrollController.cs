using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollController : MonoBehaviour
{

    private ScrollRect scroll;

    private void Awake()
    {
        scroll = GetComponent<ScrollRect>();
    }

    public void MoveToBottom()
    {
        StartCoroutine(WaitAndMove());
    }

    IEnumerator WaitAndMove()
    {
        yield return new WaitForEndOfFrame();

        Canvas.ForceUpdateCanvases();
        scroll.verticalNormalizedPosition = 0.0f;
        Canvas.ForceUpdateCanvases();
    }

}
