using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSeneMove : MonoBehaviour
{
    public enum SceneNums
    {
        MainScene,
        PlayScene
    }

    public void SceneManage()
    {
        SceneManager.LoadScene("PlayScene");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
