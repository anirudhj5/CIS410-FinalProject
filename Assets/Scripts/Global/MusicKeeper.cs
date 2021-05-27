using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Singleton pattern source:
https://gamedev.stackexchange.com/a/116010
*/

public class MusicKeeper : MonoBehaviour {
    private static MusicKeeper _instance;

    public static MusicKeeper Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }

        DontDestroyOnLoad(transform.gameObject);//keep music through scenes
    }


}
