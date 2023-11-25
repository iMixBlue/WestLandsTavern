using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookFunction_A : MonoBehaviour
{
    public GameObject slider;
    public float sliderSpeed = 5.0f;
    public GameObject backgroundSlider;
    public float backgroundSliderSpeed;
    public float range = 10.0f; 

     private float originalX; // 初始X坐标
    private bool movingRight = true; // 判断滑块移动方向
    // Start is called before the first frame update
    void Start()
    {
         originalX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(slider != null && backgroundSlider != null){
            float translation = sliderSpeed * Time.deltaTime;
             if (movingRight)
        {
            slider.transform.Translate(translation, 0, 0);
        }
        else
        {
            slider.transform.Translate(-translation, 0, 0);
        }

        // 检查滑块是否到达范围边界
        if (slider.transform.position.x > originalX + range || slider.transform.position.x < originalX - range)
        {
            movingRight = !movingRight; // 改变方向
        }
        }
    }
}
