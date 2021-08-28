using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneController : MonoBehaviour
{
    public GameObject settingPrefab;
    public VoiceAndSFX sfx;

    public string sceneName;
    static bool checkScene;

    private void Start()
    {
        GameObject vas = GameObject.FindGameObjectWithTag("SFX");
        sfx = vas.GetComponent<VoiceAndSFX>();

        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        if (sceneName == "StartMenu" && checkScene)
        {
            sfx.getComponents = 1;
            checkScene = false;
        }

        else if (sceneName == "Game" && checkScene)
        {
            sfx.getComponents = 2;
            checkScene = false;
        }
    }

  

    // controll scenes

    public void StartFromStcratch()
    {
        StartCoroutine(WaitforSeconds(1f));
        sfx.scene = 2;
        sfx.sfxPlayer.Stop();
        checkScene = true;
       
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
        checkScene = true;

        StopAllCoroutines();
        sfx.sfxPlayer.Stop();

        SceneManager.LoadScene(1);
        


    }

    public void Play()
        {
        GameObject musicController = GameObject.FindGameObjectWithTag("Music");
        MusicController music = musicController.GetComponent<MusicController>();
        music.gameOn = true;
        music.changeMusic = true;
        sfx.scene = 3;
        sfx.sfxPlayer.Stop();
        checkScene = true;

        SceneManager.LoadScene(2);


        }

     public void PlayAgain()
        {

        GameObject musicController = GameObject.FindGameObjectWithTag("Music");
        MusicController music = musicController.GetComponent<MusicController>();
        music.gameOn = true;
        music.changeMusic = true;
        sfx.scene = 3;
        sfx.sfxPlayer.Stop();

        StopAllCoroutines();

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
