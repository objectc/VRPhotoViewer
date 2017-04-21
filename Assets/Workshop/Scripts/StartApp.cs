using UnityEngine;
using System.Collections;
using System.IO;


// StartApp is responsible for handling the scene introductions and transitions when the application first starts.
public class StartApp : MonoBehaviour
{

    public int MainSceneIndex = 1;
    public float SplashDuration = 2.5f;
    public Fader Fader;

    // Use this for initialization
    IEnumerator Start()
    {
        //Application.targetFrameRate = 60;
        float t = SplashDuration;

        if (Fader != null) {
            Fader.Alpha = 0;
            t -= Fader.FadeTime;
        }
        while (t > 0) {
            t -= Time.deltaTime;
            yield return null;
        }

        if (Fader != null) {
            Fader.FadeToBlack();
            while (!Fader.Complete) {
                yield return null;
            }
        }

        Application.LoadLevel(MainSceneIndex);
    }

}