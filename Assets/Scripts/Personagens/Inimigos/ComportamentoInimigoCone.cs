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
            Instantiate(CirculoExplosao);
            Destroy(gameObject);
        }
    }
}
