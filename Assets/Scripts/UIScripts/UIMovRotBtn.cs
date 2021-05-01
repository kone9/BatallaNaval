using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIMovRotBtn : MonoBehaviour
{
    public static UIMovRotBtn instance;

    [SerializeField] private Button btn;
	[SerializeField] private GameObject BotonMover;
	[SerializeField] private GameObject BotonRotar;

	private bool moveMode = true;

	public bool MoveMode { get => moveMode; set => moveMode = value; }

	private void Awake()
	{
		instance = this;
	}

	/// <summary>Cambia el modo de rotación y cambia la letra que se ve en el boton</summary>
	public void ToggleMode()//cambia 
	{
		MoveMode = !MoveMode;
		if (MoveMode)
		{
			BotonMover.SetActive(true);
			BotonRotar.SetActive(false);
		}	
		else
		{
			BotonMover.SetActive(false);
			BotonRotar.SetActive(true);
		}
			
	}

}
