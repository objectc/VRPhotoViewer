using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Clickable : Graphic
{
    protected override void OnFillVBO(List<UIVertex> vbo)
    {
    }

    public override bool Raycast(Vector2 sp, Camera eventCamera)
    {
        return true;
    }
}
