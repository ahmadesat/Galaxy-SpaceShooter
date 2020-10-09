using UnityEngine;

public class Enemy : MonoBehaviour
{
    //For movement
    [SerializeField] private float _speed = 5f;

    //For animation
    [SerializeField] private GameObject _explosionPrefab;


    //For Sound
    [SerializeField] private AudioClip _explosionClip;

    //For UI Updates
    private UIManager _uiManager;

    // Start is called before the first frame update
    void Start()
    {
        //Find the Canvas's UIManager script
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();

    }

    private void EnemyMovement()
    {
        //Enemy movement
        transform.Translate(Vector3.down * Time.deltaTime * _speed);

        //re-spawn enemy on top if he reaches the bottom
        if(transform.position.y < -6.8f)
        {
            float randX = Random.Range(-8f, 8f);
            transform.position = new Vector3(randX, 8f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Laser"))
        {
            GameObject.Destroy(collider.gameObject);
            DestroyEnemy();
        }

        if(collider.CompareTag("Player"))
        {
            Player player = collider.GetComponent<Player>();
            if(player != null)
            {
                player.Damage();
            }

            DestroyEnemy();
        }
    }

    private void DestroyEnemy()
    {
        if(_uiManager != null)
        {
            _uiManager.UpdateScore();
        }
        AudioSource.PlayClipAtPoint(_explosionClip, transform.position);
        Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
        GameObject.Destroy(this.gameObject);

    }
}
