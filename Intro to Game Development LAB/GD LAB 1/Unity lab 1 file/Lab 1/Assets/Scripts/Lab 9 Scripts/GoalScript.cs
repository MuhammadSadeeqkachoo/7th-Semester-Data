using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public GameObject gameCompletedPanel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {

                gameCompletedPanel.SetActive(true);
                Time.timeScale = 0.0f;
        }
    }
}
