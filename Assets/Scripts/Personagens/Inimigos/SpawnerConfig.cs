using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerConfig : MonoBehaviour
{
    public float TempoSpawn;
    public float TempoTrocaDificuldade;
    public int ProbabilidadeSpawn;
    public int QuantidadeInimigosMax;
    public GameObject[] InimigosNaCena;
    private float contadorDificuldade = 0;
    private StatusJogador statusJogador;

    void Start()
    {
        statusJogador = GameObject.FindWithTag("Jogador").GetComponent<StatusJogador>();
    }

    void Update()
    {
        contadorDificuldade += Time.deltaTime;

        if (!statusJogador.Vivo)
        {
            ProbabilidadeSpawn = 0;
        }
        else if (contadorDificuldade >= TempoTrocaDificuldade && TempoSpawn >= 0.10F)
        {
            TempoSpawn -= 0.05F;
            ProbabilidadeSpawn += 3;

            contadorDificuldade = 0;
        }

        InimigosNaCena = GameObject.FindGameObjectsWithTag("Inimigo");
    }
}
