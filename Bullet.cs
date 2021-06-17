using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform Target;
    public float speed = 10;
    private float damage;
    public void seek(Transform target, float damageAmount){
        Target = target;
        damage = damageAmount;
    }

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
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget(){

        Damage(Target);

        Destroy(gameObject);
        
    }

    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

		if (e != null)
		{
			e.TakeDamage(damage);
		}
    }
}
