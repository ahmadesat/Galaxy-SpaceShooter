using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //move left
        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            _anim.SetBool("MoveLeft", true);
            _anim.SetBool("MoveRight", false);

        }
        else if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
        {
            _anim.SetBool("MoveLeft", false);
            _anim.SetBool("MoveRight", false);

        }

        //move right
        if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            _anim.SetBool("MoveRight", true);
            _anim.SetBool("MoveLeft", false);

        }
        else if(Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
        {
            _anim.SetBool("MoveRight", false);
            _anim.SetBool("MoveLeft", false);

        }
    }
}
