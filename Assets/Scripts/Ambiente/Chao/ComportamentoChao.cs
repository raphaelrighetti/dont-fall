using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ComportamentoChao : MonoBehaviour
{
    public float ChanceCriacaoPlataforma;
    private float contadorCriacaoPlataforma;
    private float contadorCriacaoPlataformaMax;
    private float tempoAtivo;
    private float[] possiveisTempos = { 5, 10, 15 };
    private BoxCollider boxCollider;
    private TMP_Text textoTempoAtivo;
    private PlataformasDisponiveis plataformasDisponiveis;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        textoTempoAtivo = transform.GetChild(0).GetChild(0).gameObject.GetComponent<TMP_Text>();
        plataformasDisponiveis = GameObject.FindWithTag("Plataformas Disponiveis").GetComponent<PlataformasDisponiveis>();

        tempoAtivo = possiveisTempos[Random.Range(0, possiveisTempos.Length)] + 1;

        contadorCriacaoPlataformaMax = tempoAtivo / (tempoAtivo / 2);

        AtualizaTextoTempoAtivo();
    }

    void Update()
    {
        contadorCriacaoPlataforma += Time.deltaTime;

        if (contadorCriacaoPlataforma >= contadorCriacaoPlataformaMax)
        {
            int numeroAleatorio = Random.Range(0, 101);

            if (numeroAleatorio <= ChanceCriacaoPlataforma)
            {
                CriarPlataforma();
            }

            contadorCriacaoPlataforma = 0;
        }

        tempoAtivo -= Time.deltaTime;

        AtualizaTextoTempoAtivo();

        if (tempoAtivo >= 0.5 && tempoAtivo <= 1)
        {
            CriarPlataforma();
        }

        if (tempoAtivo <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void AtualizaTextoTempoAtivo()
    {
        int valorTexto = (int)tempoAtivo;
        textoTempoAtivo.text = valorTexto.ToString();
    }

    private void CriarPlataforma()
    {
        Vector3 posicaoNovaPlataforma = transform.position;

        switch (EscolherDirecaoNovaPlataforma())
        {
            case "Frente":
                posicaoNovaPlataforma.z += boxCollider.bounds.size.z;
                break;
            case "Direita":
                posicaoNovaPlataforma.x += boxCollider.bounds.size.x;
                break;
            case "Atrás":
                posicaoNovaPlataforma.z -= boxCollider.bounds.size.z;
                break;
            case "Esquerda":
                posicaoNovaPlataforma.z -= boxCollider.bounds.size.x;
                break;
        }

        if (Physics.OverlapBox(posicaoNovaPlataforma, boxCollider.bounds.extents / 2, transform.rotation).Length > 0)
        {
            return;
        }

        GameObject plataformaEscolhida =
            plataformasDisponiveis.Plataformas[Random.Range(0, plataformasDisponiveis.Plataformas.Length)];

        Instantiate(plataformaEscolhida, posicaoNovaPlataforma, transform.rotation);
    }

    private string EscolherDirecaoNovaPlataforma()
    {
        string[] direcoes = { "Frente", "Direita", "Atrás", "Esquerda" };
        string direcao = direcoes[Random.Range(0, direcoes.Length)];

        return direcao;
    }
}
