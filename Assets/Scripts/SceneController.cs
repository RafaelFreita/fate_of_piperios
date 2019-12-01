using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    public int timeToWait = 6;

    public GameObject button;

    public void EnableRestart()
    {
        button.SetActive(true);
    }

    public void RestartScene()
    {
        button.SetActive(false);
        StartCoroutine(RestartSceneAsync());
    }

    IEnumerator RestartSceneAsync()
    {
        GetComponent<Animator>().SetTrigger("FadeOut");

        yield return new WaitForSeconds(timeToWait);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
