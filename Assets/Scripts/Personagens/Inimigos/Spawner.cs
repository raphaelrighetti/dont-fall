using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float contadorSpawn = 0;
    private SpawnerConfig spawnerConfig;

    void Start()
    {
        spawnerConfig = GameObject.FindWithTag("Spawner Config").GetComponent<SpawnerConfig>();
    }

    public void Spawnar(int probabilidadeSpawn, float tempoSpawn, GameObject objeto, Vector3 posicao)
    {
        contadorSpawn += Time.deltaTime;

        if (contadorSpawn >= tempoSpawn)
        {
            int numeroGerado = Random.Range(1, 101);

            if (numeroGerado <= probabilidadeSpawn)
            {
                Instantiate(objeto, posicao, transform.rotation);
            }

            contadorSpawn = 0;
        }
    }

    public void Spawnar(int probabilidadeSpawn, float tempoSpawn, GameObject objeto, Vector3 posicao, Quaternion rotacao)
    {
        contadorSpawn += Time.deltaTime;

        if (spawnerConfig.InimigosNaCena.Length >= spawnerConfig.QuantidadeInimigosMax)
        {
            return;
        }

        if (contadorSpawn >= tempoSpawn)
        {
            int numeroGerado = Random.Range(1, 101);

            if (numeroGerado <= probabilidadeSpawn)
            {
                Instantiate(objeto, posicao, rotacao);
            }

            contadorSpawn = 0;
        }
    }
}
