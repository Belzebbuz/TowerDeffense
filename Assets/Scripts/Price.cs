using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Price : MonoBehaviour {

    [SerializeField] private int buyPrice;
    [SerializeField] private int salePrice;
    public int BuyPrice { get { return buyPrice; } }
    public int SalePrice { get { return salePrice; } }

}
