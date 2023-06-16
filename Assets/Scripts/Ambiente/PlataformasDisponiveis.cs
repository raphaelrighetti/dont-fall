using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformasDisponiveis : MonoBehaviour
{
    public int QuantidadePlataformasMax;
    public GameObject[] Disponiveis;
    [HideInInspector]
    public GameObject[] NaCena;

    void Start()
    {
        StartCoroutine(PreencheNaCena());
    }

    private IEnumerator PreencheNaCena()
    {
        while (true)
        {
            NaCena = GameObject.FindGameObjectsWithTag("Plataforma");

            yield return new WaitForSeconds(1);
        }
    }
}
