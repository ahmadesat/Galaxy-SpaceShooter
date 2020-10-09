using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    //Things it will spawn
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject[] _powerUps;

    //For pausing the spawn
    private GameManager _gameManager;


    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
   
    }

    //You won't need an Update method for this


    public void StartRoutines()
    {
        StartCoroutine(EnemySpawn());
        StartCoroutine(PowerUpSpawn());
    }

    IEnumerator EnemySpawn()
    {
        while(_gameManager.gameOver == false)
        {
            yield return new WaitForSeconds(2f);
            float randX1 = Random.Range(-8f, 8f);
            Instantiate(_enemyPrefab, new Vector3(randX1, 7.5f, 0), Quaternion.identity);
            float randX2 = Random.Range(-8f, 8f);
        }

    }

    IEnumerator PowerUpSpawn()
    {
        while(_gameManager.gameOver == false)
        {
            yield return new WaitForSeconds(7f);
            float randX = Random.Range(-8f, 8f);
            int randPowerUp = Random.Range(0, 3);
            Instantiate(_powerUps[randPowerUp], new Vector3(randX, 8f, 0), Quaternion.identity);
        }

    }
}
