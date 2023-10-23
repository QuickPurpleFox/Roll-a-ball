using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float speed = 1f;
    public float gravity = 9.8f;
    public TMP_Text pointText;
    public TMP_Text winText;
    

    /*
    private static Movement _instance;
    public static Movement Instance
    {
        get 
        { 
            return _instance; 
        }
    }
    */

    [SerializeField]
    private int points = 0;
    [SerializeField]
    private float vSpeed = 0f;
    private Quaternion rotateValue;
    [SerializeField]
    private bool isGrounded = true;
    private int maxScore = 2;

    void Start()
    {
        winText.gameObject.SetActive(false);
    }

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

        //rotateValue = transform.rotation;
        //GetComponent<Rigidbody>().rotation = rotateValue * Quaternion.Euler(0, mouseY, 0);
        //vSpeed = vSpeed - (Gravity * (Time.deltaTime));
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
    public void AddPoints()
    {
        points++;
        pointText.text = "Score: " + points + "/" + maxScore;
        if(points/maxScore >= 1)
        {
            winText.gameObject.SetActive(true);
            NextScene();
            SceneManager.LoadScene("SecondScene");
        }
    }

    public IEnumerator NextScene()
    {
        yield return new WaitForSeconds(3);
    }
}
