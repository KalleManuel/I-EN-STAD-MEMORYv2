using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider musicSlider;
    public Slider SFXSlider;
    public GameObject music;
    public GameObject gameCon;
    public AudioSource SFXController;
    public AudioSource musicController;
    public GameController SFX;


    // Start is called before the first frame update
    void Start()
    {
        gameCon = GameObject.FindGameObjectWithTag("GameControl");
        SFXController = gameCon.GetComponent<AudioSource>();
        SFX.GetComponent<GameController>();

        musicController = music.GetComponent<AudioSource>();

        musicSlider.value = 0.484f;




    }

    // Update is called once per frame
    void Update()
    {
        SFXController.volume = SFXSlider.value;
        musicController.volume = musicSlider.value;
        SFX.SfxVolume = SFXSlider.value; 
    }
}
