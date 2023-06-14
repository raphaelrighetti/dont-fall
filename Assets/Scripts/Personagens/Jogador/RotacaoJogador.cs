using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacaoJogador : MonoBehaviour
{
    public LayerMask EhChao;
    private Vector3 direcao;
    private Rigidbody rb;
    private InputMethod inputMethod;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        inputMethod = GetComponent<InputMethod>();
    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Right Stick H");
        float z = Input.GetAxis("Right Stick V");

        direcao = new Vector3(x, transform.position.y, z);
        if (direcao != new Vector3(0, transform.position.y, 0))
        {
            Vector3 posicaoMira = transform.position + direcao * 1000;
            posicaoMira.y = 0;

            Quaternion novaRotacao = Quaternion.LookRotation(posicaoMira);

            rb.MoveRotation(novaRotacao);
        }
    }
}
