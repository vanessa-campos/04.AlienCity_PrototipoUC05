using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ControlMessage : MonoBehaviour
{	
	public Text gameOverText;	
	public Text restartText;	
	public Text winText;

	public bool gameOver;
	public bool restart;
	public bool win;
	
	void Start()
	{
		gameOver = false;
		restart = false;
		win = false;
		gameOverText.text = "";
		restartText.text = "";
		winText.text = "";
	}

	[System.Obsolete]
	void Update()
	{
		if (gameOver)
		{
			restartText.text = "Pressione 'R' para Restart";
			restart = true;
		}
		if (restart)
		{
			if (Input.GetKeyDown(KeyCode.R))
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
		
	public void GameOver()
	{
		gameOverText.text = "GAME OVER";
		gameOver = true;
	}

	public void Win()
	{
		winText.text = "PARABÉNS VOCÊ VENCEU!!!";
		restartText.text = "Pressione 'R' para Restart";
		restart = true;
	}
}
