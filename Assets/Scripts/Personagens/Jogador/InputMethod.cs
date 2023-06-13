using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMethod : MonoBehaviour
{
    [HideInInspector]
    public string HorizontalMovement = "Horizontal";
    [HideInInspector]
    public string VerticalMovement = "Vertical";
    [HideInInspector]
    public string Atirar = "Fire1";
    [HideInInspector]
    public Vector3 PosicaoMira;
    private float posicaoMiraRadius = 2;

    void Update()
    {
        // Teclado

        if (Input.GetAxisRaw("Horizontal") != 0
            || Input.GetAxisRaw("Vertical") != 0
            || Input.GetButtonDown("Fire1")
            || Input.GetAxis("Mouse X") != 0
            || Input.GetAxis("Mouse Y") != 0)
        {
            HorizontalMovement = "Horizontal";
            VerticalMovement = "Vertical";
            Atirar = "Fire1";
            PosicaoMira = (Input.mousePosition - transform.position).normalized;
        }

        // Controle

        if (Input.GetAxisRaw("Left Stick H") != 0
            || Input.GetAxisRaw("Left Stick V") != 0
            || Input.GetAxisRaw("Atirar Joystick") != 0
            || Input.GetAxis("Right Stick H") != 0
            || Input.GetAxis("Right Stick V") != 0)
        {
            HorizontalMovement = "Left Stick H";
            VerticalMovement = "Left Stick V";
            Atirar = "Atirar Joystick";

            float x = Input.GetAxis("Right Stick H") * posicaoMiraRadius;
            float z = Input.GetAxis("Right Stick V") * posicaoMiraRadius;

            PosicaoMira = (transform.position + new Vector3(x, 0, z)).normalized;
        }
    }
}
