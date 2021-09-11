using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameObject panelGameOver, panelTapToStart;
    public GameObject machineVOB;
    public bool isGameOver;
    private int timeScore;
    public Text txtScore, txtBestScore, txtCurrentScore;
    private void Start(){
        isGameOver = false;
        if (instance == null) instance = this;
        StartCoroutine(TimeCount());
        Time.timeScale = 0;
    }
    IEnumerator TimeCount(){
        timeScore++;
        txtCurrentScore.text = timeScore.ToString() + "seconds";
        yield return new WaitForSeconds(1f);
        if (!isGameOver) StartCoroutine(TimeCount());
    }
    public void TapToStart(){
        panelTapToStart.SetActive(false);
        Time.timeScale = 1;
    }
    public void OnGameOver(){
        StartCoroutine(ShowPanelGameOver(1f));
        isGameOver = true;
    }
    IEnumerator ShowPanelGameOver(float time){
        yield return new WaitForSeconds(time);
        panelGameOver.SetActive(true);
        panelGameOver.GetComponent<Image>().DOFade(0.8f,2f);
        machineVOB.SetActive(false);
        txtScore.text = "Score: <color=#4287f5>" + timeScore + "</color>";
        txtBestScore.text = "Best Scores: <color=#f54842>" + GameManagement.instance.GetBestScore(timeScore) + "</color>";
    }
    public void OnMainMenu(){
        SceneManager.LoadSceneAsync("Menu");
    }
    public void OnRePlay(){
        SceneManager.LoadSceneAsync("GamePlay");
    }

}
