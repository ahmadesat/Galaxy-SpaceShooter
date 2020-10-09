using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    //For movement
    [SerializeField] public float speed = 6.5f;

    //For Health
    [SerializeField] private int hearts = 3;
    [SerializeField] private GameObject _playerExplosionPrefab;
    [SerializeField] private GameObject[] damagedWings;

    //For shooting
    [SerializeField] private GameObject _laserPrefab;
    [SerializeField] private float _fireRate = 0.3f;
    private float _canFireAfter = 0.0f;

    //For UI Updates
    private UIManager _uiManager;
    private GameManager _gameManager;
    private SpawnManager _spawnManager;

    //For power-ups
    [SerializeField] private GameObject _tripleShotPrefab;
    public bool tripleShot = false;
    [SerializeField] private GameObject _shieldGameObject;
    public bool shield = false;

    //For Sound
    [SerializeField] private AudioClip _explosionClip;


    // Start is called before the first frame update
    void Start()
    {

        //Find the Canvas's UIManager script
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if(_uiManager != null)
        {
            _uiManager.UpdateLives(hearts);
        }

        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        if(_spawnManager != null)
        {
            _spawnManager.StartRoutines();
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        if(Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            gameObject.GetComponent<AudioSource>().Play();
            Shooting();
        }
    }

    private void PlayerMovement()
    {
        //Movement
        transform.Translate(Vector3.up * Time.deltaTime * speed * Input.GetAxis("Vertical"));
        transform.Translate(Vector3.right * Time.deltaTime * speed * Input.GetAxis("Horizontal"));

        //Move the shield with the Player's movement
        _shieldGameObject.transform.position = transform.position;

        //for boundaries
        if(transform.position.y > 4.2f)
        {
            transform.position = new Vector3(transform.position.x, 4.2f, 0);
        }
        else if(transform.position.y < -4.2f)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }
        if(transform.position.x > 8.2f)
        {
            transform.position = new Vector3(8.2f, transform.position.y, 0);
        }
        else if(transform.position.x < -8.2f)
        {
            transform.position = new Vector3(-8.2f, transform.position.y, 0);

        }
    }

    public void Damage()
    {
        if(shield == true)
        {
            shield = false;
            _shieldGameObject.SetActive(false);

        }

        else
        {
            hearts -= 1;
            _uiManager.UpdateLives(hearts);
            if(hearts == 2)
            {
                damagedWings[0].SetActive(true);
            }
            if(hearts ==1)
            {
                damagedWings[1].SetActive(true);
            }

            if(hearts == 0)
            {
                Instantiate(_playerExplosionPrefab, transform.position, Quaternion.identity);
                _gameManager.gameOver = true;
                AudioSource.PlayClipAtPoint(_explosionClip, Camera.main.transform.position);
                _uiManager.ShowTitleScreen();
                GameObject.Destroy(this.gameObject);
            }
        }


    }

    private void Shooting()
    {
        //shoot lasers when space/leftclick is clicked

        if(Time.time > _canFireAfter)
        {
            if(tripleShot == true)
            {
                Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
            }

            else
            {
                Instantiate(_laserPrefab, transform.position + new Vector3(0, 1.1f, 0), Quaternion.identity);
            }
            _canFireAfter = Time.time + _fireRate;
        }


    }





    public void TripleShotPowerUp()
    {
        tripleShot = true;
        StartCoroutine("TripleShotPowerDown");
    }
    public void SpeedUp()
    {
        speed = 10f;
        StartCoroutine("SpeedPowerDown");
    }

    public void ShieldsUp()
    {
        shield = true;
        _shieldGameObject.SetActive(true);
    }


    IEnumerator TripleShotPowerDown()
    {
        yield return new WaitForSeconds(10f);
        //any code below will be exectued after the waited time
        tripleShot = false;
    }

    IEnumerator SpeedPowerDown()
    {
        yield return new WaitForSeconds(10f);
        //any code below will be exectued after the waited time
        speed = 6f;
    }


}
