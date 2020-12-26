using UnityEngine;

[System.Serializable]
public class LabeledIntRange
{
    public System.Collections.Generic.List<LabeledInt> values;

    public LabeledInt MinValue
    {
        get
        {
            return values[0];
        }
    }

    public LabeledInt MaxValue
    {
        get
        {
            return values[values.Count - 1];
        }
    }

    /// <summary>
    /// depricated. use GetValueByIndex instead
    /// </summary>
    /// <param name="_label"></param>
    /// <returns></returns>
    public float GetValueByLabel(string _label)
    {
        foreach (LabeledInt lVal in values)
        {
            if (lVal.Label == _label)
            {
                return lVal.Value;
            }
        }

        Debug.LogWarning("GetValueByLabel didnt find label: " + _label);
        return -1;
    }
    /// <summary>
    /// depricated. use GetLabelByIndex instead
    /// </summary>
    /// <param name="_value"></param>
    /// <returns></returns>
    public string GetLabelByValue(float _value)
    {
        foreach (LabeledInt lVal in values)
        {
            if (lVal.Value == _value)
            {
                return lVal.Label;
            }
        }

        Debug.LogWarning("GetLabelByValue didnt find value " + _value);
        return "";
    }
    public float GetValueByIndex(float _index)
    {
        if (values.Count <= _index)
        {
            Debug.LogWarning("GetValueByIndex didnt find index: " + _index);
            return -1;
        }

        return values[(int)_index].Value;
    }
    public string GetLabelByIndex(float _index)
    {
        if (values.Count <= _index)
        {
            Debug.LogWarning("GetValueByIndex didnt find index: " + _index);
            return "";
        }

        return values[(int)_index].Label;
    }
    public float GetIndexByValue(float _value)
    {
        for (int i = 0; i < values.Count; i++) 
        {
            if (values[i].Value == _value)
            {
                return i;
            }
        }

        Debug.LogWarning("GetIndexByValue: no value found for "+_value);
        return -1;
     }

}

[System.Serializable]
public class LabeledInt
{
    public string Label;
    public float Value;
}