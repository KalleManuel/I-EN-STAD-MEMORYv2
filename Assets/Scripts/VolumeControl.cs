using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider musicSlider;
    public Slider SFXSlider;
    public GameObject music;
    public GameObject sfxCon;
    public AudioSource sfxPlayer;
    public AudioSource musicController;
    public VoiceAndSFX sfx;


    // Start is called before the first frame update
    void Start()
    {
      sfxCon = GameObject.FindGameObjectWithTag("SFX");
        sfxPlayer = sfxCon.GetComponent<AudioSource>();
       sfx = sfxCon.GetComponent<VoiceAndSFX>();

        music = GameObject.FindGameObjectWithTag("Music");

        musicController = music.GetComponent<AudioSource>();

        musicSlider.value = musicController.volume;
      SFXSlider.value = sfx.SfxVolume;

    }

    // Update is called once per frame
    void Update()
    {
        // 
      sfxPlayer.volume = SFXSlider.value;
        musicController.volume = musicSlider.value;
       sfx.SfxVolume = SFXSlider.value; 
    }

    public void CloseSetttings()
    {

        Destroy(this.gameObject);

    }
}
