using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Panel : MonoBehaviour
{
    Animator animator;
    public UnityEngine.UI.Button playButton;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
       Time.timeScale = 0f;
        playButton.onClick.AddListener(StartGame);
    }

    public void StartGame()
    {
        animator.SetBool("isStarted", true);
        Time.timeScale = 1f;
    }
}
