using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent nav;
    private Animator ani;
    private float HP;

    [Header("speed"), Range(0, 50)]
    public float speed = 3;
    [Header("stop"), Range(0, 50)]
    public float stopDistance = 3;
    [Header("CD"), Range(0, 5)]
    public float cd = 1.5f;
    private float timer;
    [Header("AttackPoint")]
    public Transform PointAtk;
    [Header("AtkLenth"), Range(0, 5f)]
    public float atkLenth;
    private RaycastHit hit;
    public int ATK = 0;

    private void Awake()
    {
        ani = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
        ATK = Random.Range(10, 50);

        nav.speed = speed;
        nav.stoppingDistance = stopDistance;
    }
    private void Update()
    {
        track();
        attack();
        ATK = Random.Range(10, 50);

    }
   


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(PointAtk.position, PointAtk.forward * atkLenth);
    }
    private void attack()
    {
        if (nav.remainingDistance < stopDistance)
        {
            timer += Time.deltaTime;
            Vector3 pos = player.position;
            pos.y = transform.position.y;
            transform.LookAt(pos);

            if (timer >= cd)
            {
                
                timer = 0;
                if (Physics.Raycast(PointAtk.position, PointAtk.forward, out hit, atkLenth, 1 << 11))
                {
                    ani.SetTrigger("attack");
                }

            }

        }

    }
   
    private void track()
    {
        nav.SetDestination(player.position);
        ani.SetBool("walk", nav.remainingDistance > stopDistance);

    }
}
