using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Artifact : MonoBehaviour
{

    public StoryNode node;

    private bool activatable = true;
    private LogManager logManager;

    private int activationsCounter = 0;
    private Vector3 initScale;

    private void Start()
    {
        initScale = transform.localScale;
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
                StartCoroutine(RestartSceneAsync());
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
        {
            node = node.nextNode;
            activationsCounter += 1;
            transform.localScale = initScale * 1.5f * activationsCounter;
        }
        else
            Debug.LogError("Didn't find next node!! Title: " + node.title);

    }

    IEnumerator RestartSceneAsync()
    {
        GameObject.FindWithTag("LevelChanger").GetComponent<Animator>().SetTrigger("FadeOut");

        yield return new WaitForSeconds(6);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnMouseDown()
    {
        Debug.Log("Clicked on artifact: " + name);
        Activate();
    }

}
