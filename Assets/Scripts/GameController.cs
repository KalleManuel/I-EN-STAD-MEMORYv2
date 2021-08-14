using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;


public class GameController : MonoBehaviour {

    // Game controll variables

    [Header("Memory Game Settings")]
    [SerializeField]
    private Sprite bgImage;

    public Sprite[] puzzles;

    public List<Sprite> gamePuzzles = new List<Sprite>();

    public List<Button> btns = new List<Button>();

    private bool firstGuess, secondGuess;

    private int countGuesses;
    private int countCorrectGuesses;
    private int gameGuesses;

    private int firstGuessIndex, secondGuessIndex;

    private string firstGuessPuzzle, secondGuessPuzzle;

    public bool firstCard;
    public bool secondCard;
    public int openedCards;


    // shuffle cards

    public Sprite tempGO;



      [Header("Player settings")]

    public GameObject playersChoices;

    public JoinedPlayers myChoice;


    [Header("Score Display")]

    public Text Player1Score;
    public Text Player2Score;
    
    public int score1 = 0;
    public int score2 = 0;

    public GameObject timerDisplay;
    public GameObject timer;
    public GameObject playerTwoDisplay;



    [Header("Player Turns")]
    public int whosTurn = 1;

   

    public int guesses = 0;


    public Color activeColor;

    public Color white;

    public int activeSize;
    public int inactiveSize;

    public GameObject pipBackground;
    public GameObject borgisBackground;
    public Sprite greenBack;
    public Sprite redBack;



    

    [Header("Menu")]

    public GameObject menuPlate;
    public GameObject sliderBack;

    [Header("Flip cards")]

    public float waitSeconds = 0.0001f;
    public int flipTimer;
    public int rotationSpeed = 5;

    [Header("End and score")]

    
    public GameObject gameoverplate;
    public Text endMessage;
    public Text endmessage2;
    public TMP_Text pepTalk;

    [Header("Audio")]


    public AudioSource music;
    public VoiceAndSFX sfx;

    void Awake()
    {

        puzzles = Resources.LoadAll<Sprite>("Sprites/CARDSV2");

    }
    
    void Start()
    {

        ShuffleDeck();
        GetButtons();
        AddGamePuzzles();
        Addlisteners();
        Shuffle(gamePuzzles);
        gameGuesses = gamePuzzles.Count / 2;
        gameoverplate.SetActive(false);
        firstCard = false;
        secondCard = false;
        menuPlate.SetActive(false);
       

        // get and display player choices

        GameObject musicController = GameObject.FindGameObjectWithTag("Music");
        music = musicController.GetComponent<AudioSource>();

        playersChoices = GameObject.FindGameObjectWithTag("PlayersChoice");
        myChoice = playersChoices.GetComponent<JoinedPlayers>();

        GameObject sfxCon = GameObject.FindGameObjectWithTag("SFX");
        sfx = sfxCon.GetComponent<VoiceAndSFX>();

        sfx.sfxPlayer.PlayOneShot(sfx.SFX[5],sfx.SfxVolume);

        pipBackground.GetComponent<Image>().sprite = greenBack;
        borgisBackground.GetComponent<Image>().sprite = redBack;

        openedCards = 0;

        if (myChoice.myPlayerMode == JoinedPlayers.PlayerMode.ONEPLAYER)
        {
            playerTwoDisplay.SetActive(false);
            timerDisplay.SetActive(true);
            pipBackground.GetComponent<Image>().sprite = greenBack;
            borgisBackground.GetComponent<Image>().sprite = greenBack;

            if (myChoice.myHelpers == JoinedPlayers.Helpers.MAYOR)
            {
               sfx.negative = sfx.sadMayor;
                sfx.positive = sfx.happyMayor;
            }

            else if (myChoice.myHelpers == JoinedPlayers.Helpers.PIP)
            {
                sfx.positive = sfx.happyPip;
                sfx.negative = sfx.sadPip;
            }
        }

        else if (myChoice.myPlayerMode == JoinedPlayers.PlayerMode.TWOPLAYERS)
        {
            playerTwoDisplay.SetActive(true);
            timerDisplay.SetActive(false);
            pipBackground.GetComponent<Image>().sprite = greenBack;
            borgisBackground.GetComponent<Image>().sprite = redBack;

        }

       

        // get player scoreboards

        Player1Score.text = "" + score1;
        Player2Score.text = "" + score2;


        
    }

