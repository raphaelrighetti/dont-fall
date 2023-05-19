using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atirar : MonoBehaviour
{

    public GameObject Bala;

    public GameObject SpawnBala;



    void Update()
    {
        GameObject balaRef = null;

        if (Input.GetButtonDown("Fire1"))
        {
            balaRef = Instantiate(Bala, SpawnBala.transform.position, SpawnBala.transform.rotation);
        }

        if (balaRef != null)
        {
            GameObject.Destroy(balaRef, 3F);
        }
    }
}
