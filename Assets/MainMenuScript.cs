using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public void OnClickSound()
    {
        SoundManagerScript.PlaySound("clickSound");  
    }
}
