using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamentoCirculoExplosao : MonoBehaviour
{
    public Vector3 ValorCrescimento;
    public Vector3 ValorLimite;

    void FixedUpdate()
    {
        transform.localScale += ValorCrescimento;

        if (PassouDoLimite())
        {
            Destroy(gameObject);
        }
    }

    private bool PassouDoLimite()
    {
        return (transform.localScale.x >= ValorLimite.x) && (transform.localScale.y >= ValorLimite.y);
    }
}
