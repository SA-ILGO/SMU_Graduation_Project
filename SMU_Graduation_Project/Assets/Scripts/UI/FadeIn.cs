using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    private Image fadeImage;
    private float fadeDuration = 0.5f;

    public void Flash()
    {
        StartCoroutine(FlashRoutine());
    }

    private IEnumerator FlashRoutine()
    {
        float halfTime = fadeDuration / 2f;
        float time = 0f;

        // ���� ��ο���
        while (time < halfTime)
        {
            time += Time.deltaTime;
            float t = time / halfTime;

            Color c = fadeImage.color;
            c.a = Mathf.Lerp(0f, 1f, t);
            fadeImage.color = c;

            yield return null;
        }

        time = 0f;

        // ���� �����
        while (time < halfTime)
        {
            time += Time.deltaTime;
            float t = time / halfTime;

            Color c = fadeImage.color;
            c.a = Mathf.Lerp(1f, 0f, t);
            fadeImage.color = c;

            yield return null;
        }

        // Ȯ���� ��������
        Color final = fadeImage.color;
        final.a = 0f;
        fadeImage.color = final;
    }
}
