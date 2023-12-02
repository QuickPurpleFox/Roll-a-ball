using System;
using UnityEngine;

public class Boot : MonoBehaviour
{
    private Animator _anim;
    
    public delegate void ButtonPressed(GameObject sender, EventArgs e);
    public static event ButtonPressed ButtonPressedEvent;
    
    private void Start()
    {
        _anim = GetComponent<Animator>();
        _anim.StopPlayback();
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("[Kolizja] gracz->button");
            _anim.SetTrigger("Collision");
            ButtonPressedEvent?.Invoke(gameObject, new EventArgs());
        }
    }

    private void OnCollisionExit(Collision other)
    {
        _anim.SetTrigger("Collision");
    }
}
