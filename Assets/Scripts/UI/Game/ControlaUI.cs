using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaUI : MonoBehaviour
{
    private ComportamentoUI comportamentoUI;

    void Start()
    {
        comportamentoUI = GetComponent<ComportamentoUI>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            comportamentoUI.AlternarPause();
        }
    }
}
