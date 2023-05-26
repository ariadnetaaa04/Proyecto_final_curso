using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float turnSpeed = 10f;

    public Rigidbody rb;
    public float jumpAmount = 10;
    Animator anim;

    private int score; //canva
    private int plusPoints = 10;

    public TMP_Text scoreText;
    public TMP_Text GameOverText;
    private bool GameOver;



    // Start is called before the first frame update
    void Start()
    {
        GameOver = false;
        score = 0;
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

        if (horizontalInput == 1)
        {
            anim.SetBool("move", true);
        }

        if (horizontalInput == 1)
        {
            anim.SetBool("move", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            // La moneda ha sido recolectada por el jugador
            // Aquí puedes agregar el código para aumentar la puntuación del jugador, por ejemplo.
            score++;
            Debug.Log("Points: " + score);
            // Destruir la moneda
            Destroy(gameObject.CompareTag("Coin"));
        }
    }

    private void UpdateScore()
    {
        //The variable that represents the text and its text string. "The text" + the variable of the points 
        scoreText.text = "Coins: " + score;
    }
}
