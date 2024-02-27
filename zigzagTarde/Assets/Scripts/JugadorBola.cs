using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class JugadorBola : MonoBehaviour
{
    public Camera camara;
    public GameObject suelo;
    public GameObject estrella;
    public GameObject particula;
    public float velocidad = 5.0f;
    public Text Contador;


    private Vector3 offset;
    private float ValX, ValZ;
    private Vector3 DireccionActual;
    private Transform suelo_actual;
    private int totalEstrellas = 0;
    // Start is called before the first frame update
    void Start()
    {
        offset = camara.transform.position;
        CrearSueloInicial();
        DireccionActual = Vector3.forward;
    }

    // Update is called once per frame
    void Update()
    {
        camara.transform.position = transform.position + offset;
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CambiarDireccion();
        }

        transform.Translate(DireccionActual * velocidad * Time.deltaTime);

    }


    private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Premio"))
            {
                Instantiate(particula, other.gameObject.transform.position, particula.transform.rotation);
                totalEstrellas++;
                Contador.text = "Puntos: " + totalEstrellas;
                Destroy(other.gameObject);
            }
        }

    private void OnCollisionExit(Collision other){
        if (other.gameObject.tag == "Suelo")
        {
            StartCoroutine(BorrarSuelo(other.gameObject));
        }
    }


    IEnumerator BorrarSuelo(GameObject suelo)
    {
        int estrella_aleatorio = Random.Range(0, 4);
        float aleatorio = Random.Range(0.0f, 1.0f);
        if (aleatorio > 0.5)
        {
            ValX += 6.0f;
        }
        else
        {
            ValZ += 6.0f;
        }

        suelo_actual = Instantiate(suelo, new Vector3(ValX, 0, ValZ), Quaternion.identity).transform;
        if (estrella_aleatorio < 1)
        {
            Instantiate(estrella, suelo_actual.position + (Vector3.up), estrella.transform.rotation);
        }

        yield return new WaitForSeconds(2);

        suelo.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        suelo.gameObject.GetComponent<Rigidbody>().useGravity = true;
        yield return new WaitForSeconds(2);
        
        Destroy(suelo);
    }

    void CambiarDireccion()
    {
        if (DireccionActual == Vector3.forward)
        {
            DireccionActual = Vector3.right;
        }
        else
        {
            DireccionActual = Vector3.forward;
        }
    }

    void CrearSueloInicial()
    {
        for (int i = 0; i < 3; i++)
        {
            ValZ += 6.0f;
            Instantiate(suelo, new Vector3(ValX, 0, ValZ), Quaternion.identity);
        }
    }
}
