using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacaoJogador : MonoBehaviour
{
    public LayerMask EhChao;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit impacto;

        if (Physics.Raycast(raio, out impacto, 100, EhChao))
        {
            Vector3 posicaoMira = impacto.point - transform.position;
            posicaoMira.y = 0;
            Quaternion rotacao = Quaternion.LookRotation(posicaoMira);

            rb.MoveRotation(rotacao);
        }
    }
}
