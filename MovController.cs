using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoPersonagem : MonoBehaviour{

    public float velocidade = 10f;
    public Rigidbody rb;
    public bool EstaNoChao = true;

    private void Start()
	{
        rb = GetComponent<Rigidbody>();   
    }

    void Update()
	{
        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * velocidade;   
        float vertical = Input.GetAxis("Vertical")  * Time.deltaTime * velocidade;   

        transform.Translate(horizontal, 0, vertical);

        if(Input.GetButtonDown("Jump") && EstaNoChao)
		{
            rb.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
            EstaNoChao = false;
        }
    }
    
    private void OnCollisionEnter(Collision collision)
	{
        if(collision.gameObject.tag == "Chao")
        {
            EstaNoChao = true;
        }    
    }
}