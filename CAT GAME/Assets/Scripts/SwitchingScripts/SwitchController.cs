// SwitchController.cs

using UnityEngine;
using UnityEngine.UI;

public class SwitchController : MonoBehaviour
{
    private Transform firstSelected;
    private Transform secondSelected;
    private int remainingUses = 3; // Set the initial number of remaining uses

    public Text remainingUsesText; // Reference to the UI Text object for displaying remaining uses

    private void Start()
    {
        UpdateRemainingUsesText();
    }

    public bool IsFirstSelected()
    {
        return firstSelected != null;
    }

    public void SetFirstSelected(Transform obj)
    {
        DeselectObjects();
        firstSelected = obj;
    }

    public void SetSecondSelected(Transform obj)
    {
        secondSelected = obj;
    }

    public void SwitchObjects()
    {
        if (firstSelected != null && secondSelected != null && remainingUses > 0)
        {
            Vector3 tempPosition = firstSelected.position;
            firstSelected.position = secondSelected.position;
            secondSelected.position = tempPosition;

            // Reset selection after switching objects
            firstSelected = null;
            secondSelected = null;

            // Decrease the remaining uses
            remainingUses--;

            UpdateRemainingUsesText();
        }
    }

    private void DeselectObjects()
    {
        if (firstSelected != null)
        {
            var firstSelectable = firstSelected.GetComponent<SelectableObject>();
            if (firstSelectable != null)
            {
                firstSelectable.Deselect();
            }
        }

        if (secondSelected != null)
        {
            var secondSelectable = secondSelected.GetComponent<SelectableObject>();
            if (secondSelectable != null)
            {
                secondSelectable.Deselect();
            }
        }
    }

    private void UpdateRemainingUsesText()
    {
        if (remainingUsesText != null)
        {
            remainingUsesText.text = "Remaining Uses: " + remainingUses.ToString();
        }
    }
}
