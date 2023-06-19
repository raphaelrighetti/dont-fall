using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComportamentoSelecaoSkin : MonoBehaviour
{
    public Slider RedSlider;
    public Slider GreenSlider;
    public Slider BlueSlider;
    public Image Imagem;
    private float red;
    private float green;
    private float blue;

    void Awake()
    {
        red = PlayerPrefs.GetFloat("Cor Jogador R", 255);
        green = PlayerPrefs.GetFloat("Cor Jogador G", 255);
        blue = PlayerPrefs.GetFloat("Cor Jogador B", 255);

        RedSlider.value = red;
        GreenSlider.value = green;
        BlueSlider.value = blue;
    }

    public void AtualizarCorJogador()
    {
        red = RedSlider.value;
        green = BlueSlider.value;
        blue = GreenSlider.value;

        PlayerPrefs.SetFloat("Cor Jogador R", red);
        PlayerPrefs.SetFloat("Cor Jogador G", green);
        PlayerPrefs.SetFloat("Cor Jogador B", blue);

        float redPct = red / RedSlider.maxValue;
        float greenPct = green / GreenSlider.maxValue;
        float bluePct = blue / BlueSlider.maxValue;

        Color cor = new Color(redPct, greenPct, bluePct);
        Imagem.color = cor;
    }
}
