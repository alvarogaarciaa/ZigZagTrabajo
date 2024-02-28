using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComenzarJuego : MonoBehaviour
{
    public void Comenzar()
    {
        SceneManager.LoadScene("Nivel1");
    }

    public void ComenzarPrincipio()
    {
        SceneManager.LoadScene("Start");
    }
}
