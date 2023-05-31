using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 180f;

    private void Update()
    {
        // Movimiento con el teclado
        float moveInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * moveInput * moveSpeed * Time.deltaTime);

        // Rotaci�n con el rat�n
        float rotationInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * rotationInput * rotationSpeed * Time.deltaTime);
    }
}
