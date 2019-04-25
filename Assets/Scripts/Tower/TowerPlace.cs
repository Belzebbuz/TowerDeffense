using UnityEngine;
using UnityEngine.EventSystems;

public class TowerPlace : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private GameObject _choiceTowerPanel;

    private Material _material;
    private Color _beginColor;
    private void Awake()
    {
         _material = GetComponent<Renderer>().material;
        if (_material != null)
            _beginColor = _material.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_material != null)
            _material.color = Color.green;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (_material != null)
            _material.color = _beginColor;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_choiceTowerPanel != null)
        {
            var tower = _choiceTowerPanel.GetComponent<ChoiceTowerPanel>();
            if (tower != null)
            {
                _choiceTowerPanel.SetActive(true);
                tower.InitTower(gameObject);
            }
        }
    }
}
