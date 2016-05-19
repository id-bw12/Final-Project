using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class MenuAnimation : BaseControlScript{

    public void FadeAnimation(bool isFading) {

        if (isFading)
            StartCoroutine(FadeOut());
        else
            StartCoroutine(FadeIn());
    }

    IEnumerator FadeOut() {

        var canvasAlpha = GameObject.Find("Canvas").GetComponent<CanvasGroup>();

        canvasAlpha.interactable = false;
        yield return null;

		while (canvasAlpha.alpha > 0) {

			canvasAlpha.alpha -= Time.deltaTime *2;
            yield return null;
        }

        
    }

    IEnumerator FadeIn(){

        var canvasAlpha = GameObject.Find("Canvas").GetComponent<CanvasGroup>();
        
        while (canvasAlpha.alpha < 1)
        {
            canvasAlpha.alpha += Time.deltaTime *2;
            yield return null;
        }

        canvasAlpha.interactable = true;
        yield return null;
    }
}