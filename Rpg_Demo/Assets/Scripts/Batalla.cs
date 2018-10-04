using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.Sprites;

public class Batalla : MonoBehaviour
{
	   //OTROS SCRIPTSz
	public Transfer _transfer;

    //DATOS EN PANTALLA (NO REAL)  

	//Nombre de los jugadores
	public Text Nombre_Jugador_TxT;
    public Text Nombre_Enemigo_TxT;

	private string Nombre_Jugador_String;
	private string Nombre_Enemigo_String;

	//Nombre de los ataques
	public Text Atake_Primero_TxT;
    public Text Atake_Segundo_TxT;
    public Text Atake_Tercero_TxT;

	private string Atake_Primero_String;
	private string Atake_Segundo_String;
	private string Atake_Tercero_String;

	//Estamina total de los ataques_Nombre en pantalla
	public Text Atake_Primero_Estamina_TxT;
    public Text Atake_Segundo_Estamina_TxT;
    public Text Atake_Tercero_Estamina_TxT;

	private string Atake_Primero_Estamina_string;
	private string Atake_Segundo_Estamina_string;
	private string Atake_Tercero_Estamina_string;

	private int Atake_Primero_Dano_int;
	private int Atake_Segundo_Dano_int;
	private int Atake_Tercero_Dano_int;

	//Los GameObjects

	//DATOS EN SCRIPT (REAL)  

	//Datos de estadisticas
	//Jugador
	private int Velozidad_Jugador;
    private int Dano_Jugador;
    private int Defensa_Jugador;
    private int Cansancio_Jugador;
	private int Nivel_Jugador;

	private int Vida_Jugador;
	private int Vida_Maxima_Jugador;

	private string Tipo1_Jugador;
	private string Tipo2_Jugador;

	private float Movimiento_1_float;
	private float Movimiento_2_float;
	private float Movimiento_3_float;

	private int Movimiento_1_int;
	private int Movimiento_2_int;
	private int Movimiento_3_int;

	public Image Barra_De_Vida_Jugador;

	//Enemigo
	private int Velozidad_Enemigo;
    private int Dano_Enemigo;
    private int Defensa_Enemigo;
    private int Cansancio_Enemigo;
	private int Vida_Enemigo;
	private int Nivel_Enemigo;

	private string Tipo1_Enemigo;
	private string Tipo2_Enemigo;

	private int Movimiento_1_Enemigo_int;
	private int Movimiento_2_Enemigo_int;
	private int Movimiento_3_Enemigo_int;

	public Image Barra_De_Vida_Enemigo;

	//Maximo y minimo de los movimientos
	//1
	private int Max1_Movimiento;
	private int Estamina1_Movimiento;
	private int cansancio1_Movimiento;
	     //2
	private int Max2_Movimiento;
	private int Estamina2_Movimiento;
	private int cansancio2_Movimiento;
	     //3
	private int Max3_Movimiento;
	private int Estamina3_Movimiento;
	private int cansancio3_Movimiento;

	//Partida selecionada/enemigo selecionado

	private int Enemigo_Selecion_int = 1;  //El ID del enemigo es infinito 0,1,2,3,4,5... (En total infinitas asta el limite de enemigos es posible)
	private int Jugador_Selecion_int; //El ID del jugador es 0,1,2 (En total 3 partidas posibles del jugador)

	//Partida

	private int Partida_Selecionada = 1;

	private int Daño_Final;

	private int Random_Ataque_Enemigo;

	private bool La_Partida_ah_empezado;
	private bool Players_Selecionados;
	private bool Estats_Enemigo_Selecionados;
	private bool Estats_Jugador_Selecionados;
	private bool movimientos_Selecionados;

	//Estadisticas 

	public Text Velozidad_Estadistica_Jugador_TxT;
	public Text Dano_Estadistica_Jugador_TxT;
	public Text Defensa_Estadistica_Jugador_TxT;
	public Text Cansancio_Estadistica_Jugador_TxT;

	public Text Velozidad_Estadistica_Enemigo_TxT;
	public Text Dano_Estadistica_Enemigo_TxT;
	public Text Defensa_Estadistica_Enemigo_TxT;
	public Text Cansancio_Estadistica_Enemigo_TxT;

