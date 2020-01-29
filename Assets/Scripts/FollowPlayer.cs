using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    private GameObject player;
    public GameObject[] enemies;

    void Start()
    {
        player = GameObject.Find("pBody");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    void Update()
    {
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
        }
    }
}
