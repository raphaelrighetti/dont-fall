using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atirar : MonoBehaviour
{
    public float CadenciaTiro;
    public GameObject Bala;
    public GameObject SpawnBala;
    private bool atirando = false;
    private float contadorTiro = 0;
    private InputMethod inputMethod;

    void Start()
    {
        inputMethod = GetComponent<InputMethod>();
    }

    void Update()
    {
        if (Input.GetAxis(inputMethod.Atirar) > 0)
        {
            if (!atirando)
            {
                contadorTiro = CadenciaTiro;
                atirando = true;
            }

            if (contadorTiro >= CadenciaTiro)
            {
                GameObject balaRef = Instantiate(Bala, SpawnBala.transform.position, SpawnBala.transform.rotation);
                GameObject.Destroy(balaRef, 3F);

                contadorTiro = 0;
            }

            contadorTiro += Time.deltaTime;
        }

        if (Input.GetAxis(inputMethod.Atirar) == 0)
        {
            atirando = false;
        }
    }
}