	private string Velozidad_Estadistica_Jugador_string;
	private string Dano_Estadistica_Jugador_string;
	private string Defensa_Estadistica_Jugador_string;
	private string Cansancio_Estadistica_Jugador_string;

	private string Velozidad_Estadistica_Enemigo_string;
	private string Dano_Estadistica_Enemigo_string;
	private string Defensa_Estadistica_Enemigo_string;
	private string Cansancio_Estadistica_Enemigo_string;

	//Calculos finales
	private int Dano_Final_Jugador;
	private int Vida_Final_Jugador;

	private int Calculo1_Jugador;
	private int Calculo2_Jugador;
	private int Calculo3_Jugador;
	private int Calculo4_Jugador;


	private int Dano_Final_Enemigo;
	private int Vida_Final_Enemigo;

	private int Calculo1_Enemigo;
	private int Calculo2_Enemigo;
	private int Calculo3_Enemigo;
	private int Calculo4_Enemigo;

	private bool Jugador_1r;
	private bool Enemigo_1r;
	private bool Jugador_2r;
	private bool Enemigo_2r;

	private bool Enemigo_Calcular_Vida_bool;
	private bool Jugador_Calcular_Vida_bool;

	private float Vida_maxima_Jugador_Float;
	private float Vida_maxima_Enemigo_Float;

	private float Vida_maxima_Jugador_Calculo;
	private float Vida_maxima_Enemigo_Calculo;

	private float Vida_Jugador_Float;
	private float Vida_Enemigo_Float;

	private bool Estadisticas_Bool;

	//ZONA
	public int minimo_de_nivel_enemigo;
	public int maximo_de_nivel_enemigo;

