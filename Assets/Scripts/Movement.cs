using UnityEngine;

public class Movement : MonoBehaviour
{
    public new Rigidbody rigidbody;
    public float speed = 1f;
    public float gravity = 9.8f;

    [SerializeField]
    private float vSpeed = 0f;
    private bool _isGrounded = true;

    private float _groundCheckDistance;
    private float _bufferDistance = 0.00001f;
    private Vector3 _upSide;

    void Start()
    {
        _upSide = GetComponent<Transform>().up;
        _groundCheckDistance = GetComponent<SphereCollider>().radius + _bufferDistance;
    }
    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float pitch = Input.GetAxisRaw("Vertical");


        if (_isGrounded)
        {
            vSpeed = 0f;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _isGrounded = false;
                vSpeed = 0.5f * speed;
            }
        }
        else
        {
            vSpeed -= gravity * Time.deltaTime;
        }

        Vector3 movement = new Vector3(horizontal, vSpeed, pitch);

        if (_isGrounded)
        {
            rigidbody.AddForce(Camera.main.transform.TransformDirection(movement.normalized * speed));
        }
        else
        {
            rigidbody.AddForce(movement.normalized * speed);
        }

        RaycastHit ray;
        if (Physics.Raycast(transform.position, -_upSide, out ray, _groundCheckDistance))
        {
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
        }
        Debug.DrawRay(transform.position, -_upSide * _groundCheckDistance, Color.green, 5);
    }  
}
