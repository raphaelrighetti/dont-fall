using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MorteJogador : MonoBehaviour
{

    public GameObject Canvas;

    void Update()
    {
        if (transform.position.y < -5)
        {
            Canvas.SetActive(true);

            if (Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene("Game");
            }
        }
    }
}
