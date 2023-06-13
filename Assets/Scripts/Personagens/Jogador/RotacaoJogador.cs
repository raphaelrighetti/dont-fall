using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacaoJogador : MonoBehaviour
{
    public LayerMask EhChao;
    private Rigidbody rb;
    private InputMethod inputMethod;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        inputMethod = GetComponent<InputMethod>();
    }

    void FixedUpdate()
    {
        Quaternion novaRotacao = Quaternion.LookRotation(inputMethod.PosicaoMira);
        novaRotacao.y = 0;

        rb.MoveRotation(novaRotacao);
    }
}
