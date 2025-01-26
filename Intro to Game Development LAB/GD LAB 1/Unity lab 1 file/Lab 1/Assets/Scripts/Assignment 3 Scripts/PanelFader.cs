using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PanelFader : MonoBehaviour
{
    public float fadeDuration = 1.0f; // Duration for fade in/out
    private Image panelImage;

    private void Start()
    {
        // Get the Image component of the panel
        panelImage = GetComponent<Image>();
        if (panelImage == null)
        {
            Debug.LogError("No Image component found on this panel!");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FadeIn();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            FadeOut();
        }
    }
    // Fade in the panel
    public void FadeIn()
    {
        StartCoroutine(FadePanel(0f, 1f)); // Fade from transparent to opaque
    }

    // Fade out the panel
    public void FadeOut()
    {
        StartCoroutine(FadePanel(1f, 0f)); // Fade from opaque to transparent
    }

    // Coroutine to handle fading logic
    private IEnumerator FadePanel(float startAlpha, float endAlpha)
    {
        float elapsedTime = 0f;

        // Get the current color of the panel
        Color panelColor = panelImage.color;

        // Loop over time to adjust the alpha value
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / fadeDuration);
            panelImage.color = new Color(panelColor.r, panelColor.g, panelColor.b, alpha);
            yield return null; // Wait for the next frame
        }

        // Ensure the panel reaches the exact target alpha
        panelImage.color = new Color(panelColor.r, panelColor.g, panelColor.b, endAlpha);
    }
}
