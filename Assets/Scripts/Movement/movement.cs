using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
public class movement : MonoBehaviour
{
    public List<GameObject> toolkits = new List<GameObject>();
    public float moveSpeed = 7f;
    public float jumpIntensity = 10f;
    public bool isGrounded = false;
    public bool canEnter = false;
    public bool canPickUp = false;
    public bool picked = false;
    private Rigidbody2D rb;
    private string currentSceneName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        transform.Translate(horizontalInput, 0f,0f);
        
        
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpIntensity);
            isGrounded = false;
        }
        if(Input.GetKeyDown(KeyCode.E) && canEnter){
            switch (currentSceneName)
            {
                case "firstScene":
                    SceneManager.LoadScene("SecondScene");
                    break;
                case "SecondScene":
                    SceneManager.LoadScene("firstScene");
                    break;
                default:
                    break;
            }
            
        }
        if(Input.GetKeyDown(KeyCode.E) && canPickUp)
        {
            picked = true;
            canPickUp = false;
            
        }
        if(Input.GetKeyDown(KeyCode.G) && picked)
        {
            picked = false;
            canPickUp = true;
            
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if(collision.gameObject.CompareTag("f_Ground"))
        {
            isGrounded = true;
        }
    }
    
    void OnTriggerEnter2D(Collider2D trigger)
    {
        // Start the countdown when the player enters the trigger area
        if (trigger.CompareTag("Door"))
        {
            Debug.Log("Player Can Enter");
            //Input Requirement Checker: Tools
            canEnter = true;
        }
        if(trigger.CompareTag("Tool"))
        {
            Debug.Log("Player Can Pick Up Tool");
            canPickUp = true;
            if(canPickUp)
            {
                toolkits.Add(trigger.gameObject);
                picked = true;
                canPickUp = false;
            }
        }
    }
    void OnTriggerExit2D(Collider2D trigger)
    {
        // Start the countdown when the player enters the trigger area
        if (trigger.CompareTag("Door"))
        {
            Debug.Log("Player leaved to the door");
            //Input Requirement Checker: Tools
            canEnter = false;
        }
        if(trigger.CompareTag("Tool"))
        {
            Debug.Log("Player leaved the tool");
            canPickUp = false;
        }
    }
}
