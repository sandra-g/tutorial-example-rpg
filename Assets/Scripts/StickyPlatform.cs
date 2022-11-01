using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")//si lo que collisiona (collision) es el player
        {
            collision.gameObject.transform.SetParent(transform);//hago q mi transform de la plataforma sea su padre.
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Player")//si lo que collisionó(collision) era player y se separa(se marca que chocaba y luego suelta)
        {
            collision.gameObject.transform.SetParent(null);//hago q mi transform de la plataforma sea su padre.
        }
    }
}
