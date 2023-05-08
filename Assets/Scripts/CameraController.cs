using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	//Referencia a nuestro jugador
	public GameObject jugador;
	public float speedH;
	public float speedV;

	private float h;
	private float v;

	//Para registrar la diferencia entre la posición de la cámara y la del jugador
	private Vector3 offset;

	void Start()
	{

		//diferencia entre la posición de la cámara y la del jugador
		offset = transform.position - jugador.transform.position;


	}

	// Se ejecuta cada frame, pero después de haber procesado todo. Es más exacto para la cámara
	void Update()
	{
		 h += speedH * Input.GetAxis("Mouse X");
		 v -= speedH * Input.GetAxis("Mouse Y");

		transform.eulerAngles = new Vector3(v, h, 0.0f);


	}
}

