using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCamera : MonoBehaviour
{
	[SerializeField] private Camera cam;

	private Vector2 originalRectPos = new Vector2(0.29f, 0.58f);
	private Vector2 originalRectSize = new Vector2(0.69f, 0.37f);

	private float originalRatio = 0.5625f;
	private float originalW = 0.29f;

	private Rect originalRect;
	private float currentRatio;

	private void Awake()
	{
		originalRect = new Rect(originalRectPos, originalRectSize);
	}

	private void Update()
	{
		currentRatio = (float)Screen.width / Screen.height;
		if (currentRatio != originalRatio)
			AdjustScreen(currentRatio);
		else
			cam.rect = originalRect;
	}

	private void AdjustScreen(float currenRatio)
	{
		Debug.Log(currenRatio);
		if (currentRatio > originalRatio)
		{
			if(currentRatio == 1.0f)
				cam.rect = new Rect(new Vector2(0.23f, 0.58f), new Vector2(0.69f, 0.37f));
			else
				cam.rect = new Rect(new Vector2(0.2f, 0.58f), new Vector2(0.69f, 0.37f));
		}
		
	}
}
