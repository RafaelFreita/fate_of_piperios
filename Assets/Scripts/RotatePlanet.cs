using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlanet : MonoBehaviour
{

    public float speed = 2.0f;

    private float auxHorizontal;
    private float auxVertical;

    void Update()
    {
        auxVertical = Input.GetAxis("Vertical");
        auxHorizontal = Input.GetAxis("Horizontal");

        transform.Rotate(Vector3.right, auxVertical * speed * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.up, auxHorizontal * speed * Time.deltaTime, Space.World);
    }
}
