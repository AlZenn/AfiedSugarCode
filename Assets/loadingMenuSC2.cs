using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loadingMenuSC2 : MonoBehaviour
{
    private Slider timeSlider;
    private Text timeSliderText;

    // Start is called before the first frame update
    void Start()
    {
        timeSlider = GameObject.Find("Slider").GetComponent<Slider>();
        timeSliderText = GameObject.Find("TimeText").GetComponent<Text>();

        timeSlider.value = 15f;
    }

    // Update is called once per frame
    void Update()
    {
        timeSlider.value -= Time.deltaTime;
        timeSliderText.text = timeSlider.value.ToString("F0");

        if (timeSlider.value <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }
}
