using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    public GameObject lightning;
    public float range = 5;
    public float cooldown = 1;
    public float damage = 50;
    private static bool strikeTrigger = false;
    private static bool lockTrigger = true;
    private Enemy targetEnemy;
    void Start()
    {

    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z) & lockTrigger)
        {
            Debug.Log("x");
            lockTrigger = false;
            strikeTrigger = true;
        }

        if(Input.GetMouseButtonDown(0) & strikeTrigger)
        {
            Debug.Log("b");
            StartCoroutine(Strike());
        }
    }

    public IEnumerator Strike()
    {
        Debug.Log("call");
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 2f;
        Instantiate(lightning, mousePosition, Quaternion.identity);
        strikeTrigger = false;
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("enemy");
        foreach(GameObject enemy in Enemies)
        {
            float distance = Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), enemy.transform.position);
            if(distance <= range)
            {
                targetEnemy = enemy.GetComponent<Enemy>();
                targetEnemy.TakeDamage(damage);
            }
        }
        yield return new WaitForSeconds(1);
        lockTrigger = true;
        Destroy(GameObject.Find("Lightning(Clone)"));

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(Camera.main.ScreenToWorldPoint(Input.mousePosition),range);
    }

    public static bool getLockTrigger()
    {
        return lockTrigger;
    }
    public static void setLockTrigger(bool value)
    {
        lockTrigger = value;
    }
    public static bool getStrikeTrigger()
    {
        return strikeTrigger;
    }
    public static void setStrikeTrigger(bool value)
    {
        strikeTrigger = value;
    }

}
