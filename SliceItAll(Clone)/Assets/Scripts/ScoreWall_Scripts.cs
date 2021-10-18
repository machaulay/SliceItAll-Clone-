using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreWall_Scripts : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("punho"))
        {
            Debug.Log("Punho");

            GameObject.Find("Espada").GetComponent<Rigidbody>().AddForce(-transform.forward * 2000f * Time.deltaTime);
        }

        if (other.gameObject.CompareTag("Espada"))
        {
            GameObject.Find("Espada").GetComponent<Rigidbody>().isKinematic = true;
            Game_Controller.carregarCena = true;

        }

    }
}
