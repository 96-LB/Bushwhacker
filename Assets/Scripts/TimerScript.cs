using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{

    public Image timer;
    public float time = 5;
    float startTime;
    float endTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer.fillAmount = Mathf.Clamp01((Time.time - startTime) / (endTime - startTime));

        if (Time.time > endTime)
        {
            startTime = Time.time;
            endTime = startTime + time;
        }
    }
}
