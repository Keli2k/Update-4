using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    protected float speed = 3.0f;
    public Transform player;public int health = 2;
    private Transform target;
    public Animator animator;
    private DEnemyController patrol;

    public Transform Target
    {
        get
        {
            return target;
        }

        set
        {
            target = value;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        patrol = GetComponent<DEnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        FollowTarget();
    }

    public void TakeDamage(int damage)
    {

        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    
        void Die()
        {
            Destroy(gameObject);
        }
        

   
            void FollowTarget()
    {
        if (target != null)
        {
            patrol.enabled = false;
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            animator.SetFloat("Speed", speed);
        }
    }

}

