using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inicio : MonoBehaviour
{
	public Transfer _transfer;
	public Traduccion _traduccion;
	public Text Press_Start;
	public Text Continuar_Empezar;
	public Text Borrar_Info;
	public Text Info;
	public Text Config; 

	public GameObject GameObject_Start;
	public GameObject GameObject_Info;
	public GameObject Anti_Destructor;

	public Transform Flecha; //Posiciones:    "0": X:-1.1 , Y: 0.47   //  "1": X:-1.1 , Y: 0.35    //    "2": X:-1.1 , Y: 0.23    //    "2-3": X: 0.94 , Y: -0.59
	private int Opcion_Selecionada_Menu_2 = 0; // "0": CONTINUAR/NUEVA , "1": BORRAR PARTIDA/INFO , "2":Info "2-3":CONFIG 

	public GameObject GameObject_Menu_0;
	public GameObject GameObject_Menu_1;
	public GameObject GameObject_Menu_2;

	private bool Anti_Destrcutor_bool = false;
	private bool Texto_Eliminado = false;

	private int Menu_Selecionado = 0;  // "0": Inicio , "1": Selector , "2": Opciones
	private float Tiempo1 = 0.0f;
	private float Tiempo2;


	public void Start()
	{
		Press_Start.text = _traduccion.Traducion_Json_Final.Traducion[_transfer.transfer_guardado.Guardat[0].Idioma].Pulsa_Start;
		Info.text = _traduccion.Traducion_Json_Final.Traducion[_transfer.transfer_guardado.Guardat[0].Idioma].Informacion_Menu;
		Config.text = _traduccion.Traducion_Json_Final.Traducion[_transfer.transfer_guardado.Guardat[0].Idioma].Configuracion;

		if (_transfer.transfer_guardado.Guardat[0].Partida_Creada)
		{
			GameObject_Info.SetActive(true);	
			Continuar_Empezar.text = _traduccion.Traducion_Json_Final.Traducion[_transfer.transfer_guardado.Guardat[0].Idioma].Continuar;
			Borrar_Info.text = _traduccion.Traducion_Json_Final.Traducion[_transfer.transfer_guardado.Guardat[0].Idioma].Borrar_Menu;
		}
		else if (!_transfer.transfer_guardado.Guardat[0].Partida_Creada)
		{
			GameObject_Info.SetActive(false);
			Continuar_Empezar.text = _traduccion.Traducion_Json_Final.Traducion[_transfer.transfer_guardado.Guardat[0].Idioma].Empezar;
			Borrar_Info.text = _traduccion.Traducion_Json_Final.Traducion[_transfer.transfer_guardado.Guardat[0].Idioma].Informacion_Menu;
		}
	}
	public void Update()
	{
		switch (Menu_Selecionado)
		{
			case 0:
				Inicio_Inicio();
				break;
			case 1:
				Inicio_Selecion();
				break;
			case 2:
				Inicio_Opciones();
				break;
		}
	}
	private void Inicio_Inicio()
	{
		if (Texto_Eliminado && Tiempo1 >= 0.12f)
		{
				GameObject_Start.SetActive(true);

				Tiempo1 = 0.0f;
				Texto_Eliminado = false;
		}
		if (!Texto_Eliminado && Tiempo1 >= 0.12f)
		{
				GameObject_Start.SetActive(false);

				Tiempo1 = 0.0f;
				Texto_Eliminado = true;

		}
		Tiempo1 = Tiempo1 + 0.1f * Time.deltaTime;

		if (Input.anyKey || Input.anyKeyDown)
		{
			GameObject_Menu_0.SetActive(false);
			GameObject_Menu_1.SetActive(true);
			Menu_Selecionado = 1;
		}
		// Debug.Log(Tiempo1);
	}
	private void Inicio_Selecion()
	{
		switch (Opcion_Selecionada_Menu_2)
		{
			case 0:

				break;
			case 1:

				break;
			case 2:

				break;
		}
	}
	private void Inicio_Opciones()
	{ }
	public void Awake()
	{
		if (!Anti_Destrcutor_bool)
		{
			DontDestroyOnLoad(Anti_Destructor);
			Anti_Destrcutor_bool = true;
		}
	}
}
