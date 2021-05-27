using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace gameLogic
{
  public class StartGame : MonoBehaviour
  {
    public static int gamesPlayed;
    public static int gameSpeed; //1 for easy 2 for hard
    public static int[] gameStates = new int[10]; //if gameStates[Scene index] = 0 game not played if 1 game has been played
    public static int lives;
    public static int lifeFlag;
    public static int score;
    public static int highScore;
    private string highscoreStr;
    public TextMeshProUGUI highscoreText;
    private int countGames;

    void Awake()
    {
      //set all starting var values
      score = 0;
      gameSpeed = 1; //default easy
      lifeFlag = 0; //if 0 dont lose a life when LoadRandomScene() is called if 1 lose a life
      lives = 3; //lives
      gamesPlayed = 1; //gamesPlayed handled by LoadRandomScene()
      countGames = SceneManager.sceneCountInBuildSettings -1;
      highscoreText.text =  "Highscore \n \n" + (StartGame.highScore.ToString().PadLeft(6, '0'));

      //loop through and set all games to unplayed
      for(int i = 0; i < countGames; i++){
        gameStates[i] = 0; //0 is unplayed
      }

    }

    //load scene called with start button
    public void LoadScene()
    {
      int scene = Random.Range(1, countGames); //random game index
      StartGame.gameStates[scene] = 1; //set game to played in gameStates
      SceneManager.LoadScene(scene); //load random game
    }

    public void HardMode()
    {
      gameSpeed = 2; //set speed to 2 for hardmode
      LoadScene();
    }
  }


}
