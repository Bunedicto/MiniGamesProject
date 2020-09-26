using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P14DifficultyButton : MonoBehaviour
{
    public int difficulty;
    private Button button;
    private GameManager gameManager2;
    
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        gameManager2 = GameObject.Find("Game Manager").GetComponent<GameManager>();

        button.onClick.AddListener(SetDifficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetDifficulty()
    {
        Debug.Log(button.gameObject.name + " was clicked");
        //gameManager2.StartGame(difficulty);
    }
}
