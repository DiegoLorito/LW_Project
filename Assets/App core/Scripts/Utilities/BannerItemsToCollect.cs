using UnityEngine;
using UnityEngine.UI;

public class BannerItemsToCollect : MonoBehaviour
{
    [SerializeField] private Transform _containerDots;
    [SerializeField] private Color _collectedColor;

    private Image[] _dots;

    private int _currentItem;
    private int _totalItems;

    public void Initialize(int total)
    {
        _dots = new Image[total];
        _currentItem = 0;
        _totalItems = total;

        PoolingDots();
        SetCurrentDots();


        void PoolingDots()
        {
            if (_containerDots.childCount < total)
            {
                int diff = total - _containerDots.childCount;

                for (int i = 0; i < diff; i++)
                {
                    GameObject dot = _containerDots.GetChild(0).gameObject;
                    Instantiate(dot, _containerDots);
                }
            }
        }
        void SetCurrentDots()
        {
            for (int i = 0; i < _containerDots.childCount; i++)
            {
                _containerDots.GetChild(i).SetActive(i < total);

                if (i < total)
                {
                    _dots[i] = _containerDots.GetChild(i).GetComponent<Image>();
                    _dots[i].color = ConstantsUI.colorLightGray2;
                }
            }
        }
    }
    public void CollectItem()
    {
        _dots[_currentItem].color = _collectedColor;

        _currentItem++;

        if (_currentItem > _totalItems) _currentItem = _totalItems;
    }
    public void Restart()
    {
        _currentItem = 0;

        for (int i = 0; i < _dots.Length; i++)
        {
            _dots[i].color = ConstantsUI.colorLightGray2;
        }
    }
}
