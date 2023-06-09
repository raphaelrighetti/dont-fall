using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ComportamentoUI : MonoBehaviour
{
    public GameObject PainelGameOver;
    public TMP_Text TextoTempoSobrevivencia;
    public TMP_Text TextoMelhorTempo;
    private float tempoSobrevivido;
    private float melhorTempo;

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

    public void Reiniciar()
    {
        SceneManager.LoadScene("Game");
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
