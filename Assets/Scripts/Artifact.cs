using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using UnityEngine.SceneManagement;

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
        // Não ser clicável caso já tenha passado por esse nodo
        if (node.isActive) return;

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
                StartCoroutine(RestartSceneAsync());
            }
            else                      // Mundo não acabou
            {
                textLog.text = node.endRule.untriggeredMessage;
            }
        }

        // Passa pro proximo nodo
        if (node.nextNode)
            node = node.nextNode;
        else
            Debug.Log("Didn't find next node!! Title: " + node.title);

    }

    IEnumerator RestartSceneAsync()
    {
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnMouseDown()
    {
        Debug.Log("Clicked on artifact: " + name);
        Activate();
    }

}
