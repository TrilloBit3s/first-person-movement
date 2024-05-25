using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControle : MonoBehaviour
{
    public float velocidade = 10f;
    private Rigidbody rb;
    public bool EstaNoChao = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody não encontrado! Por favor, adicione um Rigidbody ao objeto.");
        }
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * velocidade;
        float vertical = Input.GetAxis("Vertical") * Time.deltaTime * velocidade;

        transform.Translate(horizontal, 0, vertical);

        if (Input.GetButtonDown("Jump") && EstaNoChao && rb != null)
        {
            rb.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
            EstaNoChao = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Chao"))
        {
            EstaNoChao = true;
        }
    }
}
