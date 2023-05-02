using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    public float velocidad = 5;
    public float salto = 7;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {

        //Capturo el movimiento en horizontal y vertical de nuestro teclado
        float movimientoH = Input.GetAxis("Horizontal");
        float movimientoV = Input.GetAxis("Vertical");

        //Genero el vector de movimiento asociado, teniendo en cuenta la velocidad
        Vector3 movimiento = new Vector3(movimientoH * velocidad, 0.0f, movimientoV * velocidad);

        //Aplico ese movimiento al RigidBody del jugador
        rb.AddForce(movimiento);

       

        //Compruebo si el jugador está en el suelo antes de saltar (para que no vuele)
        /*private bool isSuelo()
        {

            //Genero el array de colisiones de la esfera/jugador pasando su centro y su radio
            Collider[] colisiones = Physics.OverlapSphere(transform.position, 0.5f);
            //Recorro ese array y si está colisionando con el suelo devuelvo true
            foreach (Collider colision in colisiones)
            {
                if (colision.tag == "Suelo")
                {
                    return true;
                }
            }
            return false;
        }
         //Si pulsa el botón de saltar y está en el suelo
        if (Input.GetButton("Jump") && isSuelo())
        {
            //Aplico el movimiento vertical con la potencia de salto
            rb.velocity += Vector3.up * salto;
        }
         
         */
    }
}
