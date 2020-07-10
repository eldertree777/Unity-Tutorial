using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public Image fadeImage;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeIn());
        // StartCoroutine("FadeIn"); 인위적으로 멈추는게 가능
    }

    // Update is called once per frame
    IEnumerator FadeIn()
   {
        Color startColor = fadeImage.color;

        for (int i=0; i<100; i++)
        {
            startColor.a = startColor.a - 0.01f;
            fadeImage.color = startColor;
            yield return new WaitForSeconds(0.01f);
        }
   }
}
