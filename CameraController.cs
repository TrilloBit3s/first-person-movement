using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController: MonoBehaviour 
{
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private float sensibilidadeX = 1f, sensibilidadeY = 1f;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        OlharEixoX();
        OlharEixoY();
    }

    private void OlharEixoX()
    {
        float mouseX = Input.GetAxis("Mouse X");

        Vector3 rotation = Player.transform.localEulerAngles;
        rotation.y += mouseX * sensibilidadeX;
        Player.transform.localEulerAngles = rotation;   
    }

    private void OlharEixoY()
    {
        float mouseY = Input.GetAxis("Mouse Y");

        Vector3 rotation = transform.localEulerAngles;
        rotation.x += mouseY * sensibilidadeY;
        rotation.x = (rotation.x > 180) ? rotation.x - 360 : rotation.x;
        rotation.x = Mathf.Clamp(rotation.x, -70, 60);
       // transform.Rotate(-mouseY,0f,0f); 
       transform.localEulerAngles = rotation; //esta transição faz o player ver ao contrario      
    }
}