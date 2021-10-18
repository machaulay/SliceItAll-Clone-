using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espada_Script : MonoBehaviour
{
    public float rotateForce;
    public float moveForce;


    [Header("Mouse")]
    public float moveForceY;
    public float moveForceZ;

    [Header("Touch")]
    public float moveForceYTouch;
    public float moveForceZTouch;


    private Rigidbody _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        

        MouseMove();
        TouchMove();
    }

    private void TouchMove()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _rb.isKinematic = false;
                    _rb.AddForce(new Vector3(0.0f, moveForceYTouch, moveForceZTouch));
                    _rb.AddTorque(transform.right * moveForce * rotateForce);
                    break;
                case TouchPhase.Moved:

                    break;
                case TouchPhase.Ended:

                    break;
            }
        }
    }

    private void MouseMove()
    {
        if (Input.GetMouseButtonDown(0) && Game_Controller.isPlaying)
        {

            _rb.isKinematic = false;
            _rb.AddForce(new Vector3(0.0f, moveForceY, moveForceZ));
            _rb.AddTorque(transform.right * moveForce * rotateForce);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("chao"))
        {
            Game_Controller.gameOver = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Base")) {
            _rb.isKinematic = true;
            Game_Controller.startGame = true;
        }

    }

    

}
