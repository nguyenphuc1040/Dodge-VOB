using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData){
        switch (gameObject.name)
        {
            case "MoveLeft": 
                PlayerController.instance.PushMove('L');
                break;
            case "MoveRight": 
                PlayerController.instance.PushMove('R');
                break;
            case "Jump":
                PlayerController.instance.Jump();
                break;
            case "Dodge":
                PlayerController.instance.Dodge();
                break;
        }
    }

    public void OnPointerUp(PointerEventData eventData){
        if (gameObject.name == "MoveLeft"){
            if (PlayerController.instance != null) PlayerController.instance.PopMove('L');
        } else 
            if (gameObject.name == "MoveRight"){
                if (PlayerController.instance != null) PlayerController.instance.PopMove('R');
            }
    }
}
