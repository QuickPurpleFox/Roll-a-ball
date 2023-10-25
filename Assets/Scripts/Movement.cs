using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class Movement : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float speed = 1f;
    public float gravity = 9.8f;

    [SerializeField]
    private int points = 0;
    [SerializeField]
    private float vSpeed = 0f;
    private Quaternion rotateValue;
    [SerializeField]
    private bool isGrounded = true;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float pitch = Input.GetAxisRaw("Vertical");


        if (isGrounded)
        {
            vSpeed = 0f;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isGrounded = false;
                vSpeed = 0.5f * speed;
            }
        }
        else
        {
            vSpeed -= gravity * Time.deltaTime;
        }

        Vector3 movement = new Vector3(horizontal, vSpeed, pitch);

        rigidbody.AddForce(movement.normalized * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
