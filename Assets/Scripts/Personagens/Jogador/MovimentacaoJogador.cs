using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentacaoJogador : MonoBehaviour
{
    public float DashCooldown;
    public LayerMask EhParede;
    public Canvas UI;
    private float distanciaChao;
    private float contadorDash;
    private Vector3 direcao;
    private Rigidbody rb;
    private CapsuleCollider capsuleCollider;
    private StatusJogador status;
    private InputMethod inputMethod;
    private ComportamentoGameUI scriptComportamentoUI;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        status = GetComponent<StatusJogador>();
        inputMethod = GetComponent<InputMethod>();
        scriptComportamentoUI = UI.GetComponent<ComportamentoGameUI>();

        distanciaChao = capsuleCollider.bounds.extents.y;
        contadorDash = DashCooldown;
    }

    void Update()
    {
        contadorDash += Time.deltaTime;

        float x = Input.GetAxis(inputMethod.HorizontalMovement);
        float z = Input.GetAxis(inputMethod.VerticalMovement);

        direcao = new Vector3(x, 0, z);

        scriptComportamentoUI.AtualizaTemporizadorDash(contadorDash, DashCooldown);

        if (Input.GetButtonDown("Fire3") && contadorDash >= DashCooldown)
        {
            Dash();
        }

        if (Input.GetButtonDown("Jump") && NoChao())
        {
            Pular();
        }
    }

    void FixedUpdate()
    {
        if (direcao != Vector3.zero)
        {
            rb.MovePosition(rb.position + (direcao * status.Velocidade) * Time.deltaTime);
        }
    }

    private void Pular()
    {
        rb.AddForce(Vector3.up * status.ForcaPulo);
    }

    private void Dash()
    {
        rb.AddForce(direcao * status.ForcaDash);

        contadorDash = 0;
    }

    private bool NoChao()
    {
        return Physics.Raycast(transform.position, Vector3.down, distanciaChao + 0.1F);
    }
}
