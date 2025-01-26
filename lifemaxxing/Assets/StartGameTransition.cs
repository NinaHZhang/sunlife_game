using System.Collections;
using System.Collections.Generic;
using EasyTransition;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameTransition : MonoBehaviour
{
    public DemoLoadScene demoLoadScene;

    // Start is called before the first frame update
    void Start()
    {
        demoLoadScene.LoadScene("TransitionDemo");
    }


}
