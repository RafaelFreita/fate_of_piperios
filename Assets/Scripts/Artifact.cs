using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using UnityEngine.SceneManagement;

public class Artifact : MonoBehaviour
{

    static bool reachedEnd = false;

    public StoryNode node;

    private bool activatable = true;
    private TextMeshProUGUI textLog;

    private Material material;
    private Color artifactColor;

    private void Awake()
    {
        reachedEnd = false;
    }

    private void Start()
    {
        textLog = GameObject.FindGameObjectWithTag("HistoryLog").GetComponent<TextMeshProUGUI>();

        material = GetComponent<MeshRenderer>().material;

        artifactColor = Random.ColorHSV(0f, 1f, .5f, 1f, .45f, 0.7f, 1f, 1f);

        material.SetColor("_BaseColor", artifactColor);
        material.SetColor("_EmissionColor", artifactColor);
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
                reachedEnd = true;
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
        GameObject.FindWithTag("LevelChanger").GetComponent<Animator>().SetTrigger("FadeOut");

        yield return new WaitForSeconds(6);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnMouseDown()
    {
        if (reachedEnd) return;
        Debug.Log("Clicked on artifact: " + name);
        Activate();

        artifactColor = artifactColor * 3;
        material.SetColor("_EmissionColor", artifactColor);
    }

}
