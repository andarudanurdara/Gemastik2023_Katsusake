using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    [SerializeField] private string _interactPrompt;
    public string InteractPrompt => _interactPrompt;

    public bool Interact(Interactor interactor)
    {
        Debug.Log("Opening Chest!");
        transform.position += new Vector3(1.0f,0f,0f);
        return true;
    }
}
