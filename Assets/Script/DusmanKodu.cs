using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanKodu : MonoBehaviour
{
    private float health;
    void Start()
    {
        health = 2;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
            health = 1;
        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }
}
