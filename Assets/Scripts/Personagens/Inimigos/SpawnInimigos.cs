using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInimigos : MonoBehaviour
{
    public GameObject InimigoBola;
    private float contadorSpawn = 0;
    private SpawnerConfig spawnerConfig;

    void Start()
    {
        spawnerConfig = GameObject.FindWithTag("Spawner Config").GetComponent<SpawnerConfig>();
    }

    void Update()
    {
        contadorSpawn += Time.deltaTime;

        if (contadorSpawn >= spawnerConfig.TempoSpawn)
        {
            int numeroGerado = Random.Range(1, 101);

            if (numeroGerado <= spawnerConfig.ProbabilidadeSpawn)
            {
                Instantiate(InimigoBola, transform.position, transform.rotation);
            }

            contadorSpawn = 0;
        }
    }
}
