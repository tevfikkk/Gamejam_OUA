using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFade : Singleton<UIFade>
{
    [Header("UI Fade Settings")]
    [SerializeField] private Image fadeScreen;
    [SerializeField] private float fadeSpeed = 1f;

    private IEnumerator fadeRoutine;

    /// <summary>
    /// Fades the screen to black
    /// </summary>
    public void FadeToBlack()
    {
        if (fadeRoutine != null)
        {
            StopCoroutine(fadeRoutine);
        }

        fadeRoutine = FadeRoutine(1f);
        StartCoroutine(fadeRoutine);
    }

    /// <summary>
    /// Fades the screen to clear
    /// </summary>
    public void FadeToClear()
    {
        if (fadeRoutine != null)
        {
            StopCoroutine(fadeRoutine);
        }

        fadeRoutine = FadeRoutine(0f);
        StartCoroutine(fadeRoutine);
    }

    /// <summary>
    /// Fades the screen to target alpha value.
    /// Target alpha value should be between 0 and 1.
    /// </summary>
    private IEnumerator FadeRoutine(float targetAlpha)
    {
        while (!Mathf.Approximately(fadeScreen.color.a, targetAlpha))
        {
            float alpha = Mathf.MoveTowards(fadeScreen.color.a, targetAlpha, fadeSpeed * Time.deltaTime);
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, alpha);
            yield return null;
        }
    }
}
