using UnityEngine;
using UnityEngine.UI;

public class ColorChangedHandler : MonoBehaviour
{
    [SerializeField] private InputField inputField;

    public void ColorChanged(Color color)
    {
        inputField.textComponent.color = color;
    }
}
