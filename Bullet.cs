using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform Target;
    public float speed = 10;
    public static int hitCounter = 0;
    public void seek(Transform target){
        Target = target;
    }

    // Update is called once per frame
    void Update()
    {
        if(Target == null){
            Destroy(gameObject);
            return;
        }

        Vector3 direction = Target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(direction.magnitude <= distanceThisFrame)
        {
            hitCounter += 1;
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget(){
        Debug.Log("hit");

        Damage(Target);
        
    }

    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

		if (e != null)
		{
			e.TakeDamage(Turret.damageAmount);
		}
    }
}
