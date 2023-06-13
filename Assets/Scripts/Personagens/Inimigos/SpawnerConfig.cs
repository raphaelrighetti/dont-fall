using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerConfig : MonoBehaviour
{
    public float TempoSpawn;
    public float TempoTrocaDificuldade;
    public int ProbabilidadeSpawn;
    private float contadorDificuldade;

    void Start()
    {
        contadorDificuldade = 0;
    }

    void Update()
    {
        contadorDificuldade += Time.deltaTime;

        if (contadorDificuldade >= TempoTrocaDificuldade && TempoSpawn >= 0.10F)
        {
            TempoSpawn -= 0.05F;
            ProbabilidadeSpawn += 3;

            contadorDificuldade = 0;
        }
    }
}
