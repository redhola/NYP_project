using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
    public static int Money;
    public int startMoney = 1000;

    private void Start() // Eðer gameMasterdan fiyat deðiþtirmek istersen startý update ile deðiþtir.
    {
        Money = startMoney;
    }



}
