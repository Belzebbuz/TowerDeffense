using System;
using UnityEngine;
using UnityEngine.AI;

public class Move : MonoBehaviour {

    [SerializeField] private float _moveSpeed;
    [SerializeField] private Transform _targetObject;

    public Action<Move> ArriveTargetEvent;

    private NavMeshAgent _navAgent;

    private void Start()
    {
        _navAgent = GetComponent<NavMeshAgent>();
        _navAgent.SetDestination(_targetObject.position);
        _navAgent.speed = _moveSpeed;
    }

    private void Update()
    {
        if (Vector3.Distance(_navAgent.transform.position, _targetObject.transform.position) < 5f)
        {
            if (ArriveTargetEvent != null)
                ArriveTargetEvent(this);
            Destroy(gameObject);
        }
    }
}
