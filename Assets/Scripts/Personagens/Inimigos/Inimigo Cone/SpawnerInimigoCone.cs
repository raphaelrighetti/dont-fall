using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerInimigoCone : MonoBehaviour
{
    public GameObject InimigoCone;
    private float parentExtentsX;
    private SpawnerConfig spawnerConfig;
    private Spawner spawner;

    void Start()
    {
        parentExtentsX = gameObject.GetComponentInParent<BoxCollider>().bounds.extents.x;

        spawnerConfig = GameObject.FindWithTag("Spawner Config").GetComponent<SpawnerConfig>();
        spawner = GetComponent<Spawner>();
    }

    void Update()
    {
        Vector3 posicaoSpawn = transform.position + (Random.insideUnitSphere * parentExtentsX);
        Quaternion rotacaoSpawn = new Quaternion(-90, 0, 0, -90);

        spawner.Spawnar(spawnerConfig.ProbabilidadeSpawn / 2, spawnerConfig.TempoSpawn, InimigoCone, posicaoSpawn, rotacaoSpawn);

    }
}