    private void Update()
    {


        //Player Indicator
        if (myChoice.myPlayerMode == JoinedPlayers.PlayerMode.ONEPLAYER)
        {
            Player1Score.text = "" + guesses;

        }

        else if (myChoice.myPlayerMode == JoinedPlayers.PlayerMode.TWOPLAYERS)
        {
            Player1Score.text = "" + score1;
            Player2Score.text = "" + score2;

            if (whosTurn == 1)
            {
                pipBackground.GetComponent<Image>().sprite = greenBack;
                borgisBackground.GetComponent<Image>().sprite = redBack;

                Player1Score.color = activeColor;
                Player2Score.color = white;
                if (Player1Score.fontSize < 65)
                {
                    Player1Score.fontSize++;
                }

                if (Player2Score.fontSize > 35)
                {
                    Player2Score.fontSize--;
                }

                sfx.negative = sfx.sadPip;
                sfx.positive = sfx.happyPip;


            }


            else if (whosTurn == 2)
            {
                pipBackground.GetComponent<Image>().sprite = redBack;
                borgisBackground.GetComponent<Image>().sprite = greenBack;

                Player1Score.color = white;
                Player2Score.color = activeColor;

                if (Player1Score.fontSize > 35)
                {
                    Player1Score.fontSize--;
                }

                if (Player2Score.fontSize < 60)
                {
                    Player2Score.fontSize++;
                }

                sfx.negative = sfx.sadMayor;
                sfx.positive = sfx.happyMayor;

            }

        }

    }

    

