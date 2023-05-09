using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_life : MonoBehaviour
{
    public float life = 100;
    public Image barraDeVida; //sprite

    
    void Update()
    {
        life = Mathf.Clamp(life, 0, 100); //no pase de un maximo ni disminuya del minimo
        barraDeVida.fillAmount = life / 100;
    }
}
