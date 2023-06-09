using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player_life : MonoBehaviour
{
    public float life = 100;
    public Image barraDeVida; //sprite
    public float currentHealth;
    public TMP_Text GameOverText;
    private bool GameOver;

    public int quantity;
    public float damageTime;
    float currentDamageTime;

    public AudioClip deathAudioClip;
    private AudioSource audioSource;

    private void Start()
    {
        GameOver = false;
        currentHealth = life;

        audioSource = GetComponent<AudioSource>();
    }
void Update()
    {
        life = Mathf.Clamp(life, 0, 100); //no pase de un maximo ni disminuya del minimo
        barraDeVida.fillAmount = life / 100;
        
        if (life == 0)
            {
                Die();
            }
    }
    
    public void Die()
    {
        GameOverText.gameObject.SetActive(true);
        barraDeVida.gameObject.SetActive(false);
        GameOver = true;
        audioSource.PlayOneShot(deathAudioClip);
    }

}
