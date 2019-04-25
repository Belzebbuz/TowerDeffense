using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

    [SerializeField] private Text _healthBase;
    [SerializeField] private Text _countWave;
    [SerializeField] private Text _currentWave;
    [SerializeField] private Text _currentMoney;
    [SerializeField] private float _timingAnimationWave;

    private int _previousWave;
    private LevelController _levelController;

    private void Awake()
    {
        _levelController = GameManager.Instance.LevelController;
        if (_levelController != null)
            _levelController.NextWaveEvent += NextWave;
    }

    private void NextWave(LevelController obj)
    {
        _currentWave.text = "Wave: " + (obj.CurrentWaveIndex + 1);
        _currentWave.DOFade(1f, _timingAnimationWave / 2f).OnComplete(() => { _currentWave.DOFade(0f, _timingAnimationWave / 2f); }).Play();
        _countWave.text = (obj.CurrentWaveIndex + 1) + "/" + obj.MaxWave;
    }

    private void Update()
    {
        _healthBase.text = GameManager.Instance._baseHealth.ToString();
        _currentMoney.text = GameManager.Instance.currentMoney.ToString();
    }

}
