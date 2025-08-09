using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private string playerSceneName;

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene(playerSceneName, LoadSceneMode.Additive);
        SceneManager.LoadScene("TestLevel", LoadSceneMode.Additive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
