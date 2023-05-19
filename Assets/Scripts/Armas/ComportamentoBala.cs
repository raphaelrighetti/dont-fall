using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamentoBala : MonoBehaviour
{

    public float Velocidade;

    private Rigidbody rb;

    private BoxCollider boxCollider;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + (transform.forward * Velocidade) * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Inimigo")
        {
            other.GetComponent<ComportamentoInimigo>().Empurrar(boxCollider);
        }

        GameObject.Destroy(gameObject);
    }
}
