using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{
    // Start is called before the first frame update
    public health playerHealth;
    public Image totalhealthBar;
    public Image currenthealthBar;

    private void Start() {
        totalhealthBar.fillAmount = playerHealth.startingHealth/10;
    }

    private void Update(){
        currenthealthBar.fillAmount = playerHealth.currentHealth/10;
    }
}