	void Start ()
    {
		La_Partida_ah_empezado = true;
		Players_Selecionados = false;
		Estats_Enemigo_Selecionados = false;
		Estats_Jugador_Selecionados = false;
		movimientos_Selecionados = false;
		Estadisticas_Bool = false;

		Enemigo_1r = false;
		Jugador_1r = false;

		Enemigo_Calcular_Vida_bool = false; 

		Nivel_Enemigo = Random.Range(minimo_de_nivel_enemigo, maximo_de_nivel_enemigo);

	}
	void Update ()
    {
		//Debug.Log(Nivel_Enemigo);

		if (La_Partida_ah_empezado)
		{
			switch (Partida_Selecionada)
			{
				case 1:
					Movimiento_1_int = _transfer.transfer_guardado.Guardat[0].ID_Movimient_1_Guardat;
					Movimiento_2_int = _transfer.transfer_guardado.Guardat[0].ID_Movimient_2_Guardat;
					Movimiento_3_int = _transfer.transfer_guardado.Guardat[0].ID_Movimient_3_Guardat;

					Estamina1_Movimiento = _transfer.transfer_guardado.Guardat[0].Estamina_Movimient_1_Guardat;
					Estamina2_Movimiento = _transfer.transfer_guardado.Guardat[0].Estamina_Movimient_2_Guardat;
					Estamina3_Movimiento = _transfer.transfer_guardado.Guardat[0].Estamina_Movimient_3_Guardat;

					Vida_Maxima_Jugador = _transfer.transfer_guardado.Guardat[0].Vida_Maxima_Jugador_Guardat;
					Vida_Jugador = _transfer.transfer_guardado.Guardat[0].Vida_Jugador_Guardat;
					Nivel_Jugador = _transfer.transfer_guardado.Guardat[0].Nivel_Personaje_Guardat;

					Jugador_Selecion_int = 0;

					La_Partida_ah_empezado = false;

					//Debug.Log("Partida 1 Selecionada");
					break;

				case 2:
					Movimiento_1_int = _transfer.transfer_guardado.Guardat[1].ID_Movimient_1_Guardat;
					Movimiento_2_int = _transfer.transfer_guardado.Guardat[1].ID_Movimient_2_Guardat;
					Movimiento_3_int = _transfer.transfer_guardado.Guardat[1].ID_Movimient_3_Guardat;

					Estamina1_Movimiento = _transfer.transfer_guardado.Guardat[1].Estamina_Movimient_1_Guardat;
					Estamina2_Movimiento = _transfer.transfer_guardado.Guardat[1].Estamina_Movimient_2_Guardat;
					Estamina3_Movimiento = _transfer.transfer_guardado.Guardat[1].Estamina_Movimient_3_Guardat;

					Vida_Maxima_Jugador = _transfer.transfer_guardado.Guardat[1].Vida_Maxima_Jugador_Guardat;
					Vida_Jugador = _transfer.transfer_guardado.Guardat[1].Vida_Jugador_Guardat;
					Nivel_Jugador = _transfer.transfer_guardado.Guardat[1].Nivel_Personaje_Guardat;

					Jugador_Selecion_int = 1;

					La_Partida_ah_empezado = false;


					//Debug.Log("Partida 2 Selecionada");
					break;

				case 3:
					Movimiento_1_int = _transfer.transfer_guardado.Guardat[2].ID_Movimient_1_Guardat;
					Movimiento_2_int = _transfer.transfer_guardado.Guardat[2].ID_Movimient_2_Guardat;
					Movimiento_3_int = _transfer.transfer_guardado.Guardat[2].ID_Movimient_3_Guardat;

					Estamina1_Movimiento = _transfer.transfer_guardado.Guardat[2].Estamina_Movimient_1_Guardat;
					Estamina2_Movimiento = _transfer.transfer_guardado.Guardat[2].Estamina_Movimient_2_Guardat;
					Estamina3_Movimiento = _transfer.transfer_guardado.Guardat[2].Estamina_Movimient_3_Guardat;

					Vida_Maxima_Jugador = _transfer.transfer_guardado.Guardat[2].Vida_Maxima_Jugador_Guardat;
					Vida_Jugador = _transfer.transfer_guardado.Guardat[2].Vida_Jugador_Guardat;
					Nivel_Jugador = _transfer.transfer_guardado.Guardat[2].Nivel_Personaje_Guardat;

					Jugador_Selecion_int = 2;

					La_Partida_ah_empezado = false;


					//Debug.Log("Partida 1 Selecionada");
					break;
			}
		}
		if (!La_Partida_ah_empezado)
		{
			//Mira si se ah selecionado los enemigos/jugador en pantalla procesados si es asin el if seguira
			if (!Players_Selecionados)
			{
				//Mira si el nombre esta selecionado y lo coloca
				if (Nombre_Enemigo_String == null)
				{

					Nombre_Enemigo_String = _transfer.transfer_enemigos_final.Enemic[Enemigo_Selecion_int].Nombre_Enemic;

					Nombre_Enemigo_TxT.text = Nombre_Enemigo_String;

					//Debug.Log("Nada de errores Enemigo:" + Nombre_Enemigo_String);
				}

				//Mira si el nombre esta selecionado y lo coloca
				if (Nombre_Jugador_String == null)
				{
					//Debug.Log("Nada de errores Jugador:" + Nombre_Jugador_String);
					Nombre_Jugador_String = _transfer.transfer_guardado.Guardat[Jugador_Selecion_int].Nombre_Personje_Guardat;

					Nombre_Jugador_TxT.text = Nombre_Jugador_String;
				}
				Players_Selecionados = true;
			}
			if (!Estats_Enemigo_Selecionados)
			{
				//Debug.Log("No ahy nada");
				Velozidad_Enemigo = _transfer.transfer_enemigos_final.Enemic[Enemigo_Selecion_int].Velozidad_Enemic;
				Defensa_Enemigo = _transfer.transfer_enemigos_final.Enemic[Enemigo_Selecion_int].Defensa_Enemic;
				Dano_Enemigo = _transfer.transfer_enemigos_final.Enemic[Enemigo_Selecion_int].Ataque_Enemic;
				Vida_Enemigo = _transfer.transfer_enemigos_final.Enemic[Enemigo_Selecion_int].Vida_Enemic;

				maximo_de_nivel_enemigo = maximo_de_nivel_enemigo + 1;

				Cansancio_Enemigo = 0;

				Velozidad_Estadistica_Enemigo_string = Velozidad_Enemigo + "E";
	            Dano_Estadistica_Enemigo_string = Dano_Enemigo + "E";
	            Defensa_Estadistica_Enemigo_string = Defensa_Enemigo + "E";
	            Cansancio_Estadistica_Enemigo_string = Cansancio_Enemigo + "E";

				Velozidad_Estadistica_Enemigo_TxT.text = Velozidad_Estadistica_Enemigo_string;
				Dano_Estadistica_Enemigo_TxT.text = Dano_Estadistica_Enemigo_string;
				Defensa_Estadistica_Enemigo_TxT.text = Defensa_Estadistica_Enemigo_string;
				Cansancio_Estadistica_Enemigo_TxT.text = Cansancio_Estadistica_Enemigo_string;

				Estats_Enemigo_Selecionados = true;
			}
			if (!movimientos_Selecionados)
			{
				//Debug.Log("Sin atakes");
				Atake_Primero_String = _transfer.transfer_movimientos_final.Moviment[Movimiento_1_int].Nombre_Moviment;
				Atake_Segundo_String = _transfer.transfer_movimientos_final.Moviment[Movimiento_2_int].Nombre_Moviment;
				Atake_Tercero_String = _transfer.transfer_movimientos_final.Moviment[Movimiento_3_int].Nombre_Moviment;

				Atake_Primero_TxT.text = Atake_Primero_String;
				Atake_Segundo_TxT.text = Atake_Segundo_String;
				Atake_Tercero_TxT.text = Atake_Tercero_String;

				Max1_Movimiento = _transfer.transfer_movimientos_final.Moviment[Movimiento_1_int].Maximo_Moviment;
				Max2_Movimiento = _transfer.transfer_movimientos_final.Moviment[Movimiento_2_int].Maximo_Moviment;
				Max3_Movimiento = _transfer.transfer_movimientos_final.Moviment[Movimiento_3_int].Maximo_Moviment;

				Atake_Primero_Estamina_string = Estamina1_Movimiento + "/" + Max1_Movimiento;
				Atake_Segundo_Estamina_string = Estamina2_Movimiento + "/" + Max2_Movimiento;
				Atake_Tercero_Estamina_string = Estamina3_Movimiento + "/" + Max3_Movimiento;

				Atake_Primero_Estamina_TxT.text = Atake_Primero_Estamina_string;
				Atake_Segundo_Estamina_TxT.text = Atake_Segundo_Estamina_string;
				Atake_Tercero_Estamina_TxT.text = Atake_Tercero_Estamina_string;

				Atake_Primero_Dano_int = _transfer.transfer_movimientos_final.Moviment[Movimiento_1_int].Dano_Moviment;
				Atake_Segundo_Dano_int = _transfer.transfer_movimientos_final.Moviment[Movimiento_2_int].Dano_Moviment;
				Atake_Tercero_Dano_int = _transfer.transfer_movimientos_final.Moviment[Movimiento_3_int].Dano_Moviment;

				movimientos_Selecionados = true;
			}
			if (!Estats_Jugador_Selecionados && !Estadisticas_Bool)
			{
				Velozidad_Jugador = _transfer.transfer_guardado.Guardat[Partida_Selecionada].Velozidad_Jugador_Guardat;
				Defensa_Jugador = _transfer.transfer_guardado.Guardat[Partida_Selecionada].Defensa_Jugador_Guardat;
				Dano_Jugador = _transfer.transfer_guardado.Guardat[Partida_Selecionada].Dano_Jugador_Guardat;
				Cansancio_Jugador = _transfer.transfer_guardado.Guardat[Partida_Selecionada].Cansancio_Jugador_Guardat;

				Velozidad_Estadistica_Jugador_string = Velozidad_Jugador + "J";
	            Dano_Estadistica_Jugador_string = Dano_Jugador + "J";
	            Defensa_Estadistica_Jugador_string = Defensa_Jugador + "J";
	            Cansancio_Estadistica_Jugador_string = Cansancio_Jugador + "J";

				Cansancio_Estadistica_Jugador_TxT.text = Cansancio_Estadistica_Jugador_string;
				Velozidad_Estadistica_Jugador_TxT.text = Velozidad_Estadistica_Jugador_string;
				Defensa_Estadistica_Jugador_TxT.text = Defensa_Estadistica_Jugador_string;
				Dano_Estadistica_Jugador_TxT.text = Dano_Estadistica_Jugador_string;

				Enemigo_Calcular_Vida();
				Jugador_Calcular_Vida();
				//Debug.Log("1");
				Estadisticas_Bool = true;	
			}
			if (Jugador_1r)
			{
				Vida_Final_Enemigo = Vida_Final_Enemigo - Dano_Final_Jugador;

				Debug.Log("Vida Enemigo: " + Vida_Final_Enemigo);
;
				//Restar_Vida_Jugador();
				Restar_Vida_Enemigo();

				if (Vida_Final_Jugador <= 0)
				{
					Vida_Final_Jugador = 0;
					Debug.Log("Gano el Enemigo");
					Debug.Log("Vida Jugador: " + Vida_Final_Jugador);
					Debug.Log("Vida Enemigo: " + Vida_Final_Enemigo);
				}
				if (Vida_Final_Enemigo <= 0)
				{
					Vida_Final_Enemigo = 0;
					Debug.Log("Gano el jugador");
					Debug.Log("Vida Jugador: " + Vida_Final_Jugador);
					Debug.Log("Vida Enemigo: " + Vida_Final_Enemigo);
				}

				Enemigo_2r = true;
				Jugador_1r = false;
			}
			if (Enemigo_1r)
			{
				Enemigo_Ataque();
				Vida_Final_Jugador = Vida_Final_Jugador - Dano_Final_Enemigo;

				Debug.Log("Vida Jugador: " + Vida_Final_Jugador);

				Restar_Vida_Jugador();
				//Restar_Vida_Enemigo();

				if (Vida_Final_Jugador <= 0)
				{
					Vida_Final_Jugador = 0;
					Debug.Log("Gano el Enemigo");
					Debug.Log("Vida Jugador: " + Vida_Final_Jugador);
					Debug.Log("Vida Enemigo: " + Vida_Final_Enemigo);

				}
				if (Vida_Final_Enemigo <= 0)
				{
					Vida_Final_Enemigo = 0;
					Debug.Log("Gano el jugador");
					Debug.Log("Vida Jugador: " + Vida_Final_Jugador);
					Debug.Log("Vida Enemigo: " + Vida_Final_Enemigo);
				}

				Jugador_2r = true;
				Enemigo_1r = false;
			}
			if (Jugador_2r)
			{
				Enemigo_Calcular_Vida();
				Vida_Final_Enemigo = Vida_Final_Enemigo - Dano_Final_Jugador;


				Dano_Final_Jugador = 0;
				Dano_Final_Enemigo = 0;

				Debug.Log("Vida Enemigo: " + Vida_Final_Enemigo);

				Restar_Vida_Enemigo();
				
				Jugador_2r = false;
			}
			if (Enemigo_2r)
			{
				Enemigo_Ataque();
				Jugador_Calcular_Vida();
				Vida_Final_Jugador = Vida_Final_Jugador - Dano_Final_Enemigo;

				Dano_Final_Jugador = 0;
				Dano_Final_Enemigo = 0;

				Debug.Log("Vida Jugador: " + Vida_Final_Jugador);

				Restar_Vida_Jugador();

				Enemigo_2r = false;
			}
		}
	}

