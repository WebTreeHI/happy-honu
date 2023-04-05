using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //to refer to score Text variable
using UnityEngine.SceneManagement; //to refer to the restart button

public class GameLogicScript : MonoBehaviour
{
  public int playerScore;
  public GameObject ScoreText;
  public GameObject GameOverState;
  public AudioSource happyBellSFX;

  [ContextMenu("Increase Score")]
  public void addScore(int scoreToAdd)
  {
    playerScore = playerScore + scoreToAdd;
    ScoreText.GetComponent<TMPro.TextMeshProUGUI>().text = playerScore.ToString();
    happyBellSFX.Play();
  }

  public void restartGame()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }

  public void gameOver()
  {
    GameOverState.SetActive(true);
  }

}
