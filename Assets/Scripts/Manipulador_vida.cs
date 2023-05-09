using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manipulador_vida : MonoBehaviour
{
    Player_life lifePlayer;
    public int quantity;
    public float damageTime;
    float currentDamageTime;

    // Start is called before the first frame update
    void Start()
    {
        lifePlayer = GameObject.FindWithTag("Player").GetComponent<Player_life>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            currentDamageTime += Time.deltaTime;
            if (currentDamageTime > damageTime)
            {
                lifePlayer.life += quantity;
                currentDamageTime = 0.0f;
            }
        }
    }
}
