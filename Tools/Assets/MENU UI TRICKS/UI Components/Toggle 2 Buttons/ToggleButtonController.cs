using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ToggleButtonController : MonoBehaviour
{
    public List<ButtonItem> AvailableButtons;

    /// <summary>
    /// thrown each time the value of the button group changes. the string value contains the last value selected
    /// </summary>
    public ValueStringChanged OnButtonValueChanged;


    void Start()
    {
        RegisterToButtonEvents();
    }

    private void RegisterToButtonEvents()
    {
        foreach (ButtonItem item in AvailableButtons)
        {
            item.toggleButton.onValueChanged.AddListener(OnToggleChanged);
        }
    }

    private void OnToggleChanged(bool isToggleOn)
    {
        if (isToggleOn == false) return;

        Debug.Log("OnToggleChanged called ");

        foreach (ButtonItem item in AvailableButtons)
        {
            if (item.toggleButton.isOn)
            {
                OnButtonValueChanged.Invoke(item.ValueIfTrue);
                item.OnActivated.Invoke();
                item.toggleButton.interactable = false;

                Debug.Log("value " + item.ValueIfTrue);

            }
            else
            {
                item.toggleButton.interactable = true;
            }
        }
    }

    public string CurrentValue
    {
        get
        {
            foreach (ButtonItem item in AvailableButtons)
            {
                if (item.toggleButton.isOn)
                {
                    return item.ValueIfTrue;
                }
            }

            return "";
        }
    }

    /// <summary>
    /// make sure button do not actually activates anything. this is only to manually set the state
    /// </summary>
    /// <param name="_value"></param>
    public void SwitchButtonStateByValueWithoutActivatingEffect(string _value)
    {
        Debug.Log("setting one item for on " + _value);

        foreach (ButtonItem item in AvailableButtons)
        {
            if (item.ValueIfTrue == _value)
            {
                item.toggleButton.SetIsOnWithoutNotify(true);
                return;
            }
        }

        Debug.Log("didnt find item for " + _value);
    }
}

[System.Serializable]
public class ButtonItem
{
    public string description;
    public Toggle toggleButton;
    public string ValueIfTrue;

    /// <summary>
    /// thrown each time this button is set to On.
    /// </summary>
    public UnityEvent OnActivated;
}