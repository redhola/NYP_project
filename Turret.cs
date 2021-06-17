using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("Turret")]
    public Transform target;
    private Enemy TargetEnemy;
    public float range = 7;
    public GameObject firepoint;
    public float damageAmount = 50;
    public float laserDamage = 30;
    
    [Header("Bullet")]
    public GameObject bulletPrefab;
    private float fireCountdown; 
    public float fireRate = 2;
    [Header("Laser")]
    public bool useLaser = false;
    public LineRenderer lineRenderer;
    public float slowAmount = 0.5f;

    void Start(){
        InvokeRepeating("UpdateTarget",0f,0.5f);
    }
    void UpdateTarget(){
            GameObject[] Enemies = GameObject.FindGameObjectsWithTag("enemy");
            GameObject currentEnemy = null;
            foreach(GameObject enemy in Enemies){
                float enemyDistance = Vector3.Distance(transform.position, enemy.transform.position);
                if( enemyDistance <= range)
                {
                    currentEnemy = enemy;
                }
            }
            if( currentEnemy != null)
            {
                target = currentEnemy.transform;
                TargetEnemy = currentEnemy.GetComponent<Enemy>();
            }else{
                target = null;
            }
    }

    void Update(){
        if(target == null)
        {
            if (useLaser)
			{
				if (lineRenderer.enabled)
				{
					lineRenderer.enabled = false;
				}
			}

			return;
        }
            

        if(useLaser)
        {
            Laser();
        }else{
            if(fireCountdown <= 0)
            {
                shoot();
                fireCountdown = 1 / fireRate;
            }
            fireCountdown -= Time.deltaTime;
        }

        
    }

    void Laser(){

        TargetEnemy.TakeDamage(laserDamage * Time.deltaTime);
        TargetEnemy.Slow(slowAmount);

        if(!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
        }

        lineRenderer.SetPosition(0,firepoint.transform.position);
        lineRenderer.SetPosition(1,target.position);
    }

    void shoot(){
        GameObject bullet = (GameObject) Instantiate(bulletPrefab,firepoint.transform.position,transform.rotation);
        Bullet instance = bullet.GetComponent<Bullet>();

        if( instance != null){
            instance.seek(target, damageAmount);
        }
    }
    void OnDrawGizmos(){

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
