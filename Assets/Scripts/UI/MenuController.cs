using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    [SerializeField] private GameObject _panelMenu;
    [SerializeField] private GameObject _panelInfo;
    [SerializeField] private GameObject _panelLoading;

    public void OnPlayClick()
    {
        _panelMenu.SetActive(false);
        _panelInfo.SetActive(false);
        _panelLoading.SetActive(true);
    }

    public void OnExitClick()
    {
        Application.Quit();
    }

    public void OnInfoClick()
    {
        _panelMenu.SetActive(false);
        _panelInfo.SetActive(true);
    }

    public void OnBackToMenu()
    {
        _panelInfo.SetActive(false);
        _panelMenu.SetActive(true);
    }
}
