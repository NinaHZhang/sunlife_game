using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseImageScript : MonoBehaviour

{

    public Image house;
    public bool isOnCooldown = false;
    public GameObject shield;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shield.activeSelf && !isOnCooldown)
        {
            StartCoroutine(CooldownRoutine());
        }
        
    }

    private IEnumerator CooldownRoutine()
    {
        isOnCooldown = true;
        house.enabled = false;
        yield return new WaitForSeconds(8f);
        house.enabled = true;
        isOnCooldown = false;
    }
}
