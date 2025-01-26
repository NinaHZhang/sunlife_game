using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollection : MonoBehaviour
{
    
    
    public CoinManager cm; //declares public field cm using coinmanager script stuff

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //gets called when object enters player trigger collider as other
    //if other is an object with tag coin, coin count increases
    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("coin")){
            Destroy(other.gameObject);
            cm.coinCount+=100;
        }

    }
}
