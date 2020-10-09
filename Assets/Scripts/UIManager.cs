using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField] public Sprite[] lives;
    [SerializeField] private Image lives_image;

    private int score;
    [SerializeField] public Text score_text;

    [SerializeField] public GameObject title_image;

    //A method for updating the lives UI
    public void UpdateLives(int currentLives)
    {
        lives_image.sprite = lives[currentLives];
    }

    public void UpdateScore()
    {
        score += 10;
        score_text.text = "Score: " + score;
    }

    public void ShowTitleScreen()
    {
        title_image.SetActive(true);
    }

    public void HideTitleScreen()
    {
        score = 0;
        score_text.text = "Score: " + score;
        title_image.SetActive(false);
    }
}
