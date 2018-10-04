using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimientos_Enemigos : MonoBehaviour
{
	private int Enemigo_En_Pantalla;

	public int Enemigo_Ataque1;
	public int Enemigo_Ataque2;
	public int Enemigo_Ataque3;

	public void Enemigo_Ataques()
	{
        switch (Enemigo_En_Pantalla)
		{
			case 0:
				Enemigo_Ataque1 = 0;
				Enemigo_Ataque2 = 0;
				Enemigo_Ataque3 = 0;
				break;

			case 1:
				Enemigo_Ataque1 = 0;
				Enemigo_Ataque2 = 0;
				Enemigo_Ataque3 = 0;
				break;
		}
	}

}
