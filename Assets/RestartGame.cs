using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartGame : MonoBehaviour
{   
    [SerializeField] Button button;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void RestartGameFunc(){
        EditorApplication.isPlaying = false;
    }
    // Update is called once per frame
    void Update()
    {
        button.onClick.AddListener(RestartGameFunc);
    }
}
