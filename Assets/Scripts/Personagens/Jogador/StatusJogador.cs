using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusJogador : MonoBehaviour
{
    public bool Vivo;
    public float Velocidade;
    public float ForcaPulo;
    public float ForcaDash;

    void Awake()
    {
        float r = PlayerPrefs.GetFloat("Cor Jogador R") / 255;
        float g = PlayerPrefs.GetFloat("Cor Jogador G") / 255;
        float b = PlayerPrefs.GetFloat("Cor Jogador B") / 255;

        GetComponent<Renderer>().material.color = new Color(r, g, b);
    }
}
