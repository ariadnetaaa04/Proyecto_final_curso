using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 5f;
  
    private float turnSpeed = 10f;

    public Rigidbody rb;
    public float jumpAmount = 10;
    // Start is called before the first frame update
    void Start()
    {
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
    }
}