	public void Ataque1 ()
	{
		if (Vida_Final_Jugador >= 1 && Vida_Final_Enemigo >=1)
		{
			if (Velozidad_Jugador > Velozidad_Enemigo)
			{
				//Debug.Log("Jugador mas rapido: " + Velozidad_Jugador + " Enemigo: " + Velozidad_Enemigo);
				if (Estamina1_Movimiento >= 1)
				{
					if (Dano_Final_Jugador == 0)
					{
						Estamina1_Movimiento = Estamina1_Movimiento - 1;
						Atake_Primero_Estamina_string = Estamina1_Movimiento + "/" + Max1_Movimiento;
						Atake_Primero_Estamina_TxT.text = Atake_Primero_Estamina_string;

						Calculo1_Jugador = Atake_Primero_Dano_int * Dano_Jugador;
						Calculo2_Jugador = Nivel_Jugador % 100;
						Dano_Final_Jugador = Calculo1_Jugador * Calculo2_Jugador;

						Jugador_1r = true;

						//Debug.Log("Dano_Final: " + Dano_Final_Jugador);
						//Debug.Log("Calculo1: " + Calculo1_Jugador + " Calculo2: " + Calculo2_Jugador);
					}
					else
					{
						Calculo1_Jugador = 0;
						Calculo2_Jugador = 0;
						//Debug.Log("Calculo1: " + Calculo1_Jugador + " Calculo2: " + Calculo2_Jugador);
					}
				}
			}
			else if (Velozidad_Enemigo > Velozidad_Jugador)
			{
				//Debug.Log("Enemigo mas rapido: " + Velozidad_Enemigo + " Jugador: " + Velozidad_Jugador);
				Enemigo_1r = true;
			}
		}
	}
	public void Ataque2 ()
	{
		if (Vida_Final_Jugador >= 1 && Vida_Final_Enemigo >= 1)
		{
			if (Velozidad_Jugador > Velozidad_Enemigo)
			{
				if (Estamina2_Movimiento >= 1)
				{
					if (Dano_Final_Jugador == 0)
					{
						Estamina2_Movimiento = Estamina2_Movimiento - 1;
						Atake_Segundo_Estamina_string = Estamina2_Movimiento + "/" + Max2_Movimiento;
						Atake_Segundo_Estamina_TxT.text = Atake_Segundo_Estamina_string;

						Calculo1_Jugador = Atake_Segundo_Dano_int * Dano_Jugador;
						Calculo2_Jugador = Nivel_Jugador % 100;
						Dano_Final_Jugador = Calculo1_Jugador * Calculo2_Jugador;

						Jugador_1r = true;

						//Debug.Log("Dano_Final: " + Dano_Final_Jugador);
						//Debug.Log("Calculo1: " + Calculo1_Jugador + " Calculo2: " + Calculo2_Jugador);
					}
					else
					{
						Calculo1_Jugador = 0;
						Calculo2_Jugador = 0;
						//Debug.Log("Calculo1: " + Calculo1_Jugador + " Calculo2: " + Calculo2_Jugador);
					}
				}
			}
			else if (Velozidad_Enemigo > Velozidad_Jugador)
			{
				//Debug.Log("Enemigo mas rapido: " + Velozidad_Enemigo + " Jugador: " + Velozidad_Jugador);
				Enemigo_1r = true;
			}
		}
	}
	public void Ataque3 ()
	{

		if (Vida_Final_Jugador >= 1 && Vida_Final_Enemigo >= 1)
		{
			if (Velozidad_Jugador > Velozidad_Enemigo)
			{
				if (Estamina3_Movimiento >= 1)
				{
					if (Dano_Final_Jugador == 0)
					{

						Estamina3_Movimiento = Estamina3_Movimiento - 1;
						Atake_Tercero_Estamina_string = Estamina3_Movimiento + "/" + Max3_Movimiento;
						Atake_Tercero_Estamina_TxT.text = Atake_Tercero_Estamina_string;

						Calculo1_Jugador = Atake_Tercero_Dano_int * Dano_Jugador;
						Calculo2_Jugador = Nivel_Jugador % 100;
						Dano_Final_Jugador = Calculo1_Jugador * Calculo2_Jugador;

						Jugador_1r = true;

						//Debug.Log("Dano_Final: " + Dano_Final_Jugador);
						//Debug.Log("Calculo1: " + Calculo1_Jugador + " Calculo2: " + Calculo2_Jugador);
					}
					else
					{
						Calculo1_Jugador = 0;
						Calculo2_Jugador = 0;
						//Debug.Log("Calculo1: " + Calculo1_Jugador + " Calculo2: " + Calculo2_Jugador);
					}
				}
			}
			else if (Velozidad_Enemigo > Velozidad_Jugador)
			{
				//Debug.Log("Enemigo mas rapido: " + Velozidad_Enemigo + " Jugador: " + Velozidad_Jugador);
				Enemigo_1r = true;
			}
		}
	}
	public void Enemigo_Ataque()
	{
		Random_Ataque_Enemigo = Random.Range(0, 4);
		switch (Random_Ataque_Enemigo)
		{
			case 0:
				if (Random_Ataque_Enemigo == 0)
				{
					Calculo1_Enemigo = Movimiento_1_Enemigo_int * Dano_Enemigo;
					Calculo2_Enemigo = Nivel_Enemigo % 100;
					Dano_Final_Enemigo = Calculo1_Enemigo * Calculo2_Enemigo;
				}
			break;

			case 1:
				if (Random_Ataque_Enemigo == 1)
				{
					Calculo1_Enemigo = Movimiento_2_Enemigo_int * Dano_Enemigo;
					Calculo2_Enemigo = Nivel_Enemigo % 100;
					Dano_Final_Enemigo = Calculo1_Enemigo * Calculo2_Enemigo;
				}
				break;
			case 2:

				if (Random_Ataque_Enemigo == 2)
				{
					Calculo1_Enemigo = Movimiento_3_Enemigo_int * Dano_Enemigo;
					Calculo2_Enemigo = Nivel_Enemigo % 100;
					Dano_Final_Enemigo = Calculo1_Enemigo * Calculo2_Enemigo;
				}
				break;
		}
		/*if (Calculo1 == 0 && Calculo2 == 0)
		{
		//	Calculo1 = Atake_Tercero_Dano_int * Dano_Jugador;
		//	Calculo2 = Nivel_Jugador % 100;
		//	Dano_Final = Calculo1 * Calculo2;
		//	Debug.Log("Dano_Final: " + Dano_Final);
		//	Debug.Log("Calculo1: " + Calculo1 + " Calculo2: " + Calculo2);
		}
		else
		{
			Calculo1 = 0;
			Calculo2 = 0;
			Debug.Log("Calculo1: " + Calculo1 + " Calculo2: " + Calculo2);
		}*/
	}
	public void Enemigo_Calcular_Vida()
	{
		if (!Enemigo_Calcular_Vida_bool)
		{
			Calculo3_Enemigo = Vida_Enemigo * Defensa_Enemigo;
			Calculo4_Enemigo = Nivel_Enemigo % 100;

			Vida_maxima_Enemigo_Calculo = Calculo3_Enemigo * Calculo4_Enemigo;
			Vida_Final_Enemigo = Calculo3_Enemigo * Calculo4_Enemigo;
			//Debug.Log("Vida Enemigo: " + Vida_Final_Enemigo);
			Enemigo_Calcular_Vida_bool = true;
		}
	}
	public void Jugador_Calcular_Vida()
	{
		if (!Jugador_Calcular_Vida_bool)
		{
			Calculo3_Jugador = Vida_Jugador * Defensa_Jugador;
			Calculo4_Jugador = Nivel_Jugador % 100;

			Vida_maxima_Jugador_Calculo = Calculo3_Jugador * Calculo4_Jugador;
			Vida_Final_Jugador = Calculo3_Jugador * Calculo4_Jugador;
			//Debug.Log("Vida Jugador: " + Vida_Final_Jugador);
			Jugador_Calcular_Vida_bool = true;
		}
	}
	public void Restar_Vida_Jugador()
	{
		//Barra_De_Vida_Jugador = GetComponent<Image>();
		Barra_De_Vida_Jugador.fillAmount = Vida_Final_Jugador / Vida_maxima_Jugador_Calculo;
		Debug.Log("Vida_Actual_J: " + Vida_Final_Jugador + " Vida_Maxima_J: " + Vida_maxima_Jugador_Calculo);
	}
	public void Restar_Vida_Enemigo()
	{
		//Barra_De_Vida_Enemigo = GetComponent<Image>();
		Barra_De_Vida_Enemigo.fillAmount = Vida_Final_Enemigo / Vida_maxima_Enemigo_Calculo;
		Debug.Log("Vida_Actual_E: " + Vida_Final_Enemigo + " Vida_Maxima_E: " + Vida_maxima_Enemigo_Calculo);
	}
}
