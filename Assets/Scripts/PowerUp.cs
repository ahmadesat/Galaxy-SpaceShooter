using UnityEngine;

public class PowerUp : MonoBehaviour
{
    //For Movement
    [SerializeField] private float _speed = 3f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PowerUpMovement();
    }

    private void PowerUpMovement()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);

        //Destroy once it reaches the bottom
        if(transform.position.y < -6.5f)
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            //access the Player's Component
            Player player = collider.GetComponent<Player>();

            //always perform a null check when using GetComponent, to avoid game-breaking errors
            if(player != null)
            {
                if(this.tag == "Triple Shot")
                {
                    player.TripleShotPowerUp();
                }

                if(this.tag == "Speed Up")
                {
                    player.SpeedUp();
                }

                if(this.tag == "Shield")
                {
                    player.ShieldsUp();
                }



                GameObject.Destroy(this.gameObject);
            }


        }

    }
}
