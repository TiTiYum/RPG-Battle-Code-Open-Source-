using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

	public Transform Flecha; //Posiciones:    "0": X:-150.7 , Y: 3.75  //  "1": X:-150.7 , Y: 2.80    //    "2": X:-150.7 , Y: 1.82    //    "2-3": X: -134.2 , Y: -4.8
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

		if (Menu_Selecionado == 0)
		{
			GameObject_Menu_0.SetActive(true);
			Flecha.gameObject.SetActive(false);
		}
		if (Input.anyKey || Input.anyKeyDown && Menu_Selecionado == 0)
		{
			GameObject_Menu_0.SetActive(false);
			GameObject_Menu_1.SetActive(true);

			Flecha.gameObject.SetActive(true);
			Menu_Selecionado = 1;
		}
		// Debug.Log(Tiempo1);
	}
	private void Inicio_Selecion()
	{
		if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
		{
			if (Opcion_Selecionada_Menu_2 == 0 && _transfer.transfer_guardado.Guardat[0].Partida_Creada)
			{
				Opcion_Selecionada_Menu_2 = 3;
			}
			else if (Opcion_Selecionada_Menu_2 <= 3 && _transfer.transfer_guardado.Guardat[0].Partida_Creada)
			{
				Opcion_Selecionada_Menu_2 -= 1;
			}

			if (Opcion_Selecionada_Menu_2 == 0 && !_transfer.transfer_guardado.Guardat[0].Partida_Creada)
			{
				Opcion_Selecionada_Menu_2 = 3;
			}
			else if (Opcion_Selecionada_Menu_2 <= 3 && !_transfer.transfer_guardado.Guardat[0].Partida_Creada)
			{
				Opcion_Selecionada_Menu_2 -= 1;
			}
			if (Opcion_Selecionada_Menu_2 == 2 && !_transfer.transfer_guardado.Guardat[0].Partida_Creada)
			{
				Opcion_Selecionada_Menu_2 = 1;
			}
		}
		if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
		{
			if (Opcion_Selecionada_Menu_2 == 3 && _transfer.transfer_guardado.Guardat[0].Partida_Creada)
			{
				Opcion_Selecionada_Menu_2 = 0;
			}
			else if (Opcion_Selecionada_Menu_2 <= 2 && _transfer.transfer_guardado.Guardat[0].Partida_Creada)
			{
				Opcion_Selecionada_Menu_2 += 1;
			}


			if (Opcion_Selecionada_Menu_2 == 3 && !_transfer.transfer_guardado.Guardat[0].Partida_Creada)
			{
				Opcion_Selecionada_Menu_2 = 0;
			}
			else if (Opcion_Selecionada_Menu_2 <= 2 && !_transfer.transfer_guardado.Guardat[0].Partida_Creada)
			{
				Opcion_Selecionada_Menu_2 += 1;
			}

			if (Opcion_Selecionada_Menu_2 == 2 && !_transfer.transfer_guardado.Guardat[0].Partida_Creada)
			{
				Opcion_Selecionada_Menu_2 = 3;
			}
		}
		switch (Opcion_Selecionada_Menu_2)
		{
			case 0:
				Flecha.localPosition = new Vector2(-150.7f, 3.75f);
				break;
			case 1:
					Flecha.localPosition = new Vector2(-150.7f, 2.80f);
				break;
			case 2:
				if (!Texto_Eliminado)
				{
					Flecha.localPosition = new Vector2(-150.7f, 1.82f);
				}
				else
				{
					Flecha.localPosition = new Vector2(-134.2f, -4.8f);
					Opcion_Selecionada_Menu_2 = 3;
				}
				break;
			case 3:
				Flecha.localPosition = new Vector2(-134.2f, -4.8f);
				break;
		}
		if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))
		{
			switch (Opcion_Selecionada_Menu_2)
			{
				case 0:
					SceneManager.LoadSceneAsync(_transfer.transfer_guardado.Guardat[0].Ultimo_mapa_Guardado, LoadSceneMode.Single);
					break;
				case 1:

					break;
				case 2:

					break;
				case 3:
					GameObject_Menu_1.SetActive(false);
					GameObject_Menu_2.SetActive(true);
					break;
			}
			
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
