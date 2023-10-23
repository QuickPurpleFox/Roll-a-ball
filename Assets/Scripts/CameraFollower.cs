using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform target;

    private Vector3 offset;// = new Vector3(0f, 1.7f, -4f);

    // Update is called once per frame
    private void Start()
    {
        offset = GetComponent<Transform>().position - target.position;
    }
    void LateUpdate()
    {
        float mouseY = Input.GetAxis("Mouse X");
        float mouseX = Input.GetAxis("Mouse Y");

        Quaternion deltaRotation = target.rotation * Quaternion.Inverse(transform.rotation);
        //offset = Quaternion.AngleAxis(deltaRotation.y, Vector3.up) * offset;
        //transform.rotation = Quaternion.Euler(1f, transform.eulerAngles.y, transform.eulerAngles.z);

        transform.RotateAround(target.transform.position, Vector3.up, 20);

        transform.position = target.position + offset;
        transform.LookAt(target);
    }
}
