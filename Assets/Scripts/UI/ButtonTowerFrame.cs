using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTowerFrame : MonoBehaviour {
    [SerializeField] private Text text;
    [SerializeField] private Button button;

    private int Id;

    public delegate void ButtonClick(int id);
    public event ButtonClick OnButtonClick;

    private void Start()
    {
        button.onClick.AddListener(onBtnClick);
    }

    private void onBtnClick()
    {
        if (OnButtonClick != null)
            OnButtonClick(Id);
    }

    public void SetFrame(int id, Sprite sprite, string text)
    {
        Id = id;
        button.image.sprite = sprite;
        this.text.text = text;
    }
}
