using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Respawn : MonoBehaviour
{
    public Transform respawnPos;
    public Fader fader;
    public PlayerInput input;

    private bool respawning = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            respawnPos = other.transform;
        }
    }

    public void Die()
    {
        if (respawnPos == null) {
            Debug.LogError("Respawn doesn't have a checkpoint!");
            return;
        }
        if (!respawning)
        {
            StartCoroutine(Death());
        }
    }

    IEnumerator Death()
    {
        respawning = true;
        fader.FadeOut(1f);
        input.enabled = false;
        yield return new WaitForSeconds(1f);
        transform.position = respawnPos.position;
        transform.rotation = respawnPos.rotation;
        input.enabled = true;
        fader.FadeIn(1f);
        yield return new WaitForSeconds(1f);
        respawning = false;
    }
}

