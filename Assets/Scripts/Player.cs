using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player")]

public class Player : ScriptableObject
{
    public Dictionary<string, int> equipment = new Dictionary<string, int>()
    {
        {"None",99999999 },
        {"klucz" , 0 },
        {"miecz" , 0 },
        {"sznur" , 0 },
        {"cuchnący płyn",0 }
    };
    public List<State> visitated = new List<State>() {  };

    
    public void Visit(State state)
    {
        visitated.Add(state);

    }
    public void ReadDictionary()
    {
        Debug.Log(equipment["klucz"]);
        equipment["klucz"] = 2;
        Debug.Log(equipment["klucz"]);


    }
}
