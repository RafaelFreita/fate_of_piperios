using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LogManager : MonoBehaviour
{

    public GameObject logEntry;

    private ScrollController scrollController;

    private void Awake()
    {
        scrollController = GameObject.FindGameObjectWithTag("Scrollview").GetComponent<ScrollController>();
    }

    public void AddMessage(string text)
    {
        TextMeshProUGUI textMesh = Instantiate(logEntry, transform).GetComponent<TextMeshProUGUI>();
        textMesh.text = text;

        scrollController.MoveToBottom();
    }

}
