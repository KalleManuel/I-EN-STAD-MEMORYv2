using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneController : MonoBehaviour
{
    public GameObject settingPrefab;
    public VoiceAndSFX sfx;

    private void Start()
    {
        GameObject vas = GameObject.FindGameObjectWithTag("SFX");
        sfx = vas.GetComponent<VoiceAndSFX>();
    }

    // controll scenes

    public void StartFromStcratch()
    {
        StartCoroutine(WaitforSeconds(1f));
        sfx.scene = 2;
       
    }

    public void StartMenu()
    {
        GameObject joinedPlayers = GameObject.FindGameObjectWithTag("PlayersChoice");
        Destroy(joinedPlayers);

        GameObject musicController = GameObject.FindGameObjectWithTag("Music");
        MusicController music = musicController.GetComponent<MusicController>();
        music.gameOn = false;
        music.changeMusic = true;
        sfx.scene = 2;

        SceneManager.LoadScene(1);
        


    }

    public void Play()
        {
        GameObject musicController = GameObject.FindGameObjectWithTag("Music");
        MusicController music = musicController.GetComponent<MusicController>();
        music.gameOn = true;
        music.changeMusic = true;
        sfx.scene = 3;

        SceneManager.LoadScene(2);


        }

     public void PlayAgain()
        {

        GameObject musicController = GameObject.FindGameObjectWithTag("Music");
        MusicController music = musicController.GetComponent<MusicController>();
        music.gameOn = true;
        music.changeMusic = true;
        sfx.scene = 3;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

     public void doquit()
        {
        Application.Quit();

        }

    IEnumerator WaitforSeconds(float sec)
    {

        yield return new WaitForSeconds(sec);

        SceneManager.LoadScene(1);

    }

    public void OpenSettings()
    {

        GameObject volumeControll = Instantiate(settingPrefab, new Vector3(0, 0, 0), Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform);
    }


}
