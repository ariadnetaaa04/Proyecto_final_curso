using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 1.5f;

    public Rigidbody rb;
    public float jumpForce = 8f;
    private bool isJumping = false;
    Animator anim;

    private int score; //canva
    private int plusPoints = 10;

    public TMP_Text scoreText;
    public TMP_Text GameOverText;
    public TMP_Text VictoryText;
    private bool GameOver;

    private AudioSource audioSource;

    private static readonly int ToWalkHash = Animator.StringToHash("ToWalk");



    // Start is called before the first frame update
    void Start()
    {
        GameOver = false;
        score=0; 
        GameOverText.gameObject.SetActive(false);
        VictoryText.gameObject.SetActive(false);
        //Calling the function so the score for the canva gets updated
        UpdateScore();

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        //para confinarlo en la pantalla durante el juego
        Cursor.lockState = CursorLockMode.Confined;

        audioSource = GetComponent<AudioSource>();

        
    }

    // Update is called once per frame
    void Update()
    {
       
        float moveInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * moveInput * moveSpeed * Time.deltaTime);

        
        float rotationInput = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up * rotationInput * rotationSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("Options");
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isJumping = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            score++;
            UpdateScore();
            audioSource.Play();
            Destroy(other.gameObject);
        }

        if (other.CompareTag("End"))
        {
            Victory();
        }
    }

    private void UpdateScore()
    {
        //The variable that represents the text and its text string. "The text" + the variable of the points 
        scoreText.text = "Coins: " + score;
    }

    private void Victory()
    {
        VictoryText.gameObject.SetActive(true);
        Time.timeScale = 0;
        GameOver = true;
    }
}
