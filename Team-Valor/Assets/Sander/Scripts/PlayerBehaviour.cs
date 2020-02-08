using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float speed;
    private Vector3 move;

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


    void FixedUpdate() //fixedupdate zodat de collisions goed werken
    {
        
        if (moveAllow == true)
        {
            move.x = Input.GetAxis("Horizontal");
            move.z = Input.GetAxis("Vertical");
            transform.position += move * Time.deltaTime * speed;

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

}
