using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public Slider slider;
    // Start is called before the first frame update
   public void Volume(){
    backgroundMusic.volume = slider.value;
   }
   private void Start() {
    backgroundMusic.volume = 0.5f;
   }
}
