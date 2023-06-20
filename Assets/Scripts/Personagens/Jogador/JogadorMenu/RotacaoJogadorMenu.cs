using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacaoJogadorMenu : MonoBehaviour
{
    public float VelocidadeRotacao;
    private Quaternion novaRotacao;

    void FixedUpdate()
    {
        transform.Rotate(Vector3.up * VelocidadeRotacao);
    }
}
