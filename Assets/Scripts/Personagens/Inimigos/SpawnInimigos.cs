using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInimigos : MonoBehaviour
{
    public float TempoSpawn;
    public float TempoTrocaDificuldade;
    public int ProbabilidadeSpawn;
    public GameObject InimigoBola;
    private float contadorSpawn;
    private float contadorDificuldade;

    void Update()
    {
        contadorSpawn += Time.deltaTime;
        contadorDificuldade += Time.deltaTime;

        if (contadorSpawn >= TempoSpawn)
        {
            int numeroGerado = Random.Range(1, 101);

            if (numeroGerado <= ProbabilidadeSpawn)
            {
                Instantiate(InimigoBola, transform.position, transform.rotation);
            }

            contadorSpawn = 0;
        }

        if (contadorDificuldade >= TempoTrocaDificuldade && TempoSpawn >= 0.10F)
        {
            TempoSpawn -= 0.05F;
            ProbabilidadeSpawn += 3;

            contadorDificuldade = 0;
        }
    }
}
