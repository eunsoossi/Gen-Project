
//Create a UI element. To do this go to Create>UI and select from the list. Attach this script to the UI GameObject to see this script working. The script also works with non-UI elements, but highlighting works better with UI.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//Use the Selectable class as a base class to access the IsHighlighted method
public class DissapearShadow2 : Selectable
{
    //Use this to check what Events are happening
    BaseEventData m_BaseEvent2;
	public GameObject shadow2;


    void Update()
    {
        //Check if the GameObject is being highlighted
        if (IsHighlighted(m_BaseEvent2) == true)
        {
			shadow2.SetActive(false);
            //Output that the GameObject was highlighted, or do something else
        }
		else 
		{
			shadow2.SetActive(true);
		}
    }
}