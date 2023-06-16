using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputGameUI : MonoBehaviour
{
    private ComportamentoGameUI comportamentoUI;

    void Start()
    {
        comportamentoUI = GetComponent<ComportamentoGameUI>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            comportamentoUI.AlternarPause();
        }
    }
}
