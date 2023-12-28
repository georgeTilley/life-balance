using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ProgressBar : MonoBehaviour
{
    private UnityEngine.UI.Slider slider;
    private Coroutine decreaseCoroutine;
    // Start is called before the first frame update
    private void Awake()
    {
        slider = GetComponent<UnityEngine.UI.Slider>();
    }

    private void Start()
    {
       decreaseCoroutine = StartCoroutine(DecreaseSliderValue(slider.maxValue)); 
    }

    public void setSlider(float progress)
    {
        if (decreaseCoroutine != null)
        {
            StopCoroutine(decreaseCoroutine);
        }
        slider.value = progress;
        decreaseCoroutine = StartCoroutine(DecreaseSliderValue(progress));
    }

    public void OnObjectPickedUp()
    {
        Debug.Log("Object picked up");
        StopCoroutine(decreaseCoroutine);
        decreaseCoroutine = StartCoroutine(DecreaseSliderValue(slider.value + 10));
    }
    IEnumerator DecreaseSliderValue(float startPoint)
    {
            float duration = 20f; // Duration in seconds
            float elapsed = 0f;
            slider.value = startPoint;
            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;
                float progress = elapsed / duration;
                slider.value = Mathf.Lerp(slider.maxValue, slider.minValue, progress);
                yield return null;
            }
            
            MenuManager.instance.GameOver(tag);
    }

}
