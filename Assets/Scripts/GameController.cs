using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public Transform iconsPanel;

    public void AddIcon(GameObject iconPrefab)
    {
        GameObject.Instantiate(iconPrefab, iconsPanel);
    }

}
