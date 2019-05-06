using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour
{
    [SerializeField] Text textComponent;
    //[SerializeField] TextMesh textComponent;
    [SerializeField] State startingState;
    //[SerializeField] Player player;
    [SerializeField] Text textEquipment;
    [SerializeField] Text events;
    string str;
    Player player;
    State state;
    // Start is called before the first frame update
    void Start()
    {


        //Player player = new Player();
        //player.ReadDictionary();
        //player.ReadDictionary();
        player = new Player();
        state = startingState;
        player.visitated.Clear();
        textComponent.text = state.GetStateStory();
        
    }

    // Update is called once per frame
    void Update()
    {

        
        MenageState();

        foreach (var item in player.equipment)
        {
            if (item.Key != "None" && item.Value > 0)
            {
                str += item.Key + ":" + item.Value + "\n";
            }
        }
        textEquipment.text = str;
        str = "";

    }

    private void MenageState()
    {
        if( state == startingState)
        {
            Start();
        }
        var nextStates = state.GateNextStates();
        

        if (state.GetItemInside() != "None" && !player.visitated.Contains(state))
        {
            events.text = "otrzymujesz : " + state.GetItemInside();
            player.equipment[state.GetItemInside()] += 1;
            
        }

        player.Visit(state);



        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (player.equipment[nextStates[0].GetRequiredItem()] > 0 || player.visitated.Contains(nextStates[0]))
            {
                if(!player.visitated.Contains(nextStates[0]))
                {
                    player.equipment[nextStates[0].GetRequiredItem()] -= 1;
                }
                state = nextStates[0];
                events.text = "";
            }
            else
            {
                state = nextStates[1];
                events.text = "";
            }

        }

        else if (Input.GetKeyDown(KeyCode.Alpha2) && nextStates.Length > 2)
        {
            if(player.equipment[nextStates[2].GetRequiredItem()] > 0 || player.visitated.Contains(nextStates[2]))
            {
                if (!player.visitated.Contains(nextStates[2]))
                {
                    player.equipment[nextStates[2].GetRequiredItem()] -= 1;
                }
                state = nextStates[2];
                events.text = "";
            }
            else
            {
                state = nextStates[3];
                events.text = "";
            }

            
        }

        else if (Input.GetKeyDown(KeyCode.Alpha3) && nextStates.Length > 4)
        {
            if (player.equipment[nextStates[4].GetRequiredItem()] > 0 || player.visitated.Contains(nextStates[4]))
            {
                if (!player.visitated.Contains(nextStates[4]))
                {
                    player.equipment[nextStates[4].GetRequiredItem()] -= 1;
                }
                state = nextStates[4];
                events.text = "";
            }
            else
            {
                state = nextStates[5];
                events.text = "";
            }
        }

        else if (Input.GetKeyDown(KeyCode.Q))
        {
            state = startingState;
        }

        textComponent.text = state.GetStateStory();
    }
}
