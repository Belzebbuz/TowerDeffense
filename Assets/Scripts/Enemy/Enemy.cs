using System;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] private AudioClip _audioMotor;
    [SerializeField] private AudioClip _audioDied;
    [SerializeField] private int deadMoney;

    private Damagable _damagable;
    private SoundObject _soundObject;
    private Move _moveEnemy;

    private void Awake()
    {
        if (_audioMotor != null )
        {
            _soundObject = GameManager.Instance.CreateSoundObject();
            _soundObject.transform.SetParent(transform);
            _soundObject.Play(_audioMotor, transform.position, 1f,  0.1f, true);
        }
        _damagable = GetComponent<Damagable>();
        if (_damagable != null)
            _damagable.DieEvent += OnDead;

        _moveEnemy = GetComponent<Move>();
        if (_moveEnemy != null)
        {
            _moveEnemy.ArriveTargetEvent += ArriteTarget;
        }
    }

    private void ArriteTarget(Move obj)
    {
        var damageEnemy = this.GetComponentInParent<DamageProvider>();
        if (damageEnemy != null)
        {
            GameManager.Instance._baseHealth -= (int)damageEnemy.Damage;
            GameManager.Instance.DeleteEnemy();
        }
    }

    private void OnDead(Damagable damagable)
    {
        _damagable.DieEvent -= OnDead;
        GameManager.Instance.DeleteEnemy();
        GameManager.Instance.currentMoney += deadMoney;
        if (_audioDied != null)
        {
            _soundObject = GameManager.Instance.CreateSoundObject();
            _soundObject.Play(_audioDied, transform.position, 1f, 1f, false);
        }
        Destroy(gameObject);
    }
}
