using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //private AudioSource gameAudio;

    public GameObject mainScreen;
    public GameObject selectionScreen;

    public Button startButton;
    public Button settingsButton;
    public Button exitButton;
    public Button backButton;
    public Button nextButton;
    public Button comingSoonButton;
    public Button personalButton;
    public Button game1;
    public Button game2;
    public Button game3;
    public Button game4;
    public Button game5;
    public Button game6;
    public Button game7;
    public Button game8;
    public Button game9;

    //public AudioClip menuSfx;

    public bool mainMenu = false;
    public bool selectionMenu = false;

    // Start is called before the first frame update
    void Start()
    {
        LoadUI();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (mainMenu == true)
        {
            mainScreen.SetActive(true);
        }
        if (mainMenu == false)
        {
            mainScreen.SetActive(false);
        }
        if (selectionMenu == true)
        {
            selectionScreen.SetActive(true);
        }
        if (selectionMenu == false)
        {
            selectionScreen.SetActive(false);
        }
    }

    public void LoadUI()
    {
        mainMenu = true;
        selectionMenu = false;

        startButton.onClick.AddListener(SelectionMenu);
        settingsButton.onClick.AddListener(ComingSoon);
        personalButton.onClick.AddListener(ComingSoon);
        exitButton.onClick.AddListener(QuitGame);
    }

    public void SelectionMenu()
    {
        //gameAudio.PlayOneShot(menuSfx);
        mainMenu = false;
        selectionMenu = true;

        game1.onClick.AddListener(Game1);
        game2.onClick.AddListener(Game2);
        game3.onClick.AddListener(Game3);

        game4.onClick.AddListener(Game4);
        game5.onClick.AddListener(Game5);
        game6.onClick.AddListener(Game6);

        game7.onClick.AddListener(Game7);
        game8.onClick.AddListener(Game8);
        game9.onClick.AddListener(Game9);

        backButton.onClick.AddListener(LoadUI);
        nextButton.onClick.AddListener(ComingSoon);
    }

    public void Game1()
    {
        SceneManager.LoadScene("Project6", LoadSceneMode.Single);
    }
    public void Game2()
    {
        SceneManager.LoadScene("Project7", LoadSceneMode.Single);
    }
    public void Game3()
    {
        SceneManager.LoadScene("Project8", LoadSceneMode.Single);
    }
    public void Game4()
    {
        SceneManager.LoadScene("Project10", LoadSceneMode.Single);
    }
    public void Game5()
    {
        SceneManager.LoadScene("Project11", LoadSceneMode.Single);
    }
    public void Game6()
    {
        SceneManager.LoadScene("Project12", LoadSceneMode.Single);
    }
    public void Game7()
    {
        SceneManager.LoadScene("Project13", LoadSceneMode.Single);
    }
    public void Game8()
    {
        SceneManager.LoadScene("Project14", LoadSceneMode.Single);
    }
    public void Game9()
    {
        SceneManager.LoadScene("Project15", LoadSceneMode.Single);
    }
    
    public void ComingSoon()
    {
        comingSoonButton.gameObject.SetActive(true);
        comingSoonButton.onClick.AddListener(NotComingSoon);
    }
    public void NotComingSoon()
    {
        comingSoonButton.gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        //gameAudio.PlayOneShot(menuSfx);
        Application.Quit();
    }
}
