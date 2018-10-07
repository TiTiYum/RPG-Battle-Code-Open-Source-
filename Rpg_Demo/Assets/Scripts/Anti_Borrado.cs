using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anti_Borrado : MonoBehaviour
{
	private bool Anti_Destrcutor_bool = false;

	void Awake()
	{
		if (!Anti_Destrcutor_bool)
		{
			DontDestroyOnLoad(this.gameObject);
			Anti_Destrcutor_bool = true;
		}
	}
}
