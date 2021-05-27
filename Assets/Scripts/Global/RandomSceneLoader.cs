using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace gameLogic
{
  public class RandomSceneLoader : MonoBehaviour
  {
    private float timer;
    public int countGames;
    bool flag;

    void Start()
    {
      countGames = SceneManager.sceneCountInBuildSettings -1; //get number of scenes minus 1 for 0 index
    }

    //will load a random unplayed scene
    public void LoadRandomScene()
    {

      if(StartGame.lifeFlag == 0)
      {
        StartGame.score += 10000 * StartGame.gameSpeed; //10k for level clear
      }

      if(StartGame.lives < -1) //if out of lives load end screne
      {
        EndGame();
        return;
      }

      if(StartGame.gamesPlayed >= countGames-1) //if all games are played
      {
        StartGame.score += 25000 * StartGame.gameSpeed; //25k for win on easy 50k for hard
        StartGame.score += ((10000 * (StartGame.lives*StartGame.lives))* StartGame.gameSpeed); //10k for 1 life 40k for 2 90k for all 3 double on hardmode
        EndGame();
        return;
      }
      flag = true;
      int scene = scene = Random.Range(1, countGames);;
      while(flag){
        scene = Random.Range(1, countGames);
        while(StartGame.gameStates[scene] == 0){ //if game not played
          if(StartGame.lifeFlag == 1){
            --StartGame.lives; //lose a life
            StartGame.lifeFlag = 0; //reset life flag (if survival game set lifeflag to 1 when it starts)
          }
          StartGame.gamesPlayed++; //increment number of games played
          StartGame.gameStates[scene] = 1;
          flag = false; //break out of outer while loop
          break;
        }
      }
      SceneManager.LoadScene(scene); //load random scene
    }

    private void EndGame()
    {
      if(  StartGame.score  >  StartGame.highScore) //if new highscore
      {
        StartGame.highScore = StartGame.score; //update highscore
      }
      SceneManager.LoadScene(countGames); //load end screen
    }

  }
}
