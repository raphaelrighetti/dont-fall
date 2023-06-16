using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorteJogador : MonoBehaviour, IMatavel
{
    public float DistanciaQuedaMax;
    public Canvas UI;
    private ComportamentoGameUI scriptComportamentoUI;
    private StatusJogador statusJogador;

    void Start()
    {
        scriptComportamentoUI = UI.GetComponent<ComportamentoGameUI>();
        statusJogador = GameObject.FindWithTag("Jogador").GetComponent<StatusJogador>();
    }

    void FixedUpdate()
    {
        if (transform.position.y <= -DistanciaQuedaMax && statusJogador.Vivo)
        {
            Morrer();
        }
    }

    public void Morrer()
    {
        statusJogador.Vivo = false;

        scriptComportamentoUI.GameOver();
    }
}
