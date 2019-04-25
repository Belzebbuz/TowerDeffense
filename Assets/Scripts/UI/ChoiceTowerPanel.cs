using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceTowerPanel : MonoBehaviour {

    [SerializeField] private GameObject[] _prefabTower;
    [SerializeField] private GameObject _buttonPrefab;
    [SerializeField] private AudioClip _audioError;
    [SerializeField] private float _volume;

    private List<ButtonTowerFrame> frames;
    private ImageTower[] imageTowers;
    private Price[] prices;

    private GameObject _towerPlace;
    private SoundObject _soundObject;

    private void Awake()
    {
        SetTowerParameters();
    }
    public void InitTower(GameObject towerPlace)
    {
        _towerPlace = towerPlace;
        
        for (int i = 0; i < _prefabTower.Length; i++)
        {
            if (i >= frames.Count)
            {
                GameObject go = Instantiate(_buttonPrefab, gameObject.transform);
                ButtonTowerFrame frame = go.GetComponent<ButtonTowerFrame>();
                frame.OnButtonClick += CreateTower;
                frames.Add(frame);
            }
            frames[i].SetFrame(i, imageTowers[i].TowerImage, prices[i].BuyPrice.ToString() + "$");
        }
    }
    private void SetTowerParameters()
    {
        frames = new List<ButtonTowerFrame>();
      
        prices = new Price[_prefabTower.Length];
        for (int i = 0; i < _prefabTower.Length; i++)
        {
            var priceTower = _prefabTower[i].GetComponent<Price>();
            if (priceTower != null)
            {
                prices[i] = priceTower;
            }
        }

        imageTowers = new ImageTower[_prefabTower.Length];
        for (int i = 0; i < _prefabTower.Length; i++)
        {
            var imageTower = _prefabTower[i].GetComponent<ImageTower>();
            if (imageTower != null)
            {
                imageTowers[i] = imageTower;
            }
        }
    }
    private void CreateTower(int indexTower)
    {
        if (BuyTower(indexTower))
        {
            Instantiate(_prefabTower[indexTower], _towerPlace.transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(false);
            if (_audioError != null)
            {
                _soundObject = GameManager.Instance.CreateSoundObject();
                _soundObject.Play(_audioError, transform.position, 0f, _volume, false);
            }
        }
    }

    private bool BuyTower(int indexTower)
    {
      var priceTower = _prefabTower[indexTower].GetComponent<Price>();
        if (priceTower != null)
        {
            var currentMoney = GameManager.Instance.currentMoney;
            if (currentMoney >= priceTower.BuyPrice)
            {
                GameManager.Instance.currentMoney -= priceTower.BuyPrice;
                return true;
            }
        }
        return false;
    }
}
