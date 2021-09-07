using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayerIF;
using System;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    public Transform contentItem;
    public Button btnPlayerItem;
   // private PlayerItem[] arrItem;
    private List<PlayerItem> arrPlayerItem;
    void Start()
    {
        RenderItemPlayer();
    }

    void RenderItemPlayer(){
        // Get Json Infomation
        var asset = Resources.Load<TextAsset>("Jsons/ItemPlayer/ItemPlayer");
        ArrayItem playerItem = JsonUtility.FromJson<ArrayItem>(asset.text);
        arrPlayerItem = playerItem.playerItem;
        // Create Button Items
        foreach (PlayerItem item in arrPlayerItem){
            var btn = (Button) Instantiate(btnPlayerItem, contentItem);
            btn.GetComponent<ItemButton>().SetInitData(item);
        }
       
    }

    public void OnPlayGame(){
        SceneManager.LoadSceneAsync("GamePlay");
    }
}
