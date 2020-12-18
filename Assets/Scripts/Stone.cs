using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Stone : MonoBehaviour
{
	public Image stone;

	// Start is called before the first frame update 
	void Start()
	{
		stone.color = new Vector4(0, 0, 0, 0);
	}

	void OnTriggerEnter2D(Collider2D other)
	{		
		if(other.gameObject.CompareTag ("Player"))
		{
			stone.color = new Vector4(1, 1, 1, 1);
			Destroy(gameObject);
		}
	}
}
