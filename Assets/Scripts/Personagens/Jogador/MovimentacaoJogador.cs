using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentacaoJogador : MonoBehaviour
{

    public float Velocidade;

    private Vector3 direcao;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        direcao = new Vector3(horizontal, 0, vertical);
    }

    void FixedUpdate()
    {
        if (direcao != Vector3.zero)
        {
            rb.MovePosition(rb.position + (direcao * Velocidade) * Time.deltaTime);
        }
    }
}
