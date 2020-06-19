﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject UIElements;

    public Animator transition;

    public float transitionTime = 1f;

    public void PlayGame()
    {
        FindObjectOfType<AudioManager>().Play("Select");
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public IEnumerator LoadLevel(int levelIndex)
    {
        UIElements.SetActive(false); // disable UI elements while transitioning between scenes

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

    public void QuitGame()
    {
        FindObjectOfType<AudioManager>().Play("Select");
        Debug.Log("QUIT");
        Application.Quit();
    }
}
