using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameOver = true;
    private UIManager _uiManager;

    [SerializeField] private Player _player;

    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.K))
        {
            ScreenCapture.CaptureScreenshot("Game");
        }


        if(gameOver == true)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(_player, Vector3.zero, Quaternion.identity);
                gameOver = false;
                if(_uiManager != null)
                {
                    _uiManager.HideTitleScreen();
                }
            }
        }
    }
}
