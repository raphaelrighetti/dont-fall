using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamentoInimigo : MonoBehaviour
{

    public float Forca;

    public float ForcaExplosao;

    private float distanciaJogador;

    private float distanciaChao;

    private Vector3 direcao;

    private Rigidbody rb;

    private SphereCollider sphereCollider;

    private GameObject jogador;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sphereCollider = GetComponent<SphereCollider>();

        jogador = GameObject.FindWithTag("Jogador");

        distanciaChao = sphereCollider.bounds.extents.y;
    }

    void FixedUpdate()
    {
        distanciaJogador = Vector3.Distance(transform.position, jogador.transform.position);
        direcao = jogador.transform.position - transform.position;

        if (NoChao())
        {
            rb.AddForce(direcao.normalized * Forca);
        }

        if (distanciaJogador > 20)
        {
            GameObject.Destroy(gameObject);
        }
    }

    public void Empurrar(Collider other)
    {
        rb.AddExplosionForce(ForcaExplosao, other.transform.position, 5F);
    }

    bool NoChao()
    {
        return Physics.Raycast(transform.position, Vector3.down, distanciaChao + 0.1F);
    }
}
