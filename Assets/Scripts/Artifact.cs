using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Artifact : MonoBehaviour
{

    public StoryNode node;

    private bool activatable = true;
    private TextMeshProUGUI textLog;

    private void Start()
    {
        textLog = GameObject.FindGameObjectWithTag("HistoryLog").GetComponent<TextMeshProUGUI>();
    }

    private void Activate()
    {
        // Não ser clicável caso o mundo não acabe nesse path
        if (!activatable) return;

        // Ativa o nodo
        node.isActive = true;

        // Mostra a mensagem
        textLog.text = node.message;
        
        // Checa se possui end rule
        if (node.endRule)
        {
            if (node.endRule.Check()) // Mundo acabou
            {
                textLog.text = node.endRule.triggeredMessage;
            }
            else                      // Mundo não acabou
            {
                textLog.text = node.endRule.untriggeredMessage;
                activatable = false;
            }
        }

        // Passa pro proximo nodo
        if (node.nextNode)
            node = node.nextNode;
        else
            Debug.LogError("Didn't find next node!! Title: " + node.title);

    }

    private void OnMouseDown()
    {
        Debug.Log("Clicked on artifact: " + name);
        Activate();
    }

}
