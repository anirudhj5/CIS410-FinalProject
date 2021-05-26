using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace gameLogic
{
  public class startGame : MonoBehaviour
  {
    public static int gamesPlayed;
    public static int[] gameStates = new int[10]; //if gameStates[Scene index] = 0 game not played if 1 game has been played
    public static int lives;
    public static int lifeFlag;
    private int countGames;

    void Awake()
    {
      //set all starting var values
      lifeFlag = 0; //if 0 dont lose a life when LoadRandomScene() is called if 1 lose a life
      lives = 3; //lives
      gamesPlayed = 1; //gamesPlayed handled by LoadRandomScene()
      countGames = SceneManager.sceneCountInBuildSettings -1;

      //loop through and set all games to unplayed
      for(int i = 0; i < countGames; i++){
        gameStates[i] = 0; //0 is unplayed
      }

    }

    //load scene called with start button
    public void LoadScene()
    {
      int scene = Random.Range(1, countGames); //random game index
      startGame.gameStates[scene] = 1; //set game to played in gameStates
      SceneManager.LoadScene(scene); //load random game
    }
  }
}
