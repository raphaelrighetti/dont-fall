using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamentoCirculoExplosao : MonoBehaviour
{
    public float ForcaEmpurro;
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

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Jogador")
        {
            Vector3 direcaoEmpurro = (other.transform.position - transform.position).normalized;

            other.GetComponent<MovimentacaoJogador>().Empurrar(direcaoEmpurro, ForcaEmpurro);
        }
    }

    private bool PassouDoLimite()
    {
        return (transform.localScale.x >= ValorLimite.x) && (transform.localScale.y >= ValorLimite.y);
    }
}
