using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState
{
    CHASE,
    ATTACK
}

public class EnemyController : MonoBehaviour
{
    private CharacterAnimations enemy_Anim;
    private NavMeshAgent navMeshAgent;

    private Transform playerTarget;

    public float move_Speed = 3.5f;

    public float attack_Distance = 1f;
    public float chase_Player_After_Attack_Distance = 1f;

    private float wait_Before_Attack_Time = 3f;
    private float attack_Timer;

    private EnemyState enemy_State;

    public GameObject attackPoint;

    private CharacterSoundFX soundFX;

    void Awake()
    {
        enemy_Anim = GetComponent<CharacterAnimations>();
        navMeshAgent = GetComponent<NavMeshAgent>();

        playerTarget = GameObject.FindGameObjectWithTag(Tags.PLAYER_TAG).transform;

        soundFX = GetComponentInChildren<CharacterSoundFX>();
    }

    // Start is called before the first frame update
    void Start()
    {
        enemy_State = EnemyState.CHASE;

        attack_Timer = wait_Before_Attack_Time;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy_State == EnemyState.CHASE)
        {
            ChasePlayer();
        }

        if (enemy_State == EnemyState.ATTACK)
        {
            AttackPlayer();
        }
    }

    void ChasePlayer()
    {
        navMeshAgent.SetDestination(playerTarget.position);
        navMeshAgent.speed = move_Speed;

        if (navMeshAgent.velocity.sqrMagnitude == 0)
        {
            enemy_Anim.Walk(false);
        }
        else
        {
            enemy_Anim.Walk(true);
        }

        if (Vector3.Distance(transform.position, playerTarget.position) <= attack_Distance)
        {
            enemy_State = EnemyState.ATTACK;
        }
    }

    void AttackPlayer()
    {
        navMeshAgent.velocity = Vector3.zero;
        navMeshAgent.isStopped = true;

        enemy_Anim.Walk(false);

        attack_Timer += Time.deltaTime;

        if (attack_Timer > wait_Before_Attack_Time)
        {
            if (Random.Range(0, 2) > 0)
            {
                enemy_Anim.Attack_1();
                soundFX.Attack_1();
            }
            else
            {
                enemy_Anim.Attack_2();
                soundFX.Attack_2();
            }

            attack_Timer = 0f;
        }

        if (Vector3.Distance(transform.position, playerTarget.position) > attack_Distance + chase_Player_After_Attack_Distance)
        {
            navMeshAgent.isStopped = false;
            enemy_State = EnemyState.CHASE;
        }
    }

    void Activate_AttackPoint()
    {
        attackPoint.SetActive(true);
    }

    void Deactivate_AttackPoint()
    {
        if (attackPoint.activeInHierarchy)
        {
            attackPoint.SetActive(false);
        }
    }
}
