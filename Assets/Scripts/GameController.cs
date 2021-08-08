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

    // pips talk


    public AudioSource audioSource;

    public AudioClip[] happyMayor;

    public AudioClip[] sadMayor;

    public AudioClip[] happyPip;

    public AudioClip [] sadPip;

    public AudioClip[] positive;

    public AudioClip [] negative;

    public AudioClip[] SFX; // 1 get point, 2 sucess, 3 card up, 4 card down

    public AudioClip[] teamMayor;
    public AudioClip[] teamPip;


    public AudioClip[] endTalk;

    // Volumecontroll

    public float SfxVolume;

    public AudioSource music;



  

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
        SfxVolume = 0.5f;

        // get and display player choices

        pipBackground.GetComponent<Image>().sprite = greenBack;
        borgisBackground.GetComponent<Image>().sprite = redBack;

        playersChoices = GameObject.FindGameObjectWithTag("PlayersChoice");
        myChoice = playersChoices.GetComponent<JoinedPlayers>();

        if (myChoice.myPlayerMode == JoinedPlayers.PlayerMode.ONEPLAYER)
        {
            playerTwoDisplay.SetActive(false);
            timerDisplay.SetActive(true);
            pipBackground.GetComponent<Image>().sprite = greenBack;
            borgisBackground.GetComponent<Image>().sprite = greenBack;

            if (myChoice.myHelpers == JoinedPlayers.Helpers.MAYOR)
            {
                negative = sadMayor;
                positive = happyMayor;
            }

            else if (myChoice.myHelpers == JoinedPlayers.Helpers.PIP)
            {
                positive = happyPip;
                negative = sadPip;
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

                negative = sadPip;
                positive = happyPip;


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

                negative = sadMayor;
                positive = happyMayor;

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
            audioSource.PlayOneShot(SFX[3], SfxVolume);
        }

        else if (secondCard)
        {
            btns[secondGuessIndex].image.sprite = gamePuzzles[secondGuessIndex];
            countGuesses++;
            audioSource.PlayOneShot(SFX[3], SfxVolume);
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

          
            audioSource.PlayOneShot(positive[Random.Range(0, positive.Length)], SfxVolume);

            audioSource.PlayOneShot(SFX[1], SfxVolume);
            Givescore();
           
            yield return new WaitForSeconds(1.5f);

            btns[firstGuessIndex].interactable = false;
            btns[secondGuessIndex].interactable = false;

            btns[firstGuessIndex].image.color = new Color (217, 150, 204, 60);
            

            

            CheckIfGameIsFinished();
        }

        else { 

            yield return new WaitForSeconds(.5f);

            
            yield return new WaitForSeconds(.3f);
            
         
            audioSource.PlayOneShot(negative[Random.Range(0, negative.Length)], SfxVolume);

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
                audioSource.PlayOneShot(SFX[4], SfxVolume);
            }
            }
        btns[firstGuessIndex].interactable = true;
        
        ChangePlayer();
        flipTimer = 0;
        
    }


        void CheckIfGameIsFinished() { 
        countCorrectGuesses++;
      
        if (countCorrectGuesses == gameGuesses) {

            audioSource.PlayOneShot(SFX[2], SfxVolume);

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
        }

        else if (myChoice.myPlayerMode == JoinedPlayers.PlayerMode.TWOPLAYERS)
        {
            menuPlate.SetActive(true);
        }

    }

    public void CloseMenu()
    {
        if (myChoice.myPlayerMode == JoinedPlayers.PlayerMode.ONEPLAYER)
        {
            Timer timercounting = timer.GetComponent<Timer>();

            timercounting.counting = true;
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
                    audioSource.PlayOneShot(endTalk[0], SfxVolume);
                }

                else if (endTime.timerValue < 20)
                {
                    audioSource.PlayOneShot(endTalk[1], SfxVolume);
                }

                else if (endTime.timerValue < 30)
                {
                    audioSource.PlayOneShot(endTalk[2], SfxVolume);
                }

                else if (endTime.timerValue < 60)
                {
                    audioSource.PlayOneShot(endTalk[3], SfxVolume);
                }
                else if (endTime.timerValue < 90)
                {
                    audioSource.PlayOneShot(endTalk[4], SfxVolume);
                }

                else if (endTime.timerValue < 120)
                {
                    audioSource.PlayOneShot(endTalk[5], SfxVolume);
                }

                else if (endTime.timerValue < 300)
                {
                    audioSource.PlayOneShot(endTalk[6], SfxVolume);
                }
            }

            else if (myChoice.myHelpers == JoinedPlayers.Helpers.MAYOR)
            {
                if (endTime.timerValue < 10)
                {
                    audioSource.PlayOneShot(endTalk[7], SfxVolume);
                }

                else if (endTime.timerValue < 20)
                {
                    audioSource.PlayOneShot(endTalk[8], SfxVolume);
                }

                else if (endTime.timerValue < 30)
                {
                    audioSource.PlayOneShot(endTalk[9], SfxVolume);
                }

                else if (endTime.timerValue < 60)
                {
                    audioSource.PlayOneShot(endTalk[10], SfxVolume);
                }
                else if (endTime.timerValue < 90)
                {
                    audioSource.PlayOneShot(endTalk[11], SfxVolume);
                }

                else if (endTime.timerValue < 120)
                {
                    audioSource.PlayOneShot(endTalk[12], SfxVolume);
                }

                else if (endTime.timerValue < 300)
                {
                    audioSource.PlayOneShot(endTalk[13], SfxVolume);
                }
            }
        }

        else if (myChoice.myPlayerMode == JoinedPlayers.PlayerMode.TWOPLAYERS)
        {
            if (score1 > score2)
            {
                pepTalk.text = "Grattis Lag Pip!";
                audioSource.PlayOneShot(endTalk[Random.Range(14,17)]);
            }


            else if (score2 > score1)
            {
                pepTalk.text = "Grattis Lag Borgmästaren!";
                audioSource.PlayOneShot(endTalk[Random.Range(18, 19)]);
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