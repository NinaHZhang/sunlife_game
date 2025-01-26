using System.Collections;
using System.Collections.Generic;
using EasyTransition;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public DemoLoadScene demoLoadScene;
    public bool isGirl = false;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Girl()
    {
        PlayerPrefs.SetString("isGirl", "Yes");
        demoLoadScene.LoadScene("TransitionDemo");
        StartCoroutine(WaitGirl());
        
    }
    public void Boy ()
    {
        PlayerPrefs.SetString("isGirl", "No");
        demoLoadScene.LoadScene("TransitionDemo");
        StartCoroutine(WaitBoy());
    }


    IEnumerator WaitGirl()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("Girl");
    }

    IEnumerator WaitBoy()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("Boy");
    }

}
