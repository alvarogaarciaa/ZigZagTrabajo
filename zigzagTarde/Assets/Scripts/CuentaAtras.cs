using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CuentaAtras : MonoBehaviour
{
    private Button boton;
    public Image imagen;
    public Sprite[] numeros;
    public Text texto;
    // Start is called before the first frame update
    void Start()
    {
        //boton = GameObject.FindAnyObjectByType<Button>();
        boton = GameObject.FindWithTag("BotonSalir").GetComponent<Button>();
        boton.onClick.AddListener(Empezar);
    }
    void Empezar()
    {
        imagen.gameObject.SetActive(true);
        boton.gameObject.SetActive(false);
        texto.gameObject.SetActive(false);

        StartCoroutine(PonerNumeros());
        //SceneManager.LoadScene("Menu");
    }

    IEnumerator PonerNumeros()
    {
        for (int i = 0; i < numeros.Length; i++)
        {
            imagen.sprite = numeros[i];
            yield return new WaitForSeconds(1);
        }
        SceneManager.LoadScene("Nivel1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
