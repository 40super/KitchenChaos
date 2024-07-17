using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;



public class Player : MonoBehaviour
{
    //Use SerializeField to expose the variable to the editor
   
    [SerializeField] private float moveSpeed = 7.0f;
    // Update is called once per frame
    private void Update(){
        //LEGACY MOVEMENT
        //Input.GetKey is a bool that listen for the key as long it is held down while .GetKeyDown only listen when it is pressed once.
        Vector2 inputVector = new Vector2(0, 0); 
        if (Input.GetKey(KeyCode.W)) {

            inputVector.y = 1;
        }
        if (Input.GetKey(KeyCode.S)) {

            inputVector.y = -1;
        }
        if (Input.GetKey(KeyCode.A)) {

            inputVector.x = -1;
        }
        if (Input.GetKey(KeyCode.D)) {

            inputVector.x = +1;
        }
        //this normalize input so if pressing two keys the speed of the vector will be normalzie and not me multiplied without normalizing.
        
        inputVector = inputVector.normalized;
        Vector3 moveDir = new Vector3 (inputVector.x, 0f, inputVector.y);
        transform.position += moveDir * moveSpeed * Time.deltaTime;
        Debug.Log(inputVector);

        //This code section allow rotating of the model when moving around.
        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir,Time.deltaTime * rotateSpeed);
    }
}
