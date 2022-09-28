using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float movementSpeed = 10.0f;
    float rotationSpeed = 200.0f;

    float hInput, vInput, mouseX, mouseY;

    [SerializeField]
    GameObject weapon, arm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        transform.Translate(new Vector3(hInput * movementSpeed * Time.deltaTime, 0, vInput * movementSpeed * Time.deltaTime));
        transform.Rotate(Vector2.up, mouseX * rotationSpeed * Time.fixedDeltaTime);
        arm.transform.Rotate(-Vector2.right, mouseY * rotationSpeed * Time.fixedDeltaTime);

        Vector3 cameraAngles = arm.transform.localRotation.eulerAngles;
        Debug.Log(cameraAngles.x);
        if(cameraAngles.x >= 80 && cameraAngles.x <=90)
        {
            arm.transform.localRotation = Quaternion.Euler(80, 0, 0);
        }
        if (cameraAngles.x <= 280 && cameraAngles.x >= 270)
        {
            arm.transform.localRotation = Quaternion.Euler(280, 0, 0);
        }
    }
}
