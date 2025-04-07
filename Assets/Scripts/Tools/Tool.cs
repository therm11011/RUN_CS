using UnityEngine;

public class Tool : MonoBehaviour
{
    public movement action;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(action.picked){
            gameObject.SetActive(false);
        }

        if(action.canPickUp == false && action.picked == true){
            transform.position = action.transform.position;
            action.toolkits.Remove(gameObject);
            gameObject.SetActive(true);
        }
    }

}
