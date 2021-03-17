using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [FormerlySerializedAs("speed")] [SerializeField]
    private float _speed = 5f;

    [SerializeField] 
    private GameObject _vaccinePrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        // reset player position on start
        transform.position = new Vector3(x: 0f, y: 0f, z: 0f);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        
        // if a certain button (spacebar) is pressed
        // then instantiate our vaccine prefab
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(message:"space bar pressed!");
            Instantiate(_vaccinePrefab, transform.position, Quaternion.identity);
        }

        // setting up the horizontal boundaries for the player
        if (transform.position.y > 2.1f)
        {
            transform.position = new Vector3(transform.position.x,
                2.1f,
                0f);
        }
        // check for lower boundary
        else if (transform.position.y < -2.1f)
        {
            // keep player within the lower boundary
            transform.position = new Vector3(transform.position.x,
                -2.1f,
                0f);
        }
        // each time the player reaches the vertical boundaries of the box,
        // it should appear on the other side
        if (transform.position.x > 10.1f)
        {
            transform.position = new Vector3(-10.1f,
                transform.position.y,
                0f);
        }
        
        else if (transform.position.x < -10.1f)
        {
            transform.position = new Vector3(10.1f,
                transform.position.y,
                0f);
        }
    }

    // player movement function
    void PlayerMovement()
    {
        // read player input on x and y axis
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        // apply player movement
        Vector3 playerTranslate = new Vector3(
            1f * horizontalInput * _speed * Time.deltaTime,
            1f * verticalInput * _speed * Time.deltaTime,
            0f);
        transform.Translate(playerTranslate);
    }
}