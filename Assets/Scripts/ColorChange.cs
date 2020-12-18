using System.Collections;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
	SpriteRenderer spriteColor;
	private Color[] cores = new Color[] { Color.red, Color.green, Color.blue };
	[HideInInspector] public int colorNumber = 0;

	// Start is called before the first frame update 
	void Start()
	{
		spriteColor = GetComponent<SpriteRenderer>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(colorNumber == 2)
		{
			colorNumber = 0;
		}
		else
		{
			colorNumber++;
		}

		if(other.gameObject.CompareTag ("Player"))
		{
			spriteColor.color = cores[colorNumber];
		}
	}
}
