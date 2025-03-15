using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{

    public Animator animator;

    public static LoadingManager instance;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += HideLoadingScreen;
    }

    void HideLoadingScreen(Scene scene, LoadSceneMode mode)
    {
        animator.SetTrigger("Enter");
        Debug.Log("Hiding Loading Screen");
    }

    // called by doors
    public void ShowLoadingScreen()
    {
        animator.SetTrigger("Exit");
        Debug.Log("Showing Loading Screen");
    }

}
