﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Artifact : MonoBehaviour
{

    public StoryNode node;

    private bool activatable = true;
    private LogManager logManager;
    private bool interacaoFlag;
    private int activationsCounter = 0;
    private Vector3 initScale;

    static bool gameHasEnded = false;

    private TextMeshProUGUI tooltipText;
    private void Start()
    {
        initScale = transform.localScale;
        logManager = GameObject.FindGameObjectWithTag("HistoryLog").GetComponent<LogManager>();
        gameHasEnded = false;

        tooltipText = GameObject.FindGameObjectWithTag("Tooltip").GetComponent<TextMeshProUGUI>();
    }


    private void Activate()
    {
        // Não ser clicável caso o mundo não acabe nesse path ou já tenha acabado
        if (!activatable || gameHasEnded) return;

        // Ativa o nodo
        node.isActive = true;

        bool textAdded = false;

        GameObject.FindObjectOfType<GameController>().AddIcon(node.iconPrefab);

        // Checa se possui end rule
        if (node.endRule)
        {
            if (node.endRule.Check()) // Mundo acabou
            {
                logManager.AddMessage(node.endRule.triggeredMessage);
                gameHasEnded = true;
                FindObjectOfType<SceneController>().EnableRestart();
                textAdded = true;
                activatable = false;
            }
            else if (node.endRule.untriggeredMessage.Trim().Length > 0)                   // Mundo não acabou
            {
                logManager.AddMessage(node.endRule.untriggeredMessage);
                textAdded = true;
                activatable = false;
            }
        }

        if (!textAdded)
        {

            // Mostra a mensagem
            logManager.AddMessage(node.message);
            // valida se existe interações
            if (node.interactions.Count > 0)
            {
                interacaoFlag = true;

                // percorre as interações e olha se todos os nodos da interação estão ativos

                foreach (Interaction a in node.interactions)
                {
                    foreach (StoryNode b in a.nodes)
                    {
                        if (b.isActive)
                        {
                           GameObject.FindObjectOfType<GameController>().AddIcon(b.iconPrefab);
                           logManager.AddMessage(a.message);
                        }
                    }
                }
            }
        }

        // Passa pro proximo nodo
        if (!gameHasEnded)
        {
            if (node.nextNode)
            {
                node = node.nextNode;
                activationsCounter += 1;
                transform.localScale = initScale * 1.5f * activationsCounter;
            }
            else
                Debug.LogError("Didn't find next node!! Title: " + node.title);
        }

    }

    private void OnMouseDown()
    {
        Debug.Log("Clicked on artifact: " + name);
        Activate();
    }

    private void OnMouseOver()
    {
        if (!activatable || gameHasEnded)
        {
            tooltipText.text = "X";
        }
        else
        {
            tooltipText.text = node.title;
        }
    }

    private void OnMouseExit()
    {
        tooltipText.text = "";
    }

}
