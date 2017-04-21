using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public Color UpColor = new Color(0, 30/255f, 90/255f);
    public Color OverColor = new Color(36/255f, 69/255f, 133/255f);
    public Color DownColor = new Color(197/255f, 217/255f, 1);
    Material _material;

    public void Start()
    {
        var r = GetComponent<MeshRenderer>();
        _material = r.materials[1];
        _material.color = UpColor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _material.color = OverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _material.color = UpColor;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _material.color = DownColor;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _material.color = OverColor;
    }
}
