using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float speedRot;//the rotation of the chracter 

    private Rigidbody rigidBody;//the character 

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody>();//get the rb and save it
        mainCamera = FindObjectOfType<Camera>();
    }

    void update(){
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"),0f,Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * speedRot;

        Ray CameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane ground = new Plane(Vector3.up,Vector3.zero);
        float rayLength;

        if(ground.Raycast(CameraRay,out rayLength)){
            Vector3 pointLook = CameraRay.GetPoint(rayLength);
            transform.LookAt(pointLook);
            Debug.DrawLine(CameraRay.origin,pointLook,Color.red);
        }

    }
  
	void FixedUpdate () 
	{
    	rigidBody.velocity= moveVelocity;

    }
}
