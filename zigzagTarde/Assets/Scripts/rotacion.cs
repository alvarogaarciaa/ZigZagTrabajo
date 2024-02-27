using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class rotacion : MonoBehaviour
{
    public float speed = 30.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime, Space.World);
    }
}
