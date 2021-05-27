using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace gameLogic
{
  public class RestartGame : MonoBehaviour
  {
    public void LoadScene()
    {
       SceneManager.LoadScene(0); //load start scene
    }
  }
}
