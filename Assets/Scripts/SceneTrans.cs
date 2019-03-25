using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrans : MonoBehaviour
{   
    public  string  SceneName;
    public Vector2  startPos;
        
   

    // Start is called before the first frame update
    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     IEnumerator MergeMethodEnumerator()
    {
        yield return SceneManager.LoadSceneAsync(this.SceneName, LoadSceneMode.Additive);                           //等待场景加载完毕后，再向下执行
        SceneManager.MergeScenes(SceneManager.GetSceneByName(this.SceneName), SceneManager.GetActiveScene()); //源场景 1，目标场景：当前 —— 将源场景合并到目标场景中
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && other.isTrigger){           
            SceneManager.LoadScene(this.SceneName);
            // StartCoroutine(this.MergeMethodEnumerator());
            other.transform.position = this.startPos;
        }
    }


}
