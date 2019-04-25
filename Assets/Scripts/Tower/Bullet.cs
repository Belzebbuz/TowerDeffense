using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField] private float _speed;

    private Transform _target;

    public void Init(Transform target)
    {
        _target = target;

    }

    private void Update()
    {
        if (_target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
        }
        else
            Destroy(gameObject);
    }
}
