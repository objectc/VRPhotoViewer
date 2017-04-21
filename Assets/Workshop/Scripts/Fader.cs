using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Fader : MonoBehaviour
{
    public float FadeTime = 1;

    [HideInInspector]
    public bool Complete = false;

    private Material _material;
    private MeshRenderer _renderer;

    public Color Color
    {
        get { return _material.GetColor("_Color"); }
        set { _material.SetColor("_Color", value); }
    }

    public float Alpha
    {
        get { return Color.a; }
        set
        {
            Color c = Color;
            c.a = value;
            Color = c;
            _renderer.enabled = value > 0.001;
        }
    }

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
        _material = _renderer.material;
    }

    public void FadeToBlack()
    {
        StopAllCoroutines();
        if (Alpha > 0.999) {
            Complete = true;
            return;
        }
        StartCoroutine(AnimateTo(1, FadeTime));
    }

    public void FadeToTransparent()
    {
        StopAllCoroutines();
        if (Alpha < 0.001) {
            Complete = true;
            return;                                              
        }
        StartCoroutine(AnimateTo(0, FadeTime));
    }

    private IEnumerator AnimateTo(float alpha, float time)
    {
        _renderer.enabled = true;
        Complete = false;

        float start = Alpha;
        float t = 0;
        time -= 0.1f;

        t = 0f;
        while (t < 0.05) {
            t += Time.unscaledDeltaTime;
            yield return null;
        }

        t = 0f;
        while (t < time) {
            float ratio = t / time;
            Alpha = Mathf.Lerp(start, alpha, ratio);
            yield return null;
            t += Time.unscaledDeltaTime;
        }
        Alpha = alpha;

        t = 0f;
        while (t < 0.05) {
            t += Time.unscaledDeltaTime;
            yield return null;
        }


        Complete = true;
    }
}
