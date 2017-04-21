using UnityEngine;
using System.Collections;


// Attach this script to an object to allow for easy cycling of textures.
public class TextureCycler : MonoBehaviour
{
    public const int Increment = 0;
    public const int Decrement = 1;
    public const int Slideshow = 2;

    // Public control variables
    public float CycleDelay = 5.0f; 	// The delay, ONLY IF IN SLIDESHOW MODE, between cycling textures
    public Fader Fader;
    public Texture[] Textures;

    private int _cycleMode;
    private bool _decrement;
    private int _currentIndex = 0; 		// Current texture index to display
    private float _updateTime = 0.0f;	// The timing used for cycling slideshow (this controls the next time to cycle)
    private bool _slideStarted = false;	// Set to true when the user first clicks the slideshow to start it
    private Material _material;

    void Start()
    {
        _material = GetComponent<MeshRenderer>().material;
        if (Fader != null) {
            Fader.Alpha = 1;
        }
        StartCoroutine(LoadNextTexture());
    }

    void Update()
    {
        // Responsible for cycling textures every (CycleDelay) intervals.
        if (_slideStarted && Time.unscaledTime >= _updateTime) {
            _updateTime = Time.unscaledTime + CycleDelay;
            if (_decrement) {
                _currentIndex--;
            } else {
                _currentIndex++;
            }
            StartCoroutine(LoadNextTexture());
        }
    }

    public void SetCycleMode(int mode)
    {
        _cycleMode = mode;
        switch (mode) {
            case Increment:
                _decrement = false;
                if (!_slideStarted) {
                    _currentIndex++;
                    StartCoroutine(LoadNextTexture());
                }
                break;
            case Decrement:
                _decrement = true;
                if (!_slideStarted) {
                    _currentIndex--;
                    StartCoroutine(LoadNextTexture());
                }
                break;
            default:
                _cycleMode = Slideshow;
                _slideStarted = !_slideStarted;
                break;
        }
    }

    // Ensures the texture index for current display is never out of bounds!
    private IEnumerator LoadNextTexture()
    {

        if (_currentIndex == Textures.Length || _currentIndex < 0) {

            switch (_cycleMode) {

                case Increment:
                    _currentIndex = 0;
                    break;

                case Decrement:
                    _currentIndex = Textures.Length - 1;
                    break;

                case Slideshow:
                    _currentIndex = (_decrement) ? Textures.Length - 1 : 0;
                    break;
            }
        }

        if (Fader != null) {
            Fader.FadeToBlack();
            while (!Fader.Complete) {
                yield return null;
            }
        }

        _material.mainTexture = Textures[_currentIndex];

        if (Fader != null) {
            Fader.FadeToTransparent();
            while (!Fader.Complete) {
                yield return null;
            }
        }
    }
}
