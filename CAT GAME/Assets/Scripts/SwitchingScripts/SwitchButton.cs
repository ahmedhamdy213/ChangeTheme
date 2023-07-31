// SwitchButton.cs

using UnityEngine;
using UnityEngine.UI;

public class SwitchButton : MonoBehaviour
{
    private SwitchController switchController;

    private void Start()
    {
        switchController = GameObject.FindObjectOfType<SwitchController>();
        if (switchController == null)
        {
            Debug.LogError("SwitchController not found in the scene. Make sure you have a SwitchManager GameObject with the SwitchController script attached.");
            this.gameObject.SetActive(false);
        }
    }

    public void OnSwitchButtonClick()
    {
        switchController.SwitchObjects();
    }
}
