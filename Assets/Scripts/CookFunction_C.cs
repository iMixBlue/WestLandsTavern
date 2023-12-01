using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CookFunction_C : MonoBehaviour
{
    public UIManager uIManager;
    public Camera mainCamera;
    public GameObject Level3;
    public GameObject scanner;
    public float _scannerSpeed = 1.5f;
    public float checkRange = 0.1f;
    public Transform[] A_KnifePosition;
    public Transform[] B_KnifePosition;
    public float fullScore = 150f;
    public float failScore = -50f;
    private bool stopLoopBool = false;
    public bool setScoreBool = false;
    float scannerX;
    private bool allow_A_0To1 = true;
    private bool allow_A_1To2 = false;
    private bool allow_A_2To3 = false;
    private bool allow_A_3To4 = false;

    private bool allow_B_0To1 = false;
    private bool allow_B_1To2 = false;
    private bool allow_B_2To3 = false;
    private bool allow_B_3To4 = false;


    // Start is called before the first frame update
    void Start()
    {
        // A_KnifePosition = new Transform[5];
        // B_KnifePosition = new Transform[5];
        scanner.transform.position = A_KnifePosition[0].position;
        Level3.SetActive(true);
        setScoreBool = false;
        stopLoopBool = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (!stopLoopBool)
        {
            scannerX = scanner.transform.position.x;
            if (scanner != null)
            {
                CheckSliderPosition();
                float translation = _scannerSpeed * Time.deltaTime;
                if (scanner.transform.position.x < A_KnifePosition[1].position.x && allow_A_0To1)
                {
                    scanner.transform.Translate(translation, 0, 0);
                }

                if (scanner.transform.position.x < A_KnifePosition[2].position.x && allow_A_1To2)
                {
                    scanner.transform.Translate(translation, 0, 0);
                }
                if (scanner.transform.position.x < A_KnifePosition[3].position.x && allow_A_2To3)
                {
                    scanner.transform.Translate(translation, 0, 0);
                }

                if (scanner.transform.position.x < A_KnifePosition[4].position.x && allow_A_3To4)
                {
                    scanner.transform.Translate(translation, 0, 0);
                }
            }
        }
        else
        {
            Level3.SetActive(false);
        }
    }


    void CheckSliderPosition()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Debug.Log(1);
            if (allow_A_0To1 && scanner.transform.position.x < A_KnifePosition[1].position.x + checkRange && scanner.transform.position.x > A_KnifePosition[1].position.x - checkRange)
            {
                allow_A_0To1 = false;
                allow_A_1To2 = true;
                SetScore(fullScore);

            }
            if (allow_A_1To2 && scanner.transform.position.x < A_KnifePosition[2].position.x + checkRange && scanner.transform.position.x > A_KnifePosition[2].position.x - checkRange)
            {
                allow_A_1To2 = false;
                allow_A_2To3 = true;
                SetScore(fullScore);

            }
            if (allow_A_2To3 && scanner.transform.position.x < A_KnifePosition[3].position.x + checkRange && scanner.transform.position.x > A_KnifePosition[3].position.x - checkRange)
            {
                allow_A_2To3 = false;
                allow_A_3To4 = true;
                SetScore(fullScore);

            }
            if (allow_A_0To1 && scanner.transform.position.x < A_KnifePosition[4].position.x + checkRange && scanner.transform.position.x > A_KnifePosition[4].position.x - checkRange)
            {
                allow_A_3To4 = false;
                SetScore(fullScore);

            }

        }

    }
    void SetScore(float score)
    {
        uIManager.addScore(score);
        // Debug.Log("AddScore_low executed");
    }

}
