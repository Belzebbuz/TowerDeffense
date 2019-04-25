using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour {

    [SerializeField] private int sceneID;
    [SerializeField] private Image loadingImg;
    [SerializeField] private Text progressText;

    void Start()
    {
        StartCoroutine(AsyncLoad(sceneID));
    }

    IEnumerator AsyncLoad(int _sceneID)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(_sceneID);
        while(!operation.isDone)
        {
            float progress = operation.progress / 0.9f;
            loadingImg.fillAmount = progress;
            progressText.text = string.Format("{0:0}%",progress*100);
            yield return null;
        }
    }
}
