using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerInimigoBola : MonoBehaviour
{
    public GameObject InimigoBola;
    private SpawnerConfig spawnerConfig;
    private Spawner spawner;

    void Start()
    {
        spawnerConfig = GameObject.FindWithTag("Spawner Config").GetComponent<SpawnerConfig>();
        spawner = GetComponent<Spawner>();
    }

    void Update()
    {
        spawner.Spawnar(spawnerConfig.ProbabilidadeSpawn, spawnerConfig.TempoSpawn, InimigoBola, transform.position);
    }
}
