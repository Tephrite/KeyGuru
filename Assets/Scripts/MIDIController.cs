using MidiJack;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class MIDIController : MonoBehaviour
{

    public Image[] keys = { };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        for(int x = 0; x < keys.Length; x++)
        {
      
            if (MidiMaster.GetKeyDown(x+36))
            {
                //Debug.Log(keys[x].name + " Pressed");

                keys[x].GetComponent<Image>().color = new Color32(191, 71, 71, 255);
            }
            if (MidiMaster.GetKeyUp(x + 36))
            {
                //Debug.Log(keys[x].name + " Released");

                if (keys[x].GetComponent<Image>().name.Contains("#"))
                {
                    keys[x].GetComponent<Image>().color = new Color32(0, 0, 0, 255);
                }
                else
                {
                    keys[x].GetComponent<Image>().color = new Color32(241, 241, 241, 255);
                }
            }
        }
        
    }
}
