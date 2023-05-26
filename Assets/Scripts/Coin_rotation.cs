using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_rotation : MonoBehaviour
{
    private void Update()
    {
        // Rotar la moneda
        transform.Rotate(new Vector3(90, 0, 0) * UnityEngine.Time.deltaTime);
    }

   
}
