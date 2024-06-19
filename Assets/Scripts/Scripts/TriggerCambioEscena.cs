using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerCambioEscena : MonoBehaviour
{
    private bool canChangeScene = false;

    private void OnEnable()
    {
        if (EventManager.Instance != null)
        {
            EventManager.Instance.OnNPCInteract += EnableSceneChange;
        }
        else
        {
            Debug.LogWarning("EventManager.Instance is null in TriggerCambioEscena.OnEnable()");
        }
    }

    private void OnDisable()
    {
        if (EventManager.Instance != null)
        {
            EventManager.Instance.OnNPCInteract -= EnableSceneChange;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && canChangeScene)
        {
            SceneManager.LoadScene(2);
        }
    }

    private void EnableSceneChange()
    {
        canChangeScene = true;
    }
}
