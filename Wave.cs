using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave 
{    
    public List<EnemyBluePrint> Enemies = new List<EnemyBluePrint>();


    public IEnumerator GetEnumerator()
    {
        return Enemies.GetEnumerator();
    }
    

}
