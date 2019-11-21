using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlanet : MonoBehaviour
{

    public float speedX = 2.0f;
    public float speedY = 2.0f;
    public float smoothTime = 0.5f;

    public Vector2 uniformDirection;
    public float uniformRotationSpeed;

    public float maxSpeed = 3.0f;

    private float auxHorizontal;
    private float auxVertical;

    private Vector3 initMousePos;
    private Vector3 mousePosDelta;

    private Vector2 currentVel;
    private Vector2 targetVel;


    private void Start()
    {
        Vector3 onSphere = Random.onUnitSphere;

        uniformDirection.x = onSphere.x;
        uniformDirection.y = onSphere.y;
        uniformDirection.Normalize();
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
            initMousePos = Input.mousePosition;
        }

        if (Input.GetMouseButton(1))
        {
            mousePosDelta = Input.mousePosition - initMousePos;

            targetVel = new Vector2(mousePosDelta.x, mousePosDelta.y);

            auxHorizontal = Mathf.Clamp(Mathf.Lerp(auxHorizontal, targetVel.x, smoothTime), -maxSpeed, maxSpeed);
            auxVertical = Mathf.Clamp(Mathf.Lerp(auxVertical, targetVel.y, smoothTime), -maxSpeed, maxSpeed);

            uniformDirection.x = auxHorizontal;
            uniformDirection.y = auxVertical;
            uniformDirection.Normalize();
        }
        else
        {
            auxVertical = Input.GetAxis("Vertical") * 100.0f;
            auxHorizontal = Input.GetAxis("Horizontal") * 100.0f;

            if (auxHorizontal != 0.0f) uniformDirection.x = auxHorizontal;
            if (auxVertical != 0.0f) uniformDirection.y = auxVertical;
            uniformDirection.Normalize();
        }

        // Setting constant rotation
        if (auxHorizontal == 0.0f && auxVertical == 0.0f)
        {
            auxHorizontal = uniformDirection.x * uniformRotationSpeed;
            auxVertical = uniformDirection.y * uniformRotationSpeed;
        }

        transform.Rotate(Vector3.up, auxHorizontal * speedX * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.right, auxVertical * speedY * Time.deltaTime, Space.World);
    }
}
