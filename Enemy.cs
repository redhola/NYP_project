using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public enum State
    {
        onPath,
        onAttack
    }
    public static State state;
    public float startSpeed = 5;
    public float speed;
    public float startHealth = 100;
    private float health;
    public int worth = 50;
    public float attackRange = 1f;
    public float chaseRange = 4f;
    private float attackTimer = 2f;
    public Transform attackPoint;
    public Transform chasePoint;
    private Transform target;
    private int wavepointIndex = 0;
    public Image healthbar;
    public Player player;
    public Animator animator;

    private void Start()
    {
        target = Waypoints.points[0];
        health = startHealth;
        speed = startSpeed;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        
    }

    private void FixedUpdate()
    { 
        switch(state){
        default:
        case State.onPath:
            Vector3 onPath = target.position - transform.position;
            transform.Translate(onPath.normalized * speed * Time.deltaTime, Space.World);
            if (Vector3.Distance(transform.position, target.position) <= 0.2f)
            {
                GetNextWaypoint();
            }
            speed = startSpeed;
            if(player.isAlive)Findtarget();
            Debug.Log(state);
            break;
        case State.onAttack:
            Vector3 onAttack = player.GetPosition() - transform.position;
            transform.Translate(onAttack.normalized * speed * Time.deltaTime, Space.World);
            if(Vector3.Distance(transform.position,player.GetPosition()) < attackRange)
            {
                speed = 0;
                //Debug.Log(Time.fixedTime);
                if(Time.fixedTime > attackTimer)
                {
                    animator.SetTrigger("Enemy_attack");
                    player.health -= 10;
                    player.healthbar.fillAmount = player.health / player.startHealth;
                    float attackRate = 2f;
                    attackTimer = Time.fixedTime + attackRate;
                }
                if(player.health <= 0)
                {
                    state = State.onPath;
                }
            }
            else{
                speed = startSpeed;
            }

            if(Vector3.Distance(transform.position,player.GetPosition()) > chaseRange + (chaseRange*0.2f))
            {
                state = State.onPath;
            }
            break;
        }
        

    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            Die();
            PlayerStats.Lives--;
            return;
        }


        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
        
    }

    public void Findtarget()
    {
       if(Vector3.Distance(transform.position,player.GetPosition()) < chaseRange)
       {
           state = State.onAttack;

       }
       
       
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        healthbar.fillAmount = health / startHealth ;

        if(health <= 0)
        {
            Die();
            PlayerStats.Money += worth;
        }
    }

    public void Slow(float amount)
    {
        speed = startSpeed * amount;
    }

    void Die()
    {

        WaveSpawner.EnemiesAlive--;

        Destroy(gameObject);

    }

    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)return;
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(chasePoint.position,chaseRange);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(10f);
    }
}

