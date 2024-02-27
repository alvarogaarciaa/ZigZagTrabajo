using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoqueBola : MonoBehaviour
{
    public GameObject particulas;

    void OnDestroy(){
        Vector3 posactual = new Vector3(transform.position.x, 0.5f, transform.position.z);
        Instantiate(particulas, transform.position, particulas.transform.rotation);
    }
    
}

