using UnityEngine;

public class carrotMoveScript : MonoBehaviour
{

    public float moveSpeed = 5;
    public float deadZone = -45;
   
    void Start()
    {
        
    }

    
    void Update()
    {

        transform.position = transform.position + (Vector3.left * moveSpeed)* Time.deltaTime;

        if(transform.position.x < deadZone){
            
            Debug.Log(" carrot deleted");
             Destroy(gameObject);
        }
        
    }
}
