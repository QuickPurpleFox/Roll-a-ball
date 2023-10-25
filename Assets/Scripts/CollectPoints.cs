using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollectPoints : MonoBehaviour
{
    public delegate void AddPoints(GameObject sender, EventArgs e);
    public static event AddPoints AddPointEvent;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(10 * Time.deltaTime, 0, 0); 
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            AddPointEvent?.Invoke(gameObject, new EventArgs());
            this.gameObject.SetActive(false);
        }
    }
}
