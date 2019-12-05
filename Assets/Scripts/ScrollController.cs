using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollController : MonoBehaviour
{

    private ScrollRect scroll;

    private Camera cameraMain;
    public AnimationCurve curve;

    private void Awake()
    {
        scroll = GetComponent<ScrollRect>();
        cameraMain = Camera.main;
    }

    public void MoveToBottom()
    {
        Debug.Log("Move to bottom!");
        StartCoroutine(WaitAndMove());
        StartCoroutine(FovExplosion(0.3f));
    }

    IEnumerator FovExplosion(float duration) {
        Debug.Log("Fov explosion!");
        float t = 0.0f;

        float s = 1.0f / duration;
        while (t < 1.0f)
        {
            t += Time.deltaTime * s;
            t = Mathf.Clamp01(t);
            cameraMain.fieldOfView = curve.Evaluate(t);
            yield return null;
        }

    }

    IEnumerator WaitAndMove()
    {
        yield return new WaitForEndOfFrame();

        Canvas.ForceUpdateCanvases();
        scroll.horizontalNormalizedPosition = 1.0f;
        Canvas.ForceUpdateCanvases();
    }

}
