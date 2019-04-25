using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour {

    [SerializeField] private float healthMax;

    public Action<Damagable> DamageEvent;
    public Action<Damagable> DieEvent;

    public float Health { get; private set; }
    public float HealthMax { get { return healthMax; } }
    private void Awake()
    {
        Health = HealthMax;
    }
    private void OnTriggerEnter(Collider collider)
    {
        var _gameObjectDamageProvider = gameObject.GetComponent<DamageProvider>();
        var _damageProvider = collider.GetComponentInParent<DamageProvider>();
        if (_damageProvider != null && _gameObjectDamageProvider != null)
        {
            if (_gameObjectDamageProvider.DamageAfterCollide || _damageProvider.DamageAfterCollide)
            {
                Health -= _damageProvider.Damage;
                if (DamageEvent != null)
                    DamageEvent(this);
                if (Health <= 0)
                {
                    if (DieEvent != null)
                        DieEvent(this);
                    Destroy(gameObject);
                }
            }
        }
    }
}
   