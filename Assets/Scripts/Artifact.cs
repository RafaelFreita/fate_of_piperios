using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Artifact : MonoBehaviour
{

    public StoryNode node;

    private bool activatable = true;
    private LogManager logManager;

    private void Start()
    {
        logManager = GameObject.FindGameObjectWithTag("HistoryLog").GetComponent<LogManager>();
    }

    private void Activate()
    {
        // Não ser clicável caso o mundo não acabe nesse path
        if (!activatable) return;

        // Ativa o nodo
        node.isActive = true;

        bool textAdded = false;

        // Checa se possui end rule
        if (node.endRule)
        {
            textAdded = true;
            if (node.endRule.Check()) // Mundo acabou
            {
                logManager.AddMessage(node.endRule.triggeredMessage);
            }
            else                      // Mundo não acabou
            {
                logManager.AddMessage(node.endRule.untriggeredMessage);
                activatable = false;
            }
        }

        if (!textAdded)
        {
            // Mostra a mensagem
            logManager.AddMessage(node.message);
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
