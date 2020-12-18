using System.Collections;
using UnityEngine;

public class ControlPanel : MonoBehaviour
{
	public GameObject door;
	public GameObject signal;
	public GameObject doorLocked;

	private ColorChange stone1;
	private ColorChange stone2;
	private ColorChange stone3;

	public AudioSource soundEffect;

    // Start is called before the first frame update
    void Start()
	{
		GameObject stoneColorObject = GameObject.FindWithTag("Stone1");
		if (stoneColorObject != null)
		{
			stone1 = stoneColorObject.GetComponent<ColorChange>();
		}

		stoneColorObject = GameObject.FindWithTag("Stone2");
		if (stoneColorObject != null)
		{
			stone2 = stoneColorObject.GetComponent<ColorChange>();
		}

		stoneColorObject = GameObject.FindWithTag("Stone3");
		if (stoneColorObject != null)
		{
			stone3 = stoneColorObject.GetComponent<ColorChange>();
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (stone1.colorNumber == 0 && stone2.colorNumber == 1 && stone3.colorNumber == 2)
		{
			Vector3 spawnPos = new Vector3(7.32f, -3.41f, -0.5f);
			Quaternion spawnRot = Quaternion.identity;
			Instantiate(door, spawnPos, spawnRot);
				
			spawnPos = new Vector3(6f, -4f, -0.5f);
			spawnRot = Quaternion.identity;
			Instantiate(signal, spawnPos, spawnRot);

			if (doorLocked != null)
			{
				doorLocked.SetActive(false);
			}
		}		
	}
    void Update()
    {		
		if(stone1.colorNumber == 0 && stone2.colorNumber == 1 && stone3.colorNumber == 2)
        {
			soundEffect.Play();
		}
	}
}