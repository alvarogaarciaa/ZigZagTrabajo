using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class rotacion : MonoBehaviour
{
    public float speed = 100.0f;
    public AudioClip sonido;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pelota"))
        {
            // Reproducir sonido
            AudioSource.PlayClipAtPoint(sonido, transform.position);
        }
    }
}
