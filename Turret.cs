using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform target;
    public GameObject bulletPrefab;
    private float fireCountdown;
    public float fireRate = 2;
    public float range = 7;
     static public float damageAmount = 50;
    void Start(){
        InvokeRepeating("UpdateTarget",0f,0.5f);
    }
    void UpdateTarget(){
            GameObject[] Enemies = GameObject.FindGameObjectsWithTag("enemy");
            GameObject currentEnemy = null;
            foreach(GameObject enemy in Enemies){
                float enemyDistance = Vector3.Distance(transform.position, enemy.transform.position);
                //Debug.Log(enemyDistance);
                if( enemyDistance <= range)
                {
                    currentEnemy = enemy;
                    //Debug.Log(currentEnemy);
                }
            }

            if( currentEnemy != null)
            {
                target = currentEnemy.transform;
                //Debug.Log(target.transform);
            }
    }

    void Update(){
        if(target == null)
            return;

        if(fireCountdown <= 0)
        {
            shoot();
            fireCountdown = 1 / fireRate;
            Debug.Log("shot");
        }
        fireCountdown -= Time.deltaTime;
    }

    void shoot(){
        GameObject bullet = (GameObject) Instantiate(bulletPrefab,transform.position,transform.rotation);
        Bullet instance = bullet.GetComponent<Bullet>();

        if( instance != null){
            instance.seek(target);
        }
    }
    void OnDrawGizmos(){

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range );
    }
}
