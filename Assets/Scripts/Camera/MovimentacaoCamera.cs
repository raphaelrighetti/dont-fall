using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentacaoCamera : MonoBehaviour
{

    public GameObject Jogador;

    private Vector3 distanciaInicial;

    void Start()
    {
        distanciaInicial = Jogador.transform.position - transform.position;
    }

    void FixedUpdate()
    {
        Vector3 novaPosicao = Jogador.transform.position - distanciaInicial;

        transform.position = novaPosicao;
    }
}
