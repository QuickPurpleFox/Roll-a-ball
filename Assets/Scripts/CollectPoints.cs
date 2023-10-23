using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollectPoints : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(10 * Time.deltaTime, 0, 0); 
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            this.gameObject.SetActive(false);

            other.gameObject.GetComponent<Movement>().AddPoints();
            //Movement.Instance.AddPoints();
        }
    }
}
