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
	public Datos_Mapa _datos_mapa;

	public Text Nombre_Jugador_TxT,
		Nombre_Enemigo_TxT,
		Atake_Primero_TxT,
		Atake_Segundo_TxT,
		Atake_Tercero_TxT,
		Atake_Primero_Estamina_TxT,
		Atake_Segundo_Estamina_TxT,
		Atake_Tercero_Estamina_TxT,
		Velozidad_Estadistica_Jugador_TxT,
		Dano_Estadistica_Jugador_TxT,
		Defensa_Estadistica_Jugador_TxT,
		Cansancio_Estadistica_Jugador_TxT,
		Velozidad_Estadistica_Enemigo_TxT,
		Dano_Estadistica_Enemigo_TxT,
		Defensa_Estadistica_Enemigo_TxT,
		Cansancio_Estadistica_Enemigo_TxT,
		Nivel_Enemigo_TxT,
		Nivel_Jugador_TxT;

	private int Atake_Primero_Dano_int,
		Atake_Segundo_Dano_int,
		Atake_Tercero_Dano_int,
		Velozidad_Jugador,
 		Dano_Jugador,
 		Defensa_Jugador,
		Cansancio_Jugador,
		Nivel_Jugador,
		Vida_Jugador,
		Vida_Maxima_Jugador,
		Movimiento_1_int,
		Movimiento_2_int,
		Movimiento_3_int,
		minimo_de_nivel_enemigo,
		maximo_de_nivel_enemigo ,
		Velozidad_Enemigo,
		Dano_Enemigo,
		Defensa_Enemigo,
		Cansancio_Enemigo,
		Vida_Enemigo,
		Nivel_Enemigo,
		Movimiento_1_Enemigo_int,
		Movimiento_2_Enemigo_int,
		Movimiento_3_Enemigo_int,
		Max1_Movimiento,
		Estamina1_Movimiento,
		cansancio1_Movimiento,
		Max2_Movimiento,
		Estamina2_Movimiento,
		cansancio2_Movimiento,
		Max3_Movimiento,
		Estamina3_Movimiento,
		cansancio3_Movimiento,
		Enemigo_Selecion_int = 1,
		Jugador_Selecion_int,
		Partida_Selecionada = 1,
		Daño_Final,
		Random_Ataque_Enemigo,
		Dano_Final_Jugador,
		Vida_Final_Jugador,
		Calculo1_Jugador,
		Calculo2_Jugador,
		Calculo3_Jugador,
		Calculo4_Jugador,
		Dano_Final_Enemigo,
		Vida_Final_Enemigo,
		Calculo1_Enemigo,
		Calculo2_Enemigo,
		Calculo3_Enemigo,
		Calculo4_Enemigo;
	         
	private float Vida_maxima_Jugador_Float,
        Vida_maxima_Enemigo_Float,
		Vida_maxima_Jugador_Calculo,
		Vida_maxima_Enemigo_Calculo,
		Vida_Jugador_Float,
		Vida_Enemigo_Float;

	private bool Estadisticas_Bool,
		Jugador_1r,
		Enemigo_1r,
		Jugador_2r,
		Enemigo_2r,
		La_Partida_ah_empezado,
		Players_Selecionados,
		Estats_Enemigo_Selecionados,
		Estats_Jugador_Selecionados,
		movimientos_Selecionados;
	                   
	public Image Barra_De_Vida_Enemigo,
        Barra_De_Vida_Jugador;

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
	}
	void Update ()
    {
		Calcular_Datos();
		Barra_Vida();
		//Debug.Log("Vida J: " + Vida_Final_Jugador);
		//Debug.Log("Vida E: " + Vida_Final_Enemigo + "Vida inicial: " + Vida_Enemigo);
		//Debug.Log("Calculo1: " + Calculo3_Enemigo);
		//Debug.Log("Calculo2: " + Calculo4_Enemigo);
		//Debug.Log("Nivel: " + Nivel_Enemigo);
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
						Atake_Primero_Estamina_TxT.text = Estamina1_Movimiento + "/" + Max1_Movimiento;

						Calculo1_Jugador = Atake_Primero_Dano_int * Dano_Jugador;
						Calculo2_Jugador = Nivel_Jugador % 100;
						Dano_Final_Jugador = Calculo1_Jugador * Calculo2_Jugador;

						Jugador_1r = true;
						Atacar();
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
				Atacar();
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
						Atake_Segundo_Estamina_TxT.text = Estamina2_Movimiento + "/" + Max2_Movimiento;

						Calculo1_Jugador = Atake_Segundo_Dano_int * Dano_Jugador;
						Calculo2_Jugador = Nivel_Jugador % 100;
						Dano_Final_Jugador = Calculo1_Jugador * Calculo2_Jugador;

						Jugador_1r = true;
						Atacar();
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
				Atacar();
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
						Atake_Tercero_Estamina_TxT.text = Estamina3_Movimiento + "/" + Max3_Movimiento;

						Calculo1_Jugador = Atake_Tercero_Dano_int * Dano_Jugador;
						Calculo2_Jugador = Nivel_Jugador % 100;
						Dano_Final_Jugador = Calculo1_Jugador * Calculo2_Jugador;

						Jugador_1r = true;
						Atacar();
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
				Atacar();
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
	public void Calcular_Vida_final()
	{
			Calculo3_Enemigo = Vida_Enemigo * Defensa_Enemigo;
			Calculo4_Enemigo = Nivel_Enemigo % 100;
			Vida_maxima_Enemigo_Calculo = Calculo3_Enemigo * Calculo4_Enemigo;
			Vida_Final_Enemigo = Calculo3_Enemigo * Calculo4_Enemigo;
			Calculo3_Jugador = Vida_Jugador * Defensa_Jugador;
			Calculo4_Jugador = Nivel_Jugador % 100;
			Vida_maxima_Jugador_Calculo = Calculo3_Jugador * Calculo4_Jugador;
			Vida_Final_Jugador = Calculo3_Jugador * Calculo4_Jugador;
	}
	public void Barra_Vida()
	{
		//Barra_De_Vida_Jugador = GetComponent<Image>();
		Barra_De_Vida_Jugador.fillAmount = Vida_Final_Jugador / Vida_maxima_Jugador_Calculo;
		//Debug.Log("Vida_Actual_J: " + Vida_Final_Jugador + " Vida_Maxima_J: " + Vida_maxima_Jugador_Calculo);
		//Barra_De_Vida_Enemigo = GetComponent<Image>();
		Barra_De_Vida_Enemigo.fillAmount = Vida_Final_Enemigo / Vida_maxima_Enemigo_Calculo;
		//Debug.Log("Vida_Actual_E: " + Vida_Final_Enemigo + " Vida_Maxima_E: " + Vida_maxima_Enemigo_Calculo);
	}
	public void Calcular_Datos()
	{
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
			if (!Estats_Enemigo_Selecionados)
			{
				//Debug.Log("No ahy nada");
				Velozidad_Enemigo = _transfer.transfer_enemigos_final.Enemic[Enemigo_Selecion_int].Velozidad_Enemic;
				Defensa_Enemigo = _transfer.transfer_enemigos_final.Enemic[Enemigo_Selecion_int].Defensa_Enemic;
				Dano_Enemigo = _transfer.transfer_enemigos_final.Enemic[Enemigo_Selecion_int].Ataque_Enemic;
				Vida_Enemigo = _transfer.transfer_enemigos_final.Enemic[Enemigo_Selecion_int].Vida_Enemic;
			
				minimo_de_nivel_enemigo = _datos_mapa.Minimo_Nivel_Enemigos;
				maximo_de_nivel_enemigo = _datos_mapa.Maximo_Nivel_Enemigos;
				maximo_de_nivel_enemigo = maximo_de_nivel_enemigo + 1;
				Nivel_Enemigo = Random.Range(minimo_de_nivel_enemigo, maximo_de_nivel_enemigo);

				Debug.Log("minimo: " + minimo_de_nivel_enemigo);
				Debug.Log("maximo: " + maximo_de_nivel_enemigo);
				Debug.Log("mNivel: " + Nivel_Enemigo);
				Cansancio_Enemigo = 0;

				Velozidad_Estadistica_Enemigo_TxT.text = Velozidad_Enemigo + "E";
				Dano_Estadistica_Enemigo_TxT.text = Dano_Enemigo + "E";
				Defensa_Estadistica_Enemigo_TxT.text = Defensa_Enemigo + "E";
				Cansancio_Estadistica_Enemigo_TxT.text = Cansancio_Enemigo + "E";

				Estats_Enemigo_Selecionados = true;
			}
			if (!Players_Selecionados)
			{
				//Mira si el nombre esta selecionado y lo coloca
				Nombre_Enemigo_TxT.text = _transfer.transfer_enemigos_final.Enemic[Enemigo_Selecion_int].Nombre_Enemic;
				Nombre_Jugador_TxT.text = _transfer.transfer_guardado.Guardat[Jugador_Selecion_int].Nombre_Personje_Guardat;
				Nivel_Enemigo_TxT.text = "" + Nivel_Enemigo;
				Nivel_Jugador_TxT.text = "" + Nivel_Jugador;
				Players_Selecionados = true;
			}
			if (!movimientos_Selecionados)
			{
				Atake_Primero_TxT.text = _transfer.transfer_movimientos_final.Moviment[Movimiento_1_int].Nombre_Moviment;
				Atake_Segundo_TxT.text = _transfer.transfer_movimientos_final.Moviment[Movimiento_2_int].Nombre_Moviment;
				Atake_Tercero_TxT.text = _transfer.transfer_movimientos_final.Moviment[Movimiento_3_int].Nombre_Moviment;

				Max1_Movimiento = _transfer.transfer_movimientos_final.Moviment[Movimiento_1_int].Maximo_Moviment;
				Max2_Movimiento = _transfer.transfer_movimientos_final.Moviment[Movimiento_2_int].Maximo_Moviment;
				Max3_Movimiento = _transfer.transfer_movimientos_final.Moviment[Movimiento_3_int].Maximo_Moviment;

				Atake_Primero_Estamina_TxT.text = Estamina1_Movimiento + "/" + Max1_Movimiento;
				Atake_Segundo_Estamina_TxT.text = Estamina2_Movimiento + "/" + Max2_Movimiento;
				Atake_Tercero_Estamina_TxT.text = Estamina3_Movimiento + "/" + Max3_Movimiento;

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

				Cansancio_Estadistica_Jugador_TxT.text = Cansancio_Jugador + "J";
				Velozidad_Estadistica_Jugador_TxT.text = Velozidad_Jugador + "J";
				Defensa_Estadistica_Jugador_TxT.text = Defensa_Jugador + "J";
				Dano_Estadistica_Jugador_TxT.text = Dano_Jugador + "J";

				
				Calcular_Vida_final();
				//Debug.Log("1");
				Estadisticas_Bool = true;
			}
		}
	}
	public void Atacar()
	{
		if (Jugador_1r)
		{
			Vida_Final_Enemigo = Vida_Final_Enemigo - Dano_Final_Jugador;

			if (Vida_Final_Jugador <= 0)
			{
				Vida_Final_Jugador = 0;
			}
			if (Vida_Final_Enemigo <= 0)
			{
				Vida_Final_Enemigo = 0;
			}
			Enemigo_2r = true;
			Jugador_1r = false;
		}
		if (Enemigo_1r)
		{
			Enemigo_Ataque();
			Vida_Final_Jugador = Vida_Final_Jugador - Dano_Final_Enemigo;

			if (Vida_Final_Jugador <= 0)
			{
				Vida_Final_Jugador = 0;

			}
			if (Vida_Final_Enemigo <= 0)
			{
				Vida_Final_Enemigo = 0;
			}
			Jugador_2r = true;
			Enemigo_1r = false;
		}
		if (Jugador_2r)
		{
			Vida_Final_Enemigo = Vida_Final_Enemigo - Dano_Final_Jugador;

			Dano_Final_Jugador = 0;
			Dano_Final_Enemigo = 0;

			Jugador_2r = false;
		}
		if (Enemigo_2r)
		{
			Enemigo_Ataque();
			Vida_Final_Jugador = Vida_Final_Jugador - Dano_Final_Enemigo;

			Dano_Final_Jugador = 0;
			Dano_Final_Enemigo = 0;

			Enemigo_2r = false;
		}
	}
}
