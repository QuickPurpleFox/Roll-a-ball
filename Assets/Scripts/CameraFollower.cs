using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform target;

    private Vector3 _offset;// = new Vector3(0f, 1.7f, -4f);

    private float _rotationX = 0f;
    private float _rotationZ = 0f;

    private Vector3 _rotation = new Vector3(0,0,0);
    private Vector3 _height = new Vector3(0, 0, 0);
    
    private float _lerpSpeed = 5.0f;

    private void Start()
    {
        _offset = GetComponent<Transform>().position - target.position;
        _height = new Vector3(0, _offset.y, 0);
    }
    void LateUpdate()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            _rotationX -= 5 * Time.deltaTime;
            _rotationZ -= 5 * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            _rotationX += 5 * Time.deltaTime;
            _rotationZ += 5 * Time.deltaTime;
        }

        if(_rotationX >= 360)
        {
            _rotationX = 0;
        }
        if (_rotationZ >= 360)
        {
            _rotationZ = 0;
        }

        _rotation = new Vector3 (Mathf.Cos(_rotationZ), 0, Mathf.Sin(_rotationX));

        transform.position = target.position + (_rotation * _offset.z) + _height;
  

        transform.LookAt(target);
    }
    /*
     * Put a collider on the camera (sphere or box).
     * Make sure you make a physics material with no friction,
     * and add it to the collider (so the camera doesnt slow down when it hits, say, a wall, due to drag).
     * 
     * 
     * if the camera collides with something
     * 
     * lerp camera in Z direction towards playerObject to minimum distance from playerObject (that way camera never goes through playerObject)
     * 
     * if camera is at minimum distance, lerp opacity of playerObject material to 30% (so player doesnt block view of environment)
     * 
     * if camera exits collision
     * 
     * lerp camera in Z direction away from playerObject to maximum distance from player
     * lerp playerObject material opacity to 100%
     */
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision detected");
        Vector3 directionToPlayer = (target.position - transform.position).normalized;
        Vector3 targetPosition = target.position - directionToPlayer * 1f;
        transform.position = Vector3.Lerp(transform.position, targetPosition, _lerpSpeed * Time.deltaTime);
    }
}
