using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocos : MonoBehaviour
{
    public int blocoTipo;
    void Start()
    {
        
    }

    private void OnTriggerEnter (Collider other)
    {

        if (other.gameObject.tag == "Espada")
        {
            
            if (blocoTipo == 1)
            {
                Game_Controller.score++;

                GetComponent<Rigidbody>().AddForce(new Vector3(-5.0f, 0.0f, 0.0f));
            }
            else if (blocoTipo == 2)
            {
                GetComponent<Rigidbody>().AddForce(new Vector3(5.0f, 0.0f, 0.0f));
            }

            Destroy(gameObject, 3.0f);
        }

        

    }
}
