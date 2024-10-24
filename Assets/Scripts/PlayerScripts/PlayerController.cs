using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20.0f;
    
    // Setting up multiple cameras
    public Camera mainCamera;
    public Camera firstPersonCamera;
    public KeyCode switchKey;
    
    // Setting up Split-Screen
    public string inputID;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move the horse forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        
        
    }
}
