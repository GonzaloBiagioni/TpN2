using UnityEngine;
using TMPro;

public class Dialogo_NPC : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;

    private void OnEnable()
    {
        NPC.onNPCInteract += ActivarDialogo;
        NPC.onNPCExit += DesactivarDialogo;
    }

    private void OnDisable()
    {
        NPC.onNPCInteract -= ActivarDialogo;
        NPC.onNPCExit -= DesactivarDialogo;
    }

    private void ActivarDialogo()
    {
        dialogueText.gameObject.SetActive(true);
        dialogueText.text = "Porfavor salvanos de la llama infernal";
    }

    private void DesactivarDialogo()
    {
        dialogueText.gameObject.SetActive(false);
    }
}
