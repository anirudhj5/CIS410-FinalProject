using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace gameLogic
{
  public class randomSceneLoader : MonoBehaviour
  {
    private float timer;
    public int countGames;
    bool flag;
    public bool win = true;
    public Animator transition_win;
    public Animator transition_lose;
    public float transTime = 1.0f;

    void Start()
    {
      countGames = SceneManager.sceneCountInBuildSettings -1; //get number of scenes minus 1 for 0 index
    }

    //will load a random unplayed scene
    public void LoadRandomScene()
    {
      Debug.Log(startGame.gamesPlayed);
      if(startGame.lives < -1) //if out of lives load end screne
      {
        SceneManager.LoadScene(countGames);//load end scene
        return;
      }

      if(startGame.gamesPlayed >= countGames-1) //if all games are played
      {
        SceneManager.LoadScene(countGames); //load end scene
        Debug.Log("game");
        return;
      }
      flag = true;
      int scene = scene = Random.Range(1, countGames);;
      while(flag){
        scene = Random.Range(1, countGames);
        while(startGame.gameStates[scene] == 0){
          if(startGame.lifeFlag == 1){
            --startGame.lives;
            win = false;
            startGame.lifeFlag = 0;
          }else{
            win = true;
          }
          startGame.gamesPlayed++; //increment number of games played
          startGame.gameStates[scene] = 1;
          flag = false;
          break;
        }
     
      }
      //transition_win.SetTrigger("gameWon");
      //StartCoroutine(LoadLevel());
      SceneManager.LoadScene(scene);
    }


    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(transTime);
        //SceneManager.LoadScene(index);
    }

    private void EndGame()
    {
      SceneManager.LoadScene(countGames); //load end screen
    }

  }
}
