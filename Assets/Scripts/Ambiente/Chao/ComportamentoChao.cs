using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ComportamentoChao : MonoBehaviour
{
    private float tempoAtivo;
    private float[] possiveisTempos = { 5, 10, 15, 20, 25 };
    private TMP_Text textoTempoAtivo;

    void Start()
    {
        textoTempoAtivo = transform.GetChild(0).GetChild(0).gameObject.GetComponent<TMP_Text>();

        tempoAtivo = possiveisTempos[Random.Range(0, possiveisTempos.Length)] + 1;

        AtualizaTextoTempoAtivo();
    }

    void Update()
    {
        tempoAtivo -= Time.deltaTime;

        AtualizaTextoTempoAtivo();

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
}
