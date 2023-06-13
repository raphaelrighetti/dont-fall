using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentacaoJogador : MonoBehaviour
{
    public float DashCooldown;
    public LayerMask EhParede;
    public Canvas UI;
    private float contadorDash;
    private Vector3 direcao;
    private Rigidbody rb;
    private StatusJogador status;
    private InputMethod inputMethod;
    private ComportamentoUI scriptComportamentoUI;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        status = GetComponent<StatusJogador>();
        inputMethod = GetComponent<InputMethod>();
        scriptComportamentoUI = UI.GetComponent<ComportamentoUI>();

        contadorDash = DashCooldown;
    }

    void Update()
    {
        contadorDash += Time.deltaTime;

        float x = Input.GetAxis(inputMethod.HorizontalMovement);
        float z = Input.GetAxis(inputMethod.VerticalMovement);

        scriptComportamentoUI.AtualizaTemporizadorDash(contadorDash, DashCooldown);

        if (Input.GetButtonDown("Fire3") && contadorDash >= DashCooldown)
        {
            Dash();
        }

        direcao = new Vector3(x, 0, z);
    }

    void FixedUpdate()
    {
        if (direcao != Vector3.zero)
        {
            rb.MovePosition(rb.position + (direcao * status.Velocidade) * Time.deltaTime);
        }
    }

    private void Dash()
    {
        rb.AddForce(direcao * status.ForcaDash);

        contadorDash = 0;
    }
}
