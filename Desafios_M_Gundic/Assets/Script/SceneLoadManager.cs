using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    [SerializeField] private float transitionTime = 1f;
    [SerializeField] public String nextScene;
    private Animator transitionAnimator;
    void Start()
    {
        transitionAnimator = GetComponentInChildren<Animator>();
    }

    public void LoadNextScene()
    {
        //int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        StartCoroutine(SceneLoad(nextScene));

    }

    public IEnumerator SceneLoad (String Scene)
    {
        transitionAnimator.SetTrigger("StartTransition");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(Scene);
    }
}