    void GetButtons()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleButton");
        for (int i = 0; i < objects.Length; i++) {
            btns.Add(objects[i].GetComponent<Button>());
            btns[i].image.sprite = bgImage;
        }

    }
    void AddGamePuzzles()
    {
        int looper = btns.Count;
        int index = 0;
        for (int i = 0; i < looper; i++)
        {
            if (index == looper / 2)
            {
                index = 0;
            }


            gamePuzzles.Add(puzzles[index]);
            index++;

        }
    }

        void Addlisteners()
        {
            foreach (Button btn in btns)
            {
                btn.onClick.AddListener(() => PickAPuzzle());
           
            }
        }

        public void PickAPuzzle()
        {
            string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
           

        if (!firstGuess)
        {
            
            

            firstGuess = true;
            firstCard = true;
            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            firstGuessPuzzle = gamePuzzles[firstGuessIndex].name;
        

            // Flip Card

            StartFlip();
           

        } else if (!secondGuess) {

            
            
            secondGuess = true;
            secondCard = true;
            secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            secondGuessPuzzle = gamePuzzles[secondGuessIndex].name;

            StartFlip();
           
          }
        }


    public void StartFlip()
    {
          StartCoroutine(FlipCards());

    }

    IEnumerator FlipCards()
    {
        if (firstCard)
        {
            for (int i = 0; i < 10; i++)
            {
                yield return new WaitForSeconds(waitSeconds);

                btns[firstGuessIndex].transform.Rotate(0, 18, 0);


                flipTimer += 18;

                if (flipTimer == 90 || flipTimer == -90)
                {
                    
                    Flip();
                }
            }
            flipTimer = 0;
        }

        else if (secondCard)
        {
            for (int i = 0; i < 10; i++)
            {
                yield return new WaitForSeconds(waitSeconds);

                btns[secondGuessIndex].transform.Rotate(0, 18, 0);


                flipTimer += 18;

                if (flipTimer == 90 || flipTimer == -90)
                {
                   
                    Flip();
                }
            }
            flipTimer = 0;
        }

    }

    public void Flip()
    {
        if (firstCard)
        {
            btns[firstGuessIndex].image.sprite = gamePuzzles[firstGuessIndex];
            btns[firstGuessIndex].interactable = false;
            firstCard = false;
            sfx.sfxPlayer.PlayOneShot(sfx.SFX[3], sfx.SfxVolume);
        }

        else if (secondCard)
        {
            btns[secondGuessIndex].image.sprite = gamePuzzles[secondGuessIndex];
            countGuesses++;
            sfx.sfxPlayer.PlayOneShot(sfx.SFX[3], sfx.SfxVolume);
            guesses++;
            secondCard = false;
            StartCoroutine(CheckIfThePuzzlesMatch());
        }
    }
    void ChangePlayer()
    {
        whosTurn++;

            if (whosTurn > 2)
        {
            whosTurn = 1;

        }
    }

    void Givescore()
    {
        if (whosTurn == 1)
        {
            score1++;
        }

        else if (whosTurn == 2)
        {
            score2++;
        }

    }

    IEnumerator CheckIfThePuzzlesMatch ()
    {
        yield return new WaitForSeconds (.5f);

        if (firstGuessPuzzle == secondGuessPuzzle) {

            openedCards += 2;

            if (openedCards == gamePuzzles.Count)
            {
                Timer endTime = timer.GetComponent<Timer>();
                endTime.counting = false;
            }

            sfx.sfxPlayer.PlayOneShot(sfx.positive[Random.Range(0, sfx.positive.Length)], sfx.SfxVolume);

            sfx.sfxPlayer.PlayOneShot(sfx.SFX[1], sfx.SfxVolume);
            Givescore();
           
            

            btns[firstGuessIndex].interactable = false;
            btns[secondGuessIndex].interactable = false;

            btns[firstGuessIndex].image.color = new Color (217, 150, 204, 60);
      

            CheckIfGameIsFinished();
        }

        else { 
            
            yield return new WaitForSeconds(.3f);
            
         
            sfx.sfxPlayer.PlayOneShot(sfx.negative[Random.Range(0, sfx.negative.Length)], sfx.SfxVolume);

            StartCoroutine(FlipCardsback());

        }

        yield return new WaitForSeconds(.5f); 
        firstGuess = secondGuess = false;
        


    }

    IEnumerator FlipCardsback()
    {
        
            for (int i = 0; i < 10; i++)
            {
                yield return new WaitForSeconds(waitSeconds);

                btns[firstGuessIndex].transform.Rotate(0, -18, 0);
                btns[secondGuessIndex].transform.Rotate(0, -18, 0);


            flipTimer += 18;

                if (flipTimer == 90 || flipTimer == -90)
                {
                btns[firstGuessIndex].image.sprite = bgImage;
                btns[secondGuessIndex].image.sprite = bgImage;
                sfx.sfxPlayer.PlayOneShot(sfx.SFX[4], sfx.SfxVolume);
            }
            }
        btns[firstGuessIndex].interactable = true;
        
        ChangePlayer();
        flipTimer = 0;
        
    }


        void CheckIfGameIsFinished() { 
        countCorrectGuesses++;
      
        if (countCorrectGuesses == gameGuesses) {

            
            sfx.sfxPlayer.PlayOneShot(sfx.SFX[2], sfx.SfxVolume);
            

            DisplayEnd();
        }

    }

    // shuffles cards on table

  void Shuffle(List<Sprite> list)
    {
      for(int i = 0; i < list.Count; i++)
      {
           Sprite temp = list[i];
           int randomIndex = Random.Range(i, list.Count);
           list[i] = list[randomIndex];
           list[randomIndex] = temp;
       }
  }

    // Shuffles cards in pile

    public void ShuffleDeck()
    {
        for (int i = 0; i < puzzles.Length; i++)
        {
            int rnd = Random.Range(0, puzzles.Length);
            tempGO = puzzles[rnd];
            puzzles[rnd] = puzzles[i];
            puzzles[i] = tempGO;
        }
    }

    public void OpenMeny()
    {
        

       if (myChoice.myPlayerMode == JoinedPlayers.PlayerMode.ONEPLAYER)
        {
            Timer timercounting = timer.GetComponent<Timer>();

            timercounting.counting = false;
            menuPlate.SetActive(true);
            sliderBack.SetActive(false);
        }

        else if (myChoice.myPlayerMode == JoinedPlayers.PlayerMode.TWOPLAYERS)
        {
            menuPlate.SetActive(true);
            sliderBack.SetActive(false);
        }

    }

    public void CloseMenu()
    {
        if (myChoice.myPlayerMode == JoinedPlayers.PlayerMode.ONEPLAYER)
        {
            Timer timercounting = timer.GetComponent<Timer>();

            timercounting.counting = true;
            sliderBack.SetActive(true);
            menuPlate.SetActive(false);
        }

        else if (myChoice.myPlayerMode == JoinedPlayers.PlayerMode.TWOPLAYERS)
        {
            menuPlate.SetActive(false);
        }
    }

    public void DisplayEnd()
    {
        music.Stop();

        gameoverplate.SetActive(true);

        if (myChoice.myPlayerMode == JoinedPlayers.PlayerMode.ONEPLAYER)
        {
            Timer endTime = timer.GetComponent<Timer>();

            pepTalk.text = "Bra hittat!";
            endMessage.text = "Tid: " + endTime.timer.text;
            endmessage2.text = "Försök: " + guesses;

            if (myChoice.myHelpers == JoinedPlayers.Helpers.PIP)
            {
                if (endTime.timerValue < 10)
                {
                    sfx.sfxPlayer.PlayOneShot(sfx.endTalk[0], sfx.SfxVolume);
                }

                else if (endTime.timerValue < 20)
                {
                    sfx.sfxPlayer.PlayOneShot(sfx.endTalk[1], sfx.SfxVolume);
                }

                else if (endTime.timerValue < 30)
                {
                    sfx.sfxPlayer.PlayOneShot(sfx.endTalk[2], sfx.SfxVolume);
                }

                else if (endTime.timerValue < 60)
                {
                    sfx.sfxPlayer.PlayOneShot(sfx.endTalk[3], sfx.SfxVolume);
                }
                else if (endTime.timerValue < 90)
                {
                    sfx.sfxPlayer.PlayOneShot(sfx.endTalk[4], sfx.SfxVolume);
                }

                else if (endTime.timerValue < 120)
                {
                    sfx.sfxPlayer.PlayOneShot(sfx.endTalk[5], sfx.SfxVolume);
                }

                else if (endTime.timerValue < 300)
                {
                    sfx.sfxPlayer.PlayOneShot(sfx.endTalk[6], sfx.SfxVolume);
                }
            }

            else if (myChoice.myHelpers == JoinedPlayers.Helpers.MAYOR)
            {
                if (endTime.timerValue < 10)
                {
                    sfx.sfxPlayer.PlayOneShot(sfx.endTalk[7], sfx.SfxVolume);
                }

                else if (endTime.timerValue < 20)
                {
                    sfx.sfxPlayer.PlayOneShot(sfx.endTalk[8], sfx.SfxVolume);
                }

                else if (endTime.timerValue < 30)
                {
                    sfx.sfxPlayer.PlayOneShot(sfx.endTalk[9], sfx.SfxVolume);
                }

                else if (endTime.timerValue < 60)
                {
                    sfx.sfxPlayer.PlayOneShot(sfx.endTalk[10], sfx.SfxVolume);
                }
                else if (endTime.timerValue < 90)
                {
                    sfx.sfxPlayer.PlayOneShot(sfx.endTalk[11], sfx.SfxVolume);
                }

                else if (endTime.timerValue < 120)
                {
                    sfx.sfxPlayer.PlayOneShot(sfx.endTalk[12], sfx.SfxVolume);
                }

                else if (endTime.timerValue < 300)
                {
                    sfx.sfxPlayer.PlayOneShot(sfx.endTalk[13], sfx.SfxVolume);
                }
            }
        }

        else if (myChoice.myPlayerMode == JoinedPlayers.PlayerMode.TWOPLAYERS)
        {
            if (score1 > score2)
            {
                pepTalk.text = "Grattis Lag Pip!";
                sfx.sfxPlayer.PlayOneShot(sfx.endTalk[Random.Range(14,17)]);
            }


            else if (score2 > score1)
            {
                pepTalk.text = "Grattis Lag Borgmästaren!";
                sfx.sfxPlayer.PlayOneShot(sfx.endTalk[Random.Range(18, 19)]);
            }


            else if (score1 == score2)
            {
                pepTalk.text = "Lika! Grattis till er båda!";
            }

            endMessage.text = "Team Pip: " + score1;
            endmessage2.text = " Team Borgis: " + score2;
        }
    } 
 

 }