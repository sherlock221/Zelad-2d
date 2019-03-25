using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

     public GameObject  Player;   
    // Start is called before the first frame update

    private void Awake() {

        DontDestroyOnLoad (this);//防止人物在切换场景的时候被销毁          
        
    }
    void Start()
    {

        SceneManager.LoadScene("FirstScene");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
