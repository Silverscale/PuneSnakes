using UnityEngine;
using UnityEngine.UI;

public class UIColorPicker : MonoBehaviour, ISnakeColorPicker
{
    [SerializeField] private Button[] colorButtons = default;

    private Color colorSelected;

    private void Start() {
        if (colorButtons == null || colorButtons.Length == 0) {
            Debug.LogError("Color buttons array is not assigned or is empty!");
        }
        StartListeningForButtonClicks();
        SelectDefaultColor();
    }

    private void StartListeningForButtonClicks() {
        foreach (var button in colorButtons) {
            button.onClick.AddListener(() => OnButtonClick(button));
        }
    }

    public void OnButtonClick(Button buttonPressed) {
        var buttonImage = buttonPressed.GetComponent<Image>();
        colorSelected = buttonImage.color;
    }

    private void SelectDefaultColor() {
        OnButtonClick(colorButtons[0]);
    }

    public Color GetSelectedSnakeColor() {
        return colorSelected;
    }
}
