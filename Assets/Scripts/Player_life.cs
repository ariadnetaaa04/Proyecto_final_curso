using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player_life : MonoBehaviour
{
    public float life = 100;
    public Image barraDeVida; //sprite
    private float currentHealth;
    public TMP_Text GameOverText;
    private bool GameOver;

    private void Start()
    {
        GameOver = false;
        currentHealth = life;
    }
void Update()
    {
        life = Mathf.Clamp(life, 0, 100); //no pase de un maximo ni disminuya del minimo
        barraDeVida.fillAmount = life / 100;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // El jugador ha sido atacado por un enemigo
            // Reducir la vida del jugador
            currentHealth -= 10;

            // Realizar acciones adicionales si la vida llega a cero
            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        // Acciones a realizar cuando la vida del jugador llega a cero
        // Por ejemplo, reiniciar el nivel, mostrar un mensaje de game over, etc.
        Debug.Log("¡Game Over!");
        GameOverText.gameObject.SetActive(true);
        GameOver = true;
    }

    
}
