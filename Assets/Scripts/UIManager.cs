using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject scoreText;
    public GameObject failCountText;
    public float totalScore = 0f;
    private Color defaultColor = Color.black;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addScore(float score, Color? color = null){
        totalScore += score;
        this.scoreText.GetComponent<TMP_Text>().text = "Score : " + totalScore;
        if(color == null){
            color = Color.black;
            this.scoreText.GetComponent<TMP_Text>().color = (Color)color;
        }
        else if(color != null){
            this.scoreText.GetComponent<TMP_Text>().color = (Color)color;
        }
    }
    public void SetFailCount(int count){
        this.failCountText.GetComponent<TMP_Text>().text = "FailCount : " + count;
    }
}
