using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameObject panelGameOver;
    private void Start(){
        if (instance == null) instance = this;
    }
    
    public void TapToStart(){

    }
    public void GameOver(){
        panelGameOver.SetActive(true);
    }
    public void OnMainMenu(){
        SceneManager.LoadSceneAsync("Menu");
    }
    public void OnRePlay(){
        SceneManager.LoadSceneAsync("GamePlay");
    }

}
