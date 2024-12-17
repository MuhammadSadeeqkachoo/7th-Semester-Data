using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fallzone : MonoBehaviour
{
    public GameObject gameoverPanel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            gameoverPanel.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

}
