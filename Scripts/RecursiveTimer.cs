using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RecursiveTimerMMSS : MonoBehaviour
{
    public Text timerText;
    private float elapsedTime = 0f;

    void Start()
    {
        StartCoroutine(UpdateTimer());
    }

    IEnumerator UpdateTimer()
    {
        yield return new WaitForSeconds(1f);
        elapsedTime += 1f;
        UpdateTimerText();
        StartCoroutine(UpdateTimer());
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60F);
        int seconds = Mathf.FloorToInt(elapsedTime % 60F);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
