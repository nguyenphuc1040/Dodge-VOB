using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayerIF;
public class ItemButton: MonoBehaviour{
    private PlayerItem info;
    public GameObject btn;
    public void SetInitData(PlayerItem info){
        this.info = info;
        LoadingSource();
    }
    public void LoadingSource(){
        btn.GetComponent<Image>().sprite = Resources.Load<Sprite>("Imgs/BtnPlayer/"+info.imageUrl);
    }
    public void OnPress(){
        if (MenuController.instance != null) MenuController.instance.OnChoiceItem(btn.transform);   
        if (GameManagement.instance != null) GameManagement.instance.currentItem = info;
    }
}