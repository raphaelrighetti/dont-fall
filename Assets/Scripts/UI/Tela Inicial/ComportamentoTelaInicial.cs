using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComportamentoTelaInicial : MonoBehaviour
{
    public void IniciarJogo()
    {
        SceneManager.LoadScene("Game");
    }

    public void ExibirOpcoes()
    {
        Debug.Log("Devia mostrar as opções!");
    }
}
