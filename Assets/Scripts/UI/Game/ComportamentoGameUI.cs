using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ComportamentoGameUI : MonoBehaviour
{
    public GameObject PainelGameOver;
    public GameObject PainelMenuPause;
    public TMP_Text TextoTempoSobrevivencia;
    public TMP_Text TextoMelhorTempo;
    public TMP_Text NumeroInimigosMortos;
    public Slider TemporizadorDash;
    private int inimigosMortos;
    private float tempoSobrevivido;
    private float melhorTempo;
    private bool pausado = false;

    void Start()
    {
        melhorTempo = PlayerPrefs.GetFloat("MelhorTempo", 0);
    }

    public void GameOver()
    {
        tempoSobrevivido = Time.timeSinceLevelLoad;
        AjustaMelhorTempo(tempoSobrevivido);

        FormataTextoTempoSobrevivencia();
        FormataTextoMelhorTempo();

        PainelGameOver.SetActive(true);
    }

    public void AlternarPause()
    {
        if (!pausado)
        {
            Pausar();
        }
        else
        {
            Despausar();
        }

        pausado = !pausado;
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene("Game");
    }

    public void TelaInicial()
    {
        SceneManager.LoadScene("TelaInicial");
    }

    public void AtualizaTemporizadorDash(float contador, float temporizadorMax)
    {
        if (TemporizadorDash.maxValue != temporizadorMax)
        {
            TemporizadorDash.maxValue = temporizadorMax;
        }

        if (contador >= temporizadorMax)
        {
            TemporizadorDash.value = temporizadorMax;
        }
        else
        {
            TemporizadorDash.value = contador;
        }
    }

    public void AtualizarInimigosMortos()
    {
        inimigosMortos++;

        NumeroInimigosMortos.text = inimigosMortos.ToString();
    }

    private void Pausar()
    {
        Time.timeScale = 0;

        PainelMenuPause.SetActive(true);
    }

    private void Despausar()
    {
        Time.timeScale = 1;

        PainelMenuPause.SetActive(false);
    }

    private void AjustaMelhorTempo(float tempo)
    {
        if (tempo > melhorTempo)
        {
            melhorTempo = tempo;
            PlayerPrefs.SetFloat("MelhorTempo", melhorTempo);
        }
    }

    private void FormataTextoTempoSobrevivencia()
    {
        int min = (int)tempoSobrevivido / 60;
        int s = (int)tempoSobrevivido % 60;

        string texto = $"{min}min e {s}s";

        TextoTempoSobrevivencia.text = texto;
    }

    private void FormataTextoMelhorTempo()
    {
        int min = (int)melhorTempo / 60;
        int s = (int)melhorTempo % 60;

        string texto = $"{min}min e {s}s";

        TextoMelhorTempo.text = texto;
    }
}
