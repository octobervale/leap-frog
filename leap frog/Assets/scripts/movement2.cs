using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement2 : MonoBehaviour
{
    public float speede = 1f;
    public float jumpForcee = 0.5f;
    public float rotationSpeede = 100.0f;
    public bool isJumpinge = false;
    public bool isJumpOvere = false;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.I))
        {
            transform.position += transform.forward * speede * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.J))
        {
            transform.Rotate(Vector3.up, -rotationSpeede * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.L))
        {
           transform.Rotate(Vector3.up, rotationSpeede * Time.deltaTime);
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.K) && !isJumpinge)
        {
            rb.AddForce(new Vector3(0, jumpForcee, 0), ForceMode.Impulse);
            isJumpinge = true;
            isJumpOvere = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumpinge = false;
            isJumpOvere = false;
        }
    }
}
