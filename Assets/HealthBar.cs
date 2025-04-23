using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Slider bar;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] TextMeshProUGUI timer;
    [SerializeField] GameObject canvas;
    float startTime;
    float time;
    int minutes;
    float seconds;
    [SerializeField] float healthLossRate = 0.2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text.text = "Health: "+Math.Round(bar.normalizedValue*100).ToString()+"/100";
        startTime = Time.time;
        timer.text = "Elapsed: 0s";
    }

    // Update is called once per frame
    void Update()
    {
        bar.normalizedValue -= 1e-3f *Time.deltaTime * healthLossRate;
        text.text = "Health: "+Math.Round(bar.normalizedValue*100).ToString()+"/100";
        time  = Time.time - startTime;
        minutes = (int) time/60;
        seconds = time%60;
        timer.text = "Elapsed: "+minutes.ToString()+"min "+Math.Round(seconds).ToString()+"s";
        if(bar.normalizedValue==0){
            canvas.SetActive(true);
        }
    }
}
