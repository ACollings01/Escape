using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    private GameObject player;
    private GameObject moveTarget;
    private ParticleSystem targetParticles;
    private Camera playerCamera;
    private NavMeshAgent playerAgent;
    private int layerMask = 1 << 9; // Layer 9 is the walkable area, limits movement to within the walkable area.

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("pBody");
        moveTarget = GameObject.Find("pMoveTarget");
        targetParticles = moveTarget.GetComponent<ParticleSystem>();
        playerCamera = GameObject.Find("pCamera").GetComponent<Camera>();
        playerAgent = player.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        CameraFollow();
    }

    private void MovePlayer()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            // Only move if the player right clicks
            if (Input.GetKey("mouse 1"))
            {
                // Move the destination object
                moveTarget.transform.position = hit.point;

                // Play a particle effect when the moveTarget position is set
                targetParticles.Play();

                // Set the player's target
                playerAgent.SetDestination(moveTarget.transform.position);
            }
        }
    }

    private void CameraFollow()
    {
        playerCamera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 12, player.transform.position.z - 8);
    }
}
