using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComportamentoTelaInicial : MonoBehaviour
{
    public GameObject PainelTelaInicial;
    public GameObject PainelComoJogar;

    void Start()
    {
        Time.timeScale = 1;
    }

    public void IniciarJogo()
    {
        SceneManager.LoadScene("Game");
    }

    public void SelecionarSkin()
    {
        SceneManager.LoadScene("SelecaoSkin");
    }

    public void ExibirOpcoes()
    {
        Debug.Log("Devia mostrar as opções!");
    }

    public void AlternarComoJogar()
    {
        PainelTelaInicial.SetActive(!PainelTelaInicial.activeSelf);
        PainelComoJogar.SetActive(!PainelComoJogar.activeSelf);
    }
}
