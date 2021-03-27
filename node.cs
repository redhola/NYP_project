using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class node : MonoBehaviour
{
    private GameObject turret;
    public Sprite TurretSprite;
    
    void OnMouseDown(){
        if(turret != null){
            Debug.Log("already a turret build");
            return;
        }
        GetComponent<SpriteRenderer>().sprite = TurretSprite;

    }
    void OnMouseEnter(){
        GetComponent<SpriteRenderer>().material.color = Color.blue;
        Debug.Log("mouse over");
    }
    void OnMouseExit(){
        GetComponent<SpriteRenderer>().material.color = Color.white;
        Debug.Log("mouse exit");
    }
}