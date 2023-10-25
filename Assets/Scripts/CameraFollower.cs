using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform target;

    private Vector3 offset;// = new Vector3(0f, 1.7f, -4f);

    private float rotationX = 0f;
    private float rotationZ = 0f;

    private Vector3 rotation = new Vector3(0,0,0);
    private Vector3 height = new Vector3(0, 0, 0);

    private void Start()
    {
        offset = GetComponent<Transform>().position - target.position;
        height = new Vector3(0, offset.y, 0);
    }
    void LateUpdate()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            rotationX -= 5 * Time.deltaTime;
            rotationZ -= 5 * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            rotationX += 5 * Time.deltaTime;
            rotationZ += 5 * Time.deltaTime;
        }

        if(rotationX >= 360)
        {
            rotationX = 0;
        }
        if (rotationZ >= 360)
        {
            rotationZ = 0;
        }

        rotation = new Vector3 (Mathf.Cos(rotationZ), 0, Mathf.Sin(rotationX));

        transform.position = target.position + (rotation * offset.z) + height;
  

        transform.LookAt(target);
    }
}
