using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerIF;
public class GameManagement : MonoBehaviour
{
    public static GameManagement instance;
    public PlayerItem currentItem { get; set;}
    void Awake()
    {
        MakeInstance();    
    }

    void MakeInstance(){
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int GetBestScore(int score){
        if (score > PlayerPrefs.GetInt("BestScore")) PlayerPrefs.SetInt("BestScore", score);
        return PlayerPrefs.GetInt("BestScore");
    }
}
