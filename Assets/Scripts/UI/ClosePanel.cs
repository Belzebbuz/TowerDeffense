using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePanel : MonoBehaviour {

    public void OnClose()
    {
        gameObject.SetActive(false);
    }
}
