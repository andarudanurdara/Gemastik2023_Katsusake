using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform _interactorPoint;
    [SerializeField] private float _interactorPointRadius = 2f;
    [SerializeField] private LayerMask _interactableMask;
    [SerializeField] private InteractorPromptUI _interactPromptUI;

    private readonly Collider[] _colliders = new Collider[3];
    [SerializeField] private int _colFound;
    private IInteractable interactable;

    private void Update()
    {
        // Find everything that touches the sphere
        _colFound = Physics.OverlapSphereNonAlloc(_interactorPoint.position, _interactorPointRadius
            , _colliders, _interactableMask);

        if (_colFound > 0)
        {
            interactable = _colliders[0].GetComponent<IInteractable>();

            if (interactable != null )
            {
                if (!_interactPromptUI.isDisplayed) _interactPromptUI.SetUp(interactable.InteractPrompt);

                if (Input.GetKey(KeyCode.X)) interactable.Interact(this);
            }
        }
        else
        {
            if (interactable != null) interactable = null;
            if (_interactPromptUI.isDisplayed) _interactPromptUI.Close();
        }

    }

    // For development to see the interaction radius
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactorPoint.position, _interactorPointRadius);
    }
}
