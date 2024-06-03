using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TeleportHouse : MonoBehaviour
{
    [SerializeField] private Vector3 tpPosPlayer, tpPosDog;
    public bool blockTp;

    private void OnTriggerStay(Collider other) {
        if (other.CompareTag("Player")){
            if (blockTp) return;

            other.transform.position = tpPosPlayer;

            StartCoroutine(CameraFollow.sharedInstance.InstantFollow(0.1f));

            GameObject.Find("Dog").GetComponent<NavMeshAgent>().Warp(tpPosDog);
        }
    }
}
