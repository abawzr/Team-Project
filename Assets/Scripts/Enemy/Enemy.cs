using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private List<Transform> patrolPoints;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float viewAngle = 60f;
    [SerializeField] private float viewDistance = 10f;
    [SerializeField] private LayerMask excludeEnemyLayer;
    [SerializeField] private Transform jumpscarePointTransform;
    [SerializeField] private float jumpscareDistance;
    [SerializeField] private AudioSource footstepAudioSource;
    [SerializeField] private AudioClip footstepClip;
    [SerializeField] private float walkStepInterval;
    [SerializeField] private float runStepInterval;

    private NavMeshAgent _navMeshAgent;
    private Animator _animator;
    private int _currentPatrolPoint;
    private Vector3 _eyePosition;
    private Vector3 _directionToPlayer;
    private float _stepTimer;
    private bool _isJumpscareOccurred;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, viewDistance);

        Vector3 rightLimit = Quaternion.Euler(0, viewAngle, 0) * transform.forward;
        Vector3 leftLimit = Quaternion.Euler(0, -viewAngle, 0) * transform.forward;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + transform.up * 0.5f, transform.position + rightLimit * viewDistance);
        Gizmos.DrawLine(transform.position + transform.up * 0.5f, transform.position + leftLimit * viewDistance);

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(_eyePosition, _directionToPlayer * viewDistance);
    }

    private void Awake()
    {
        // Get Nav Mesh Agent and Animator components from same game object this script attached to
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        // In the start pick a random patrol point and set enemy destination to it
        int randomIndex = Random.Range(0, patrolPoints.Count);
        _navMeshAgent.SetDestination(patrolPoints[randomIndex].position);
    }

    private void Update()
    {
        _animator.SetFloat("Speed", _navMeshAgent.velocity.magnitude);

        if (!_isJumpscareOccurred)
        {
            // Check if enemy can see player
            if (CanSeePlayer())
            {
                _animator.SetBool("IsChasing", true);

                // Speed up the enemy and make it follow player
                _navMeshAgent.speed = 5f;
                _navMeshAgent.SetDestination(playerTransform.position);

                if (Vector3.Distance(transform.position, playerTransform.position) <= jumpscareDistance)
                {
                    PlayerMovement.IsMovementInputOn = false;
                    PlayerCamera.IsCameraInputOn = false;

                    _navMeshAgent.speed = 0f;
                    _navMeshAgent.acceleration = 0f;
                    _navMeshAgent.velocity = Vector3.zero;

                    transform.position = jumpscarePointTransform.position;
                    transform.rotation = jumpscarePointTransform.localRotation;

                    _animator.SetBool("IsJumpscare", true);

                    _isJumpscareOccurred = true;
                }
            }
            else
            {
                _animator.SetBool("IsChasing", false);

                // Slow down the enemy and make him patrolling
                _navMeshAgent.speed = 3.5f;
                if (!_navMeshAgent.pathPending && _navMeshAgent.remainingDistance < 0.2f)
                {
                    NextPoint();
                }
            }

            PlayFootstep();
        }
    }

    private bool CanSeePlayer()
    {
        if (PlayerInteraction.IsPlayerHidden) return false;

        // Check distance between enemy and player
        float distance = Vector3.Distance(transform.position, playerTransform.position);
        if (distance > viewDistance) return false;

        // Check field of view
        _eyePosition = transform.position + transform.up * 1.8f;
        _directionToPlayer = (playerTransform.position + playerTransform.up * 0.25f - _eyePosition).normalized;
        float angle = Vector3.Angle(transform.forward, _directionToPlayer);
        if (angle > viewAngle) return false;

        // Raycast to check if wall is blocking
        if (Physics.Raycast(_eyePosition, _directionToPlayer, out RaycastHit hitInfo, viewDistance, excludeEnemyLayer))
        {
            if (hitInfo.collider.tag == "Player")
            {
                return true;
            }

            return false; // Player is not visible
        }

        return true; // Player is visible
    }

    private void NextPoint()
    {
        if (patrolPoints.Count == 0) return;

        // Don't stop the loop till next point found
        while (true)
        {
            int tempIndex = Random.Range(0, patrolPoints.Count);

            if (tempIndex != _currentPatrolPoint)
            {
                _currentPatrolPoint = tempIndex;
                break;
            }
        }

        _navMeshAgent.SetDestination(patrolPoints[_currentPatrolPoint].position);
    }

    private void PlayFootstep()
    {
        if (footstepClip == null) return;

        float speed = _navMeshAgent.velocity.magnitude;

        // Enemy is not moving
        if (speed < 0.01f)
        {
            _stepTimer = 0;
            return;
        }

        float stepInterval = speed < 5 ? walkStepInterval : runStepInterval;

        _stepTimer += Time.deltaTime;

        if (_stepTimer >= stepInterval)
        {
            footstepAudioSource.PlayOneShot(footstepClip);
            _stepTimer = 0;
        }
    }
}
