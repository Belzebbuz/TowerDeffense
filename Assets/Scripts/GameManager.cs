using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager Instance { get; private set; }
    public int CurrentCountEnemy { get; private set; }
    public LevelController LevelController { get { return _levelController; } }
    public int currentMoney;
    public int _baseHealth;

    [SerializeField] private LevelController _levelController;
    [SerializeField] private SoundObject _soundObjectPrefab;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private GameObject _panelGame;

    private void Awake()
    {
        Instance = this;
        CurrentCountEnemy = 0;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        _panelGame.SetActive(false);
        _losePanel.SetActive(true);
    }
    public void Victory()
    {
        Time.timeScale = 0;
        _panelGame.SetActive(false);
        _winPanel.SetActive(true);
    }

    public SoundObject CreateSoundObject()
    {
        var go = Instantiate(_soundObjectPrefab);
        return go.GetComponent<SoundObject>();
    }

    public void AddEnemy()
    {
        CurrentCountEnemy++;
    }
    public void DeleteEnemy()
    {
        CurrentCountEnemy--;
    }
    private void Update()
    {
        if (_baseHealth <= 0)
            GameOver();
    }

}
