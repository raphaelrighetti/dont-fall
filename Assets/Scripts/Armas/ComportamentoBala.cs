using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamentoBala : MonoBehaviour
{
    private Rigidbody rb;
    private StatusBala status;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        status = GetComponent<StatusBala>();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + (transform.forward * status.Velocidade) * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Inimigo")
        {
            other.GetComponent<ComportamentoInimigoBola>().Empurrar(gameObject);
        }

        GameObject.Destroy(gameObject);
    }
}
