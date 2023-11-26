using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CookFunction_B : MonoBehaviour
{
    public UIManager uIManager;
    public GameObject orangeSlider; // 橙色滑块
    public GameObject greenSlider;  // 绿色滑块
    public GameObject slider;       // 扫描线
    public float _sliderSpeed = 3.0f;
    public GameObject slider2;
    public float _slierSpeed2 = 1.5f;
    public GameObject backgroundSlider;
    public float _background_sliderSpeed;

    public GameObject leftRange;
    public GameObject rightRange;
    public float _originalX; // 初始X坐标
    public float range = 10.0f;
    // [SerializeField]
    private bool moveRight1 = true; // 判断滑块移动方向
    // [SerializeField]
    private bool moveRight2 = true;
    public float highScore = 150f;
    public float lowScore = 50f;


    // Start is called before the first frame update
    void Start()
    {
        //  _originalX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (slider != null && slider2 != null)
        {
            TranslateLeftandRight(slider, _sliderSpeed);
            // TranslateLeftandRight(slider2, _slierSpeed2, _originalX);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Debug.Log(1);
            CheckSliderPosition();
        }
    }
    public void TranslateLeftandRight(GameObject obj, float speed)
    {
        if (obj != null)
        {
            float translation = speed * Time.deltaTime;
            if (moveRight1)
            {
                obj.transform.Translate(translation, 0, 0);
            }
            else
            {
                obj.transform.Translate(-translation, 0, 0);
            }

            // 检查滑块是否到达范围边界
            if (obj.transform.localPosition.x < leftRange.transform.position.x || obj.transform.localPosition.x > rightRange.transform.position.x)
            {
                moveRight1 = !moveRight1; // 改变方向
            }

        }
    }
    public void TranslateLeftandRight(GameObject obj, float speed, float originPosition)
    {
        if (obj != null)
        {
            float translation = speed * Time.deltaTime;
            if (moveRight2)
            {
                obj.transform.Translate(translation, 0, 0);
            }
            else
            {
                obj.transform.Translate(-translation, 0, 0);
            }

            // 检查滑块是否到达范围边界
            if (obj.transform.position.x > originPosition + range || obj.transform.position.x < originPosition - range)
            {
                moveRight2 = !moveRight2; // 改变方向
            }

        }
    }
    void CheckSliderPosition()
{
    // 获取扫描线的X位置
    float scannerX = slider.transform.localPosition.x;

    // 获取橙色和绿色滑块的边界
    float orangeWidth = orangeSlider.transform.localScale.x * orangeSlider.GetComponent<BoxCollider>().size.x;
    float greenWidth = greenSlider.transform.localScale.x * 0.7f * greenSlider.GetComponent<BoxCollider>().size.x;

    float orangeMinX = orangeSlider.transform.position.x - (orangeWidth / 2);
    float orangeMaxX = orangeSlider.transform.position.x + (orangeWidth / 2);
    float greenMinX = greenSlider.transform.position.x - (greenWidth / 2);
    float greenMaxX = greenSlider.transform.position.x + (greenWidth / 2);

    // 调试信息
    // Debug.Log(orangeWidth);
    // Debug.Log(greenWidth);
    // Debug.Log($"Scanner X: {scannerX}, Orange Min: {orangeMinX}, Orange Max: {orangeMaxX}, Green Min: {greenMinX}, Green Max: {greenMaxX}");

    // 检查扫描线的位置
    if (scannerX >= greenMinX && scannerX <= greenMaxX)
    {
        // 扫描线位于绿色滑块内
        AddScore_High();
    }
    else if (scannerX >= orangeMinX && scannerX <= orangeMaxX)
    {
        // 扫描线位于橙色滑块内，但不在绿色滑块内
        AddScore_low();
    }
}

void AddScore_High()
{
    uIManager.addScore(highScore);
    // Debug.Log("AddScore_High executed");
}

void AddScore_low()
{
    uIManager.addScore(lowScore);
    // Debug.Log("AddScore_low executed");
}

}
