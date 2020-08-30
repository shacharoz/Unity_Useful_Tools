using UnityEngine;
using UnityEngine.UI;

public class SliderIntegrator : MonoBehaviour
{
    public Text titleHolder;
    public Text minimumValueHolder; 
    public Text currentValueHolder; 
    public Text maximumValueHolder;
    public Slider slider;

    public enum SliderType
    {
        Standard,
        LabeledIntValues,
        TwoValuesInOne,
    }
    public SliderType type;


    public void SetData(string title, int minValue, int maxValue)
    {
        minimumValueHolder.text = minValue.ToString();
        maximumValueHolder.text = maxValue.ToString();
        titleHolder.text = title;

        slider.minValue = minValue;
        slider.maxValue = maxValue;

        //set init values- according to exisitng state
        if (slider.value > maxValue)
            slider.value = maxValue;
        if (slider.value < minValue)
            slider.value = minValue;

        currentValueHolder.text = slider.value.ToString();
    }

    private LabeledIntRange valueRangeHolder;
    public void SetData(string title, LabeledIntRange valueRange, bool maintainPreviousValue = true)
    {
        float previousValue = (valueRangeHolder != null) ? valueRangeHolder.GetValueByIndex(slider.value) : -1;
        
        valueRangeHolder = valueRange;

        minimumValueHolder.text = valueRangeHolder.MinValue.Label;
        maximumValueHolder.text = valueRangeHolder.MaxValue.Label;
        titleHolder.text = title;

        slider.minValue = 0;
        slider.maxValue = valueRangeHolder.values.Count-1;

        //set init values- according to exisitng state
        if (slider.value > valueRangeHolder.values.Count-1)
            slider.value = valueRangeHolder.values.Count - 1;
        if (slider.value < 0)
            slider.value = 0;

        if (maintainPreviousValue && previousValue != -1)
        {
            float result = valueRangeHolder.GetIndexByValue(previousValue);
            if (result == -1)
            {
                //meaning value was not found (either too big or too small)
                if (previousValue > valueRangeHolder.MaxValue.Value)
                    result = valueRangeHolder.values.Count - 1; //put max value
                else if (previousValue < valueRangeHolder.MinValue.Value)
                    result = 0; //put min value
            }

            slider.value = result;
        }

        //set current value content
        currentValueHolder.text = valueRangeHolder.GetLabelByIndex(slider.value);
    }

    

    void Start()
    {
        
    }

    public ValueFloatChanged OnSliderValueUpdated;

    public float CurrentValue
    {
        get
        {
            if (type == SliderType.Standard)
            {
                return slider.value;
            }
            else if (type == SliderType.LabeledIntValues)
            {
                return valueRangeHolder.GetValueByIndex(slider.value);
            }
            else 
            {
                Debug.LogWarning("SliderIntegrator.CurrentValue: unexpected request");
                return -1;
            }
        }
    }

    public void OnValueUpdated(float value)
    {
        if (type == SliderType.Standard)
        {
            currentValueHolder.text = value.ToString();
            OnSliderValueUpdated.Invoke(value);
        }
        else if (type == SliderType.LabeledIntValues)
        {
            currentValueHolder.text = valueRangeHolder.GetLabelByIndex(slider.value);
            OnSliderValueUpdated.Invoke(valueRangeHolder.GetValueByIndex(slider.value));
        }
    }
}