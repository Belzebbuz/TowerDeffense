using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHead : MonoBehaviour {

    [SerializeField] private float _findRadius;
    [SerializeField] private GameObject _gunPrefab;

    private Enemy _enemy;
    private Gun _gun;

    private void Awake()
    {
        _gun = _gunPrefab.GetComponent<Gun>();
    }
    private void Update()
    {
        if (_enemy == null)
        {
            _enemy = FindEnemy();
        }
        else
        {
            LookAtTargetOnly_Y(_enemy.transform);

            if (_gun != null)
            {
                _gun.Shoot(_enemy);
            }

            float dist = Vector3.Distance(_enemy.transform.position, transform.position);
            if (dist > _findRadius)
            {
                _enemy = null;
            }
        }
    }
    private Enemy FindEnemy()
    {
        Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();
        float minDistance = _findRadius;
        Enemy nearestEnemy = null;

        foreach (var enemy in enemies)
        {
            float distance = Vector3.Distance(enemy.transform.position, transform.position);
            if (distance <= minDistance)
            {
                minDistance = distance;
                nearestEnemy = enemy;
            }
        }
        return nearestEnemy;
    }

    private void LookAtTargetOnly_Y(Transform target)
    {
        Vector3 targetPostition = new Vector3(target.position.x, transform.position.y, target.position.z);
        transform.LookAt(targetPostition);
    }

}
