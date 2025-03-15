using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CurtainManager : MonoBehaviour
{

    [SerializeField] Animator EnterAnimator;
    [SerializeField] Animator ExitAnimator;

    public static CurtainManager instance;
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
    void OnEnable()
    {
        SetObjectVisible(EnterAnimator, true);
        // SceneManager.sceneLoaded += PlayEnter;
        PlayEnter();
    }
    // Scene scene, LoadSceneMode mode
    void PlayEnter()
    {
        if (gameObject)
            StartCoroutine(PlayEnterWait());

        IEnumerator PlayEnterWait()
        {
            yield return new WaitForSeconds(0.5f);
            PlayEnterAnimation();
        }
    }
    void PlayEnterAnimation()
    {
        Debug.Log("Playing Enter Animation");
        SetObjectVisible(EnterAnimator, true);
        SetObjectVisible(ExitAnimator, false);

        EnterAnimator.SetTrigger("Play");
    }

    // called by Doors
    public void PlayExit()
    {
        PlayExitAnimation();
    }

    void ShowLoadingScreen()
    {
        SetObjectVisible(EnterAnimator, true);
        Debug.Log("Curaing ShowLoadingScreen called");

    }

    void PlayExitAnimation()
    {
        Debug.Log("Playing Exit Animation");
        SetObjectVisible(ExitAnimator, true);

        ExitAnimator.SetTrigger("Play");
    }

    void OnDisable()
    {
        SetObjectVisible(EnterAnimator, true);
        Debug.Log("Curaing OnDisable called");
    }
    void SetObjectVisible(Animator anim, bool active)
    {
        anim.GetComponent<CanvasGroup>().alpha = active ? 1 : 0;
    }
}
