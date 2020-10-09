using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //move up when projected
        transform.Translate(Vector3.up * _speed * Time.deltaTime);

        //destroy laser once it is out of the screen
        if(transform.position.y > 5.5f)
        {
            Object.Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {

        if(collider.CompareTag("Enemy"))
        {
            GameObject.Destroy(collider.gameObject);
            GameObject.Destroy(this.gameObject);
        }
    }
}
