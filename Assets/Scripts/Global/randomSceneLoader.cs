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
      Debug.Log(StartGame.gamesPlayed);
      if(StartGame.lives < -1) //if out of lives load end screne
      {
        SceneManager.LoadScene(countGames);//load end scene
        return;
      }

      if(StartGame.gamesPlayed >= countGames-1) //if all games are played
      {
        SceneManager.LoadScene(countGames); //load end scene
        Debug.Log("game");
        return;
      }
      flag = true;
      int scene = scene = Random.Range(1, countGames);;
      while(flag){
        scene = Random.Range(1, countGames);
        while(StartGame.gameStates[scene] == 0){
          if(StartGame.lifeFlag == 1){
            --StartGame.lives;
            StartGame.lifeFlag = 0;
          }
          StartGame.gamesPlayed++; //increment number of games played
          StartGame.gameStates[scene] = 1;
          flag = false;
          break;
        }
      }
      SceneManager.LoadScene(scene); //load random scene
    }

    private void EndGame()
    {
      SceneManager.LoadScene(countGames); //load end screen
    }

  }
}
