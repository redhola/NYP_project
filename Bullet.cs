using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform Target;
    public float speed = 10;
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
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget(){
        Debug.Log("hit");
        Destroy(Target.gameObject);
        Destroy(gameObject);
    }
}
