// SelectableObject.cs

using UnityEngine;

public class SelectableObject : MonoBehaviour
{
    private SwitchController switchController;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    public Color selectedColor;

    private bool isSelected = false; // Keep track of selection state

    private void Start()
    {
        switchController = GameObject.FindObjectOfType<SwitchController>();
        if (switchController == null)
        {
            Debug.LogError("SwitchController not found in the scene. Make sure you have a SwitchManager GameObject with the SwitchController script attached.");
            this.enabled = false;
        }

        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color;
        }
    }

    private void OnMouseDown()
    {
        if (switchController != null)
        {
            if (isSelected)
            {
                switchController.SetSecondSelected(transform);
                // Show the Switch button on UI or handle UI visibility here.
            }
            else
            {
                switchController.SetFirstSelected(transform);
                // Hide the Switch button on UI or handle UI visibility here.
            }
            // Toggle selection state
            isSelected = !isSelected;

            // Change the color of the selected object
            if (spriteRenderer != null)
            {
                spriteRenderer.color = isSelected ? selectedColor : originalColor;
            }
        }
    }

    public void Deselect()
    {
        isSelected = false;
        // Restore the original color when deselected
        if (spriteRenderer != null)
        {
            spriteRenderer.color = originalColor;
        }
    }
}
