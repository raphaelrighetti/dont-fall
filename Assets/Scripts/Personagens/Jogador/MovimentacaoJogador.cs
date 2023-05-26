using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentacaoJogador : MonoBehaviour
{

    public float Velocidade;

    public LayerMask EhParede;

    private bool encostandoForward;

    private bool encostandoRight;

    private bool encostandoBack;

    private bool encostandoLeft;

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

        EncostandoParede();
        AjustaDirecao();
    }

    void FixedUpdate()
    {
        if (direcao != Vector3.zero)
        {
            rb.MovePosition(rb.position + (direcao * Velocidade) * Time.deltaTime);
        }
    }

    private void EncostandoParede()
    {
        float maxDistance = 0.9F;

        encostandoForward = Physics.Raycast(transform.position, Vector3.forward, maxDistance, EhParede);
        encostandoRight = Physics.Raycast(transform.position, Vector3.right, maxDistance, EhParede);
        encostandoBack = Physics.Raycast(transform.position, Vector3.back, maxDistance, EhParede);
        encostandoLeft = Physics.Raycast(transform.position, Vector3.left, maxDistance, EhParede);
    }

    private void AjustaDirecao()
    {
        if (encostandoForward && direcao.z > 0)
        {
            direcao.z = 0;
        }

        if (encostandoRight && direcao.x > 0)
        {
            direcao.x = 0;
        }

        if (encostandoBack && direcao.z < 0)
        {
            direcao.z = 0;
        }

        if (encostandoLeft && direcao.x < 0)
        {
            direcao.x = 0;
        }
    }
}
