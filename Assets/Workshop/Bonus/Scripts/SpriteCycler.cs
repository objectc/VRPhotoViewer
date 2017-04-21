using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class SpriteCycler : MonoBehaviour, IPointerClickHandler
{
    public Sprite[] Sprites;
    public Image LeftImage;
    public Image RightImage;

    private int _currentIndex = 0;

    void Start()
    {
        LeftImage.sprite = RightImage.sprite = Sprites[_currentIndex];
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _currentIndex++;
        if (_currentIndex >= Sprites.Length) {
            _currentIndex = 0;
        }
        LeftImage.sprite = RightImage.sprite = Sprites[_currentIndex];
    }
}
