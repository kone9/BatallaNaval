using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResoAdjuster : MonoBehaviour
{
	[SerializeField] private RectTransform uiPanel;
	[SerializeField] private Transform cam;

	private float originalRatio = 0.5625f;
	private float currentRatio;

	private Vector3 originalCamPos = new Vector3(39.0f, 75.0f, 55.9f);
	private Vector2 originalUiPos = new Vector2(1.5f, 5.0f);

	private void Update()
	{
		currentRatio = (float)Screen.width / Screen.height;
		if (currentRatio == originalRatio)
		{
			uiPanel.anchoredPosition = originalUiPos;
			cam.localPosition = originalCamPos;
		}
		else
			AdjustScreen(currentRatio);
	}

	private void AdjustScreen(float currenRatio)
	{
		if (currentRatio == 1.0f) return;

		if (currentRatio < originalRatio)
		{
			uiPanel.anchoredPosition = new Vector2(1.5f, 117.0f);
			cam.localPosition = new Vector3(cam.localPosition.x, 90.0f, 55.9f);
		}
	}
}
