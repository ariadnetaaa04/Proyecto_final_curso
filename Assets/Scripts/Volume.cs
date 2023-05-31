using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Volume : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public Image imageMute;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volumeAudio", 0.5f); //guardar posicion slider. PlayerPref = variable que se mantiene guardada en el juego. Valor predefinido 0.5
        AudioListener.volume = slider.value; //volumen del juego es igual al valor del slider
        IsMute();
    }

    public void ChangeSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("volumeAudio", sliderValue); //SetFloat le da un valor a la variable  
        AudioListener.volume = slider.value;
        IsMute();
    }
    public void IsMute() //revisa si esta a 0
    {
        if (sliderValue == 0)
        {
            imageMute.enabled = true;
        }
        else
        {
            imageMute.enabled = false;
        }
    }
}
