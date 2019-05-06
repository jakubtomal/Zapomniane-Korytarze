using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State")]

public class State : ScriptableObject
{
    public bool visitated = false;
    [TextArea(14,10)][SerializeField] string storyText;
    [SerializeField] State[] nextStates;
    [SerializeField] string requiredItem;
    [SerializeField] string itemInside;
    


    public string GetStateStory()
    {
        return storyText;
    }

    public State[] GateNextStates()
    {
        return nextStates;
    }

    public string GetRequiredItem()
    {
        return requiredItem;
    }

    public string GetItemInside()
    {
        return itemInside;
    }


}
