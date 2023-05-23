using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float turnSpeed = 10f;

    public Rigidbody rb;
    public float jumpAmount = 10;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        //Manual forward movement
        transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);
        //Manual lateral movement
        
        transform.Translate(Vector3.right * turnSpeed * Time.deltaTime * horizontalInput);

        //transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpAmount, ForceMode.Impulse);
        }

        if (Input.GetKey("W"))
        {
            anim.SetBool("move", true);
        }

        if (!Input.GetKey("W"))
        {
            anim.SetBool("move", false);
        }
    }
}
