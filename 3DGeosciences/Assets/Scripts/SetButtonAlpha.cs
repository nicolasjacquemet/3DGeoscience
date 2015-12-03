using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetButtonAlpha : MonoBehaviour {

	public void SetAlpha(float alpha){
		Image image = GetComponent<Image>();
		Color newColor = image.color;
		newColor.a = alpha;
		image.color = newColor;
	}

}
