using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SalePanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField] private GameObject salePanel;

    private Price priceTower;
    
    private void Awake()
    {
        if(salePanel != null)
            salePanel.transform.rotation = Camera.main.transform.rotation;
        priceTower = GetComponent<Price>();
    }

    public void OnSale()
    {
        if (priceTower != null)
        {
            GameManager.Instance.currentMoney += priceTower.SalePrice;
            Destroy(gameObject);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(salePanel != null)
            salePanel.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (salePanel != null)
            salePanel.SetActive(false);
    }
}
