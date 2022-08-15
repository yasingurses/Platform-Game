using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamera : MonoBehaviour
{
    public Transform karakter;



    void Update()
    {
        if (karakter.position.x > transform.position.x)
        {
            transform.position = new Vector3(karakter.position.x, transform.position.y, transform.position.z);
        }
    }
}
