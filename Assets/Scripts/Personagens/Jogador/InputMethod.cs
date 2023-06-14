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
    public string TipoRotacao;

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
            TipoRotacao = "Mouse";
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
            TipoRotacao = "Joystick";
        }
    }
}
