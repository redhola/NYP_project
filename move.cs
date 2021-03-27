using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{

    public float movementSpeed = 7;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        var movementX = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movementX,0,0) * Time.deltaTime * movementSpeed;
        var movementY = Input.GetAxis("Vertical");
        transform.position += new Vector3(0,movementY,0) * Time.deltaTime *movementSpeed;

        animator.SetFloat("SpeedX", Mathf.Abs(movementX));
        animator.SetFloat("SpeedY", Mathf.Abs(movementY));

        Vector3 characterFlip = transform.localScale;
        if( Input.GetAxis("Horizontal") < 0)
            characterFlip.x = -1;
        if( Input.GetAxis("Horizontal") > 0)
            characterFlip.x = 1;
        transform.localScale = characterFlip;
    }
}
