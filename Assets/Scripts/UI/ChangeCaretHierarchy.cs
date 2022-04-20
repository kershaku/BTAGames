using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCaretHierarchy : MonoBehaviour
{
    //public GameObject groupUIHolder;
    GameObject caret;
    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ChangeCaretPosition();
        }
            
    }

    public void ChangeCaretPosition()
    {
        caret = GameObject.Find("InputField Input Caret");
        caret.transform.SetAsLastSibling();
        caret = GameObject.Find("SONA_Input Input Caret");
        caret.transform.SetAsLastSibling();
    }

}



