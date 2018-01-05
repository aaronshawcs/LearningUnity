using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
	[SerializeField]
	BallScript gameBall;
	[SerializeField]
	Text scoreText;

	int playerScore;
	
	void Start ()
	{
		playerScore = 0;
	}

	public void Crash()
	{
		playerScore++;
		UpdateScoreText();
		// now check if the player has collided 7 times
		if (playerScore == 7)
			GameOver();
	}

	void GameOver()
	{
		UpdateScoreText();
		playerScore = 0;
		gameBall.Reset();
	}

	void UpdateScoreText()
	{
		scoreText.text = playerScore.ToString();
	}
}
