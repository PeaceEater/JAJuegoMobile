using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogFollowPlayer : MonoBehaviour
{
    public static DogFollowPlayer sharedInstance;

    [SerializeField] private Transform player;
    public bool stopFollow;
    private NavMeshAgent agent;

    private void Awake() {
        if(sharedInstance == null){
            sharedInstance = this;
        }
    }

    private void Start() {
        agent = GetComponent<NavMeshAgent>();
    }

    void FixedUpdate(){
        if (stopFollow || DogController.sharedInstance.controllingActive){
            if (agent.enabled){
                agent.isStopped = true;   
                agent.enabled = false;
            }
            return;
        } 

        agent.enabled = true;
        agent.isStopped = false;
        agent.SetDestination(player.transform.position);
    }
}

