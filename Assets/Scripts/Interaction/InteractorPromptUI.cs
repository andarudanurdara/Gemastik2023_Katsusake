using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractorPromptUI : MonoBehaviour
{
    private Camera _mainCam;
    [SerializeField] private GameObject _uiCanvas;
    [SerializeField] private TextMeshProUGUI _promptText;

    private void Start()
    {
        _mainCam = Camera.main;
    }

    private void LateUpdate()
    {
        var rotation = _mainCam.transform.rotation;
        transform.LookAt(transform.position + rotation * Vector3.forward,
            rotation * Vector3.up);
    }

    public bool isDisplayed = false;

    public void SetUp(string promptText)
    {
        _promptText.text = promptText;
        _uiCanvas.SetActive(true);
        isDisplayed = true;
    }

    public void Close()
    {
        _uiCanvas.SetActive(false);
        isDisplayed = false;
    }
}
