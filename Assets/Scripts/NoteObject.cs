using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;
public class NoteObject : MonoBehaviour
{

    public bool canBePressed;
    public bool isScale;
    public float noteNumber;

    public int keyToPress;

    // Start is called before the first frame update
    void Start()
    {
        if (isScale){
            transform.localPosition = new Vector3(transform.localPosition.x, (-90.0f + noteNumber * 67.0f), transform.localPosition.z);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (MidiMaster.GetKeyDown(keyToPress))
        {
            if(canBePressed)
            {
                gameObject.SetActive(false);

                GameManager.instance.NoteHit();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            canBePressed = true;
        }
        else if (other.tag == "Miss")
        {
            canBePressed = false;

            GameManager.instance.NoteMissed();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = false;

        }
    }
}
