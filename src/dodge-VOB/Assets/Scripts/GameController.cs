using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameObject panelGameOver;
    public GameObject machineVOB;
    private void Start(){
        if (instance == null) instance = this;
    }
    
    public void TapToStart(){

    }
    public void OnGameOver(){
        panelGameOver.SetActive(true);
        machineVOB.SetActive(false);
    }
    public void OnMainMenu(){
        SceneManager.LoadSceneAsync("Menu");
    }
    public void OnRePlay(){
        SceneManager.LoadSceneAsync("GamePlay");
    }

}
