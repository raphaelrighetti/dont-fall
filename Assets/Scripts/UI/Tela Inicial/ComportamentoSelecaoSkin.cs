using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ComportamentoSelecaoSkin : MonoBehaviour
{
    public Slider RedSlider;
    public Slider GreenSlider;
    public Slider BlueSlider;
    public GameObject JogadorMenu;
    private float red;
    private float green;
    private float blue;
    private bool iniciado = false;
    private Renderer jogadorRenderer;

    void Start()
    {
        jogadorRenderer = JogadorMenu.GetComponent<Renderer>();

        red = PlayerPrefs.GetFloat("Cor Jogador R", 255);
        green = PlayerPrefs.GetFloat("Cor Jogador G", 255);
        blue = PlayerPrefs.GetFloat("Cor Jogador B", 255);

        RedSlider.value = red;
        GreenSlider.value = green;
        BlueSlider.value = blue;

        MudarCorObjeto();

        iniciado = true;
    }

    public void AtualizarCorJogador()
    {
        if (!iniciado)
        {
            return;
        }

        red = RedSlider.value;
        green = BlueSlider.value;
        blue = GreenSlider.value;

        PlayerPrefs.SetFloat("Cor Jogador R", red);
        PlayerPrefs.SetFloat("Cor Jogador G", green);
        PlayerPrefs.SetFloat("Cor Jogador B", blue);

        MudarCorObjeto();
    }

    public void MudarCorObjeto()
    {
        float redPct = red / RedSlider.maxValue;
        float greenPct = green / GreenSlider.maxValue;
        float bluePct = blue / BlueSlider.maxValue;

        Color cor = new Color(redPct, greenPct, bluePct);
        jogadorRenderer.material.color = cor;
    }

    public void Voltar()
    {
        SceneManager.LoadScene("TelaInicial");
    }
}
