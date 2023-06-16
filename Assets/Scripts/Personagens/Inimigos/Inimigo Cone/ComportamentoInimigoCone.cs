using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamentoInimigoCone : MonoBehaviour
{
    public GameObject CirculoExplosao;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Chao"))
        {
            Vector3 posicaoSpawn = transform.position;
            posicaoSpawn.y = 0.25F;

            Instantiate(CirculoExplosao, posicaoSpawn, transform.rotation);
            Destroy(gameObject);
        }
    }
}
