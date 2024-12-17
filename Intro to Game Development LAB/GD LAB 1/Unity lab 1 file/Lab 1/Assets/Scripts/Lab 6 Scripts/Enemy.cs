using UnityEngine;

public class Enemy : MonoBehaviour
{
    string[] message = { "Dead!", "Killed!", "Defeated!" };

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
            Invoke("ChangeColor", .5f);
            Destroy(gameObject,1);
            Debug.Log(message[Random.Range(0,message.Length)]);
        }
    }

    private void ChangeColor()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
    }
}
