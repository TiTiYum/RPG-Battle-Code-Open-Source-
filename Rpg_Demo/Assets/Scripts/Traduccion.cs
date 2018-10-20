using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using System;
using System.IO;

public class Traduccion : MonoBehaviour
{
	private string Traducion = "/Datos/Traducion.Json";
	public Traducion_Json Traducion_Json_Final;

	void Start()
	{
		string datos_de_solo_lectura = File.ReadAllText(Application.dataPath + Traducion);

		Traducion_Json_Final = JsonUtility.FromJson<Traducion_Json>(datos_de_solo_lectura);
	}
}
	[Serializable]
	public class Traducion : ISerializationCallbackReceiver
	{
	// "0": ESPAÑOL \\
	// "1": ENGLISH \\

	//MENU INICIO\\
	public string Pulsa_Start;
	public string Continuar;
	public string Empezar;
	public string Borrar_Menu;
	public string Informacion_Menu;
	public string Configuracion;


	//Carteles\\
	public string Cartel_0;
	public string Cartel_1;
	public string Cartel_2;
	public string Cartel_3;


	//NPC\\
	public string NPC_0;
	public string NPC_1;
	public string NPC_2;
	public string NPC_3;
	public string NPC_4;


	void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
		}
		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
		}
	}
	[Serializable]
	public class Traducion_Json
	{
		public List<Traducion> Traducion;
	}

