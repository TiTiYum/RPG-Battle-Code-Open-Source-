using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using System;
using System.IO;

public class Transfer : MonoBehaviour
{  //Para en este o en otros scripts usar los datos
	public Base_Datos_Movimientos transfer_movimientos_final;
	public Base_Datos_Enemigos transfer_enemigos_final;
	public Base_Datos_Objectos transfer_objecto_final;
	public Base_Datos_Guardado transfer_guardado;

	//LLama ah la ruta de donde estan esos archivos asin para facil haceso
	private string Lugar_de_solo_lectura = "/Datos/ItemsLectura.Json";
	private string Lugar_de_guardado = "/Datos/Guardado.Json";

	void Start()
	{   //Lee lo que ahi dentro de esos archivos
        string datos_de_solo_lectura = File.ReadAllText(Application.dataPath + Lugar_de_solo_lectura);

		string datos_de_guardado = File.ReadAllText(Application.dataPath + Lugar_de_guardado);

		//Transforma lo de json ah las variables serializadas del script
		transfer_movimientos_final = JsonUtility.FromJson<Base_Datos_Movimientos>(datos_de_solo_lectura);
		transfer_enemigos_final = JsonUtility.FromJson<Base_Datos_Enemigos>(datos_de_solo_lectura);
		transfer_objecto_final = JsonUtility.FromJson<Base_Datos_Objectos>(datos_de_solo_lectura);

		transfer_guardado = JsonUtility.FromJson<Base_Datos_Guardado>(datos_de_guardado);
	}

	/*void Update()//Testeo de pruebas
	{ Debug.Log(transfer_movimientos_final.Moviment[0].Nombre_Moviment);
		Debug.Log(transfer_objecto_final.Objecte[1].Nombre_Objecte);
		Debug.Log(transfer_enemigos_final.Enemic[1].Nombre_Enemic);
		Debug.Log(transfer_guardado.Guardat[1].Nombre_Personje_Guardat);
	}*/
}

[Serializable] //Variables serializadas SOLO_LECTURA
public class Movimientos_Json : ISerializationCallbackReceiver
{
	public int ID_Moviment;

	public string Nombre_Moviment;
	public int Maximo_Moviment;
	public int Cansancio_Moviment;
	public int Dano_Moviment;
	public string Tipo1_Moviment;
	public string Tipo2_Moviment;
	public string Descripcion_Moviment;

	void ISerializationCallbackReceiver.OnBeforeSerialize()
	{
	}
	void ISerializationCallbackReceiver.OnAfterDeserialize()
	{
	}
}

[Serializable] //Variables serializadas SOLO_LECTURA
public class Objectos_Json : ISerializationCallbackReceiver
{
	public int ID_Objecte;

	public string Nombre_Objecte;
	public string Sprite_Objecte;
	public string Descripcion_Objecte;

	void ISerializationCallbackReceiver.OnBeforeSerialize()
	{
	}
	void ISerializationCallbackReceiver.OnAfterDeserialize()
	{
	}
}

[Serializable] //Variables serializadas SOLO_LECTURA
public class Enemigos_Json : ISerializationCallbackReceiver
{
	public int ID_Enemic;

	public string Nombre_Enemic;
	public string Sprite_Enemic;
	public string Descripcion_Enemic;
	public int Velozidad_Enemic;
	public int Defensa_Enemic;
	public int Ataque_Enemic;
	public int Vida_Enemic;
	public string Ataques1_Enemic;
	public string Ataques2_Enemic;
	public string Ataques3_Enemic;

	void ISerializationCallbackReceiver.OnBeforeSerialize()
	{
	}
	void ISerializationCallbackReceiver.OnAfterDeserialize()
	{
	}
}

[Serializable] //Variables serializadas GUARDADO
public class Guardado_Json : ISerializationCallbackReceiver
{

	public int Slot_ID_Guardat;

	public int Idioma; // "0": ESPAÑOL  ,  "1": English

	public int ID_Guardat;
	public int ID_Enemigo_Guardat;

	public string Nombre_Personje_Guardat;
	public int Nivel_Personaje_Guardat;
	public float XP_Personaje_Guardat;

	public int Vida_Maxima_Jugador_Guardat;
	public int Vida_Jugador_Guardat;

	public int Dano_Jugador_Guardat;
	public int Velozidad_Jugador_Guardat;
	public int Defensa_Jugador_Guardat;
	public int Cansancio_Jugador_Guardat;


	public int ID_Movimient_1_Guardat;
	public int Estamina_Movimient_1_Guardat;

	public int ID_Movimient_2_Guardat;
	public int Estamina_Movimient_2_Guardat;

	public int ID_Movimient_3_Guardat;
	public int Estamina_Movimient_3_Guardat;

	void ISerializationCallbackReceiver.OnBeforeSerialize()
	{
	}
	void ISerializationCallbackReceiver.OnAfterDeserialize()
	{
	}
}

[Serializable] //Todas las variables SOLO_LECTURA serializadas juntas gracias ah una lista 
public class Base_Datos_Movimientos
{
	public List<Movimientos_Json> Moviment;
}

[Serializable] //Todas las variables SOLO_LECTURA serializadas juntas gracias ah una lista
public class Base_Datos_Objectos
{
	public List<Objectos_Json> Objecte;
}

[Serializable] //Todas las variables SOLO_LECTURA serializadas juntas gracias ah una lista
public class Base_Datos_Enemigos
{
	public List<Enemigos_Json> Enemic;
}

[Serializable] //Todas las variables GUARDADo serializadas juntas gracias ah una lista
public class Base_Datos_Guardado
{
	public List<Guardado_Json> Guardat;
}



