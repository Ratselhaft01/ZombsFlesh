using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy_behavior : MonoBehaviour
{
    [SerializeField] float chaseRange = 5f;

    private Transform playerT;
    float timeRemaining = 1;
    bool isProvoked = false;
    life_counter playerHealth;
    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    // Start is called before the first frame update
    void Start() {
        playerT = GameObject.Find("Player").GetComponent<Transform>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        life_counter life = GetComponent<life_counter>();
        life.SetHealth(1);

        life_counter playerHealth = playerT.GetComponent<life_counter>();
    }

    // Update is called once per frame
    void Update() {
        distanceToTarget = Vector3.Distance(playerT.position, transform.position);
        if (isProvoked) {
            EngageTarget();
        }
        else if (distanceToTarget <= chaseRange) {
            isProvoked = true;
        }
    }

    private void EngageTarget() {
        if (distanceToTarget >= navMeshAgent.stoppingDistance) {
            ChaseTarget();
        }
        if (distanceToTarget <= navMeshAgent.stoppingDistance) {
            AttackTarget();
        }
    }

    private void AttackTarget() {
        if (timeRemaining > 0) {
            timeRemaining -= Time.deltaTime;
        }
        else {
            if (Input.GetMouseButton(0)) {
                timeRemaining = 1f;
                playerHealth.DealDamage(1); 
            }
        }
    }

    private void ChaseTarget() {
        navMeshAgent.SetDestination(playerT.position);
    }
}
