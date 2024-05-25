using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour 
{
    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private float sensibilidadeX = 1f;
    [SerializeField]
    private float sensibilidadeY = 1f;
    
    private float rotationX = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        ControlarEixoX();
        ControlarEixoY();
    }

    private void ControlarEixoX()
    {
        float mouseX = Input.GetAxis("Mouse X");
        Vector3 playerRotation = playerTransform.localEulerAngles;
        playerRotation.y += mouseX * sensibilidadeX;
        playerTransform.localEulerAngles = playerRotation;   
    }

    private void ControlarEixoY()
    {
        float mouseY = Input.GetAxis("Mouse Y");
        rotationX -= mouseY * sensibilidadeY;
        rotationX = Mathf.Clamp(rotationX, -70f, 60f);

        Vector3 cameraRotation = transform.localEulerAngles;
        cameraRotation.x = rotationX;
        transform.localEulerAngles = cameraRotation;
		// transform.Rotate(-mouseY,0f,0f); 
    }
}
