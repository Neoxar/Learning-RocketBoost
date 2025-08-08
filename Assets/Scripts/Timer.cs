using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;

    private float _elapsedTime;

    void Update()
    {
        _elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(_elapsedTime / 60);
        int seconds = Mathf.FloorToInt(_elapsedTime % 60);
        _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
