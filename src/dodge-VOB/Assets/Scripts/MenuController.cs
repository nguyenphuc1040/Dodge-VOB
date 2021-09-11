using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayerIF;
using System;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    public static MenuController instance;
    public Transform contentItem;
    public Button btnPlayerItem;
    public Transform choiceFrame;
   // private PlayerItem[] arrItem;
    private List<PlayerItem> arrPlayerItem;
    void Awake(){
        if (instance == null) instance = this;
    }
    void Start(){
        RenderItemPlayer();
    }
    public void OnChoiceItem(Transform item){
        choiceFrame.position = item.position;
    }
    void RenderItemPlayer(){
        // Get Json Infomation
        var asset = Resources.Load<TextAsset>("Jsons/ItemPlayer/ItemPlayer");
        ArrayItem playerItem = JsonUtility.FromJson<ArrayItem>(asset.text);
        arrPlayerItem = playerItem.playerItem;
        // Create Button Items
        int i = 0;
        foreach (PlayerItem item in arrPlayerItem){
            if (i==0) GameManagement.instance.currentItem = item;
            var btn = (Button) Instantiate(btnPlayerItem, contentItem);
            btn.GetComponent<ItemButton>().SetInitData(item);
        }
        GameManagement.instance.currentItem = arrPlayerItem[0];
    }

    public void OnPlayGame(){
        SceneManager.LoadSceneAsync("GamePlay");
    }
}