using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float speed;
    private Vector3 move;
    public Health hpScript;
    public Animator pAnimator;
    private Vector3 animDirection;

    public bool moveAllow = true;

    private RaycastHit hit;
    public Camera cam;
    private Ray rayMouse;
    public float maximumLenght;
    public float outOfBoundsMaxLenght;
    private Vector3 direction;



    void Start()
    {
       
    }

    void Update()
    {
        if (hpScript.health <= 0)
        {
            print("lmao u ded");
        }

    }


    void FixedUpdate() //fixedupdate zodat de collisions goed werken
    {

        if (moveAllow == true)
        {
            move.x = Input.GetAxis("Horizontal");
            move.z = Input.GetAxis("Vertical");
            transform.position += move * Time.deltaTime * speed;
            //transform.Translate(move * Time.deltaTime * speed);
            Animating();

            rayMouse = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(rayMouse.origin, rayMouse.direction, out hit, maximumLenght))
            {
                RotateToMouseDirection(gameObject, hit.point); //gameObject is het object waar dit script op zit
            }
            else
            {
                RotateToMouseDirection(gameObject, rayMouse.GetPoint(outOfBoundsMaxLenght));
            }
        }
        

        
    }

    void RotateToMouseDirection (GameObject obj, Vector3 destination)
    {
        direction = destination - obj.transform.position;
        direction.y = 0;
        obj.transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
        
    }

    void Animating()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        animDirection = new Vector3(h, 0, v);

        if (animDirection.magnitude > 1.0f)
        {
            animDirection = animDirection.normalized;
        }

        animDirection = transform.TransformDirection(animDirection);

        pAnimator.SetFloat("moveForward", animDirection.z);
        pAnimator.SetFloat("moveSide", animDirection.x);
    }

}
