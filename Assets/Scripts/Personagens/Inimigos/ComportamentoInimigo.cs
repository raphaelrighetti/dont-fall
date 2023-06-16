using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamentoInimigo : MonoBehaviour, IMatavel
{
    private float distanciaJogador;
    private float distanciaChao;
    private Vector3 direcao;
    private Rigidbody rb;
    private SphereCollider sphereCollider;
    private StatusInimigo status;
    private ComportamentoGameUI scriptComportamentoUI;
    private GameObject jogador;

    void Start()
    {
        Canvas[] canvasList = GameObject.FindObjectsOfType<Canvas>();

        rb = GetComponent<Rigidbody>();
        sphereCollider = GetComponent<SphereCollider>();
        status = GetComponent<StatusInimigo>();

        foreach (Canvas item in canvasList)
        {
            ComportamentoGameUI script = item.GetComponent<ComportamentoGameUI>();

            if (script != null)
            {
                scriptComportamentoUI = script;
                break;
            }
        }

        distanciaChao = sphereCollider.bounds.extents.y;

        jogador = GameObject.FindWithTag("Jogador");
    }

    void FixedUpdate()
    {
        distanciaJogador = Vector3.Distance(transform.position, jogador.transform.position);
        direcao = jogador.transform.position - transform.position;

        if (NoChao())
        {
            rb.AddForce(direcao.normalized * status.Forca);
        }

        if (distanciaJogador > 20)
        {
            Morrer();
        }
    }

    public void Morrer()
    {
        GameObject.Destroy(gameObject);

        scriptComportamentoUI.AtualizarInimigosMortos();
    }

    public void Empurrar(GameObject other)
    {
        StatusBala statusBala = other.GetComponent<StatusBala>();

        rb.AddExplosionForce(statusBala.ForcaExplosao, other.transform.position, 5F);
    }

    bool NoChao()
    {
        return Physics.Raycast(transform.position, Vector3.down, distanciaChao + 0.1F);
    }
}
