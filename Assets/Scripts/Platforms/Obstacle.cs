using UnityEngine;
using System.Collections; 

public class Obstacle : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator DestroyCountdown()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
        Debug.Log("Object Disabled");
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Character"))
        {
            StartCoroutine(DestroyCountdown());
        }
    }
    
}
