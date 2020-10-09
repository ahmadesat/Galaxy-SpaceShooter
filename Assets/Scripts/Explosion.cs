using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Destroy this Game Object after 3.5seconds
        GameObject.Destroy(this.gameObject, 3.5f);
    }
}
