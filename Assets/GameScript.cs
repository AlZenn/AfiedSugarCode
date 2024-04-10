using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{
    //sayaç ve texti
    private Slider __timeSlider;
    private Text __timeSliderText;



    private Button _restartButton;
    private Button _quitButton;
    private Button _PAUSEOPENER;


    private Text QuestionT;
    private Text scoreText;
    private Text maxScoreText;

    public GameObject pauseScreen;
    private Text maxScoreText1;
    private Button _restartButton1;
    private Button _resumeButton1;
    private Button _quitButton1;

    public GameObject gameOverScreen;
    

    public int scorePoint = 0;
    public int maxScorePointInt;
    
    
    
    private Text Answer1T;
    private Text Answer2T;
    private Text Answer3T;
    
    private Button Answer1;
    private Button Answer2;
    private Button Answer3;
    
    private int maxNum = 1000;
    private int minNum = 1;

    private int randomNumber1;
    private int randomNumber2;

    private int correctNumber;
    private int[] wrongNumbers = new int[2];

    private void Awake()
    {
        gameOverScreen = GameObject.Find("GameOver");
        pauseScreen = GameObject.Find("PauseScreen");
    }

    void Start()
    {
        QuestionT = GameObject.Find("QuestionText").GetComponent<Text>();
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        maxScoreText = GameObject.Find("MaxScoreTextOn").GetComponent<Text>();
        maxScoreText1 = GameObject.Find("MaxScoreTextOn1").GetComponent<Text>();

        Answer1T = GameObject.Find("a1").GetComponent<Text>();
        Answer2T = GameObject.Find("a2").GetComponent<Text>();
        Answer3T = GameObject.Find("a3").GetComponent<Text>();
        Answer1 = GameObject.Find("Answer1B").GetComponent<Button>();
        Answer2 = GameObject.Find("Answer2B").GetComponent<Button>();
        Answer3 = GameObject.Find("Answer3B").GetComponent<Button>();
        _restartButton = GameObject.Find("RestartButton").GetComponent<Button>();
        _restartButton1 = GameObject.Find("RestartButton1").GetComponent<Button>();
        _quitButton = GameObject.Find("QuitButton").GetComponent<Button>();
        _quitButton1 = GameObject.Find("QuitButton1").GetComponent<Button>();
        _resumeButton1 = GameObject.Find("ResumeButton1").GetComponent<Button>();
        _PAUSEOPENER = GameObject.Find("PauseButtonB").GetComponent<Button>();

        //sayaç ve zaman
        __timeSlider= GameObject.Find("Slider").GetComponent<Slider>();
        __timeSliderText = GameObject.Find("TimeText").GetComponent<Text>();

        __timeSlider.value = 15f;
        __timeSlider.maxValue = 15f;
        __timeSlider.minValue = 0f;


        gameOverScreen.SetActive(false);
        pauseScreen.SetActive(false);
        scoreText.text = "Score: " + scorePoint.ToString();

        _restartButton.onClick.AddListener(_restartAsko);
        _quitButton.onClick.AddListener(_quitAsko);
        _PAUSEOPENER.onClick.AddListener(_pauseScreen);

        newNumber();
    }

    void newNumber()
    {
        randomNumber1 = UnityEngine.Random.Range(minNum,maxNum);
        randomNumber2 = UnityEngine.Random.Range(minNum,maxNum);
        
        Calculator(randomNumber1, randomNumber2);
    }
    
    void Calculator(int a, int b)
    {
        QuestionT.text = a.ToString() + " + " + b.ToString() + " = ?";
        correctNumber = a + b;
        wrongNumbers[0] = correctNumber + UnityEngine.Random.Range(1,10);
        wrongNumbers[1] = correctNumber - UnityEngine.Random.Range(1,10);

        RandomAnswerCheck();
    }
    
    void RandomAnswerCheck()
    {
        int random1 = UnityEngine.Random.Range(1, 4);

        if (random1 == 1)
        {
            Answer1T.text = correctNumber.ToString();
            Answer2T.text = wrongNumbers[0].ToString();
            Answer3T.text = wrongNumbers[1].ToString();
            
            Answer1.onClick.AddListener(correctButton);
            Answer2.onClick.AddListener(wrongButton);
            Answer3.onClick.AddListener(wrongButton);


        }else if (random1 == 2)
        {
            Answer2T.text = correctNumber.ToString();
            Answer1T.text = wrongNumbers[0].ToString();
            Answer3T.text = wrongNumbers[1].ToString();
            
            Answer2.onClick.AddListener(correctButton);
            Answer1.onClick.AddListener(wrongButton);
            Answer3.onClick.AddListener(wrongButton);


        }
        else if (random1 == 3)
        {
            Answer3T.text = correctNumber.ToString();
            Answer2T.text = wrongNumbers[0].ToString();
            Answer1T.text = wrongNumbers[1].ToString();
            
            Answer3.onClick.AddListener(correctButton);
            Answer2.onClick.AddListener(wrongButton);
            Answer1.onClick.AddListener(wrongButton);

        }
        
    }


    void correctButton()
    {
        scorePoint = scorePoint + 1;
        scoreText.text = "Score: " + scorePoint.ToString();

        // þu kodu öðrenene kadar canýn çýktý ezberle 
        Answer1.onClick.RemoveAllListeners();
        Answer2.onClick.RemoveAllListeners();
        Answer3.onClick.RemoveAllListeners();
        __timeSlider.value = 15f;

        newNumber();
    }
    void wrongButton()
    {
        maxScorePointInt = scorePoint;
        maxScoreText.text = "Max Score: " + maxScorePointInt.ToString();
        gameOverScreen.SetActive(true);
    }

    private void Update()
    {
        if (__timeSlider.value <= 0f)
        {
            wrongButton();
        }
        __timeSliderText.text = "Time: "+ __timeSlider.value.ToString("F0");

        __timeSlider.value -= Time.deltaTime;
    }

    private void _restartAsko()
    {
        SceneManager.LoadScene("Game");
        Debug.Log("resledim aþko");
    }
    private void _quitAsko()
    {
        Application.Quit();
        Debug.Log("çýktým aþko");
    }

    void _pauseScreen()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0f;
        maxScoreText1.text = "Max Score: " + scorePoint.ToString();
        _resumeButton1.onClick.AddListener(goGame);
        _restartButton1.onClick.AddListener(_restartAsko);
        _quitButton1.onClick.AddListener(_quitAsko);
    }
    void goGame()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1f;
    }


}
