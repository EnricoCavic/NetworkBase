using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Cavic.Gameplay
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent agent = null;

        public void SetDestination(Vector3 _position)
        {
            if (!NavMesh.SamplePosition(_position, out NavMeshHit hit, 1f, NavMesh.AllAreas))  
                return;

            agent.SetDestination(hit.position);
        }
    }
}