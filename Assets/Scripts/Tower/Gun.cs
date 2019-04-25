using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    [SerializeField] GameObject _prefabBullet;
    [SerializeField] private float timeShoot;
    [SerializeField] private AudioClip _audio;
    [SerializeField] private float _volume;

    private float _timerShoot = 0;
    private Bullet _bullet;
    private SoundObject _soundObject;

    private void Update()
    {
        if (_timerShoot >= 0)
            _timerShoot -= Time.deltaTime;
    }

    public void Shoot(Enemy enemy)
    {
        if(_timerShoot <= 0)
        {
            if(_prefabBullet != null)
                _bullet = Instantiate(_prefabBullet, transform.position, transform.rotation).GetComponent<Bullet>();
            if (_bullet != null)
                _bullet.Init(enemy.transform);
            if (_audio != null)
            {
                _soundObject = GameManager.Instance.CreateSoundObject();
                _soundObject.Play(_audio, transform.position, 1f, _volume, false);
            }
            var particle = transform.GetComponent<ParticleSystem>();
            if (particle != null)
                particle.Play();

            _timerShoot = timeShoot;
        }
    }
}