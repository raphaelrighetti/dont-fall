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
        if (inputMethod.TipoRotacao == "Mouse")
        {
            RotacaoMouse();
        }
        else if (inputMethod.TipoRotacao == "Joystick")
        {
            RotacaoJoystick();
        }

    }

    private void RotacaoMouse()
    {
        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit impacto;

        if (Physics.Raycast(raio, out impacto, 100, EhChao))
        {
            direcao = (impacto.point - transform.position).normalized;

            Rotacionar();
        }
    }

    private void RotacaoJoystick()
    {
        float x = Input.GetAxis("Right Stick H");
        float z = Input.GetAxis("Right Stick V");

        direcao = new Vector3(x, transform.position.y, z);
        if (direcao != new Vector3(0, transform.position.y, 0))
        {
            Rotacionar();
        }
    }

    private void Rotacionar()
    {
        Vector3 posicaoMira = (transform.position + direcao.normalized * 10) - transform.position;
        posicaoMira.y = 0;

        Quaternion novaRotacao = Quaternion.LookRotation(posicaoMira);

        rb.MoveRotation(novaRotacao);
    }
}
