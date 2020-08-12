using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentHealth : MonoBehaviour
{
    static Text text;
    
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        text.text = "Health: " + PlayerController.health.ToString();
    }

    public static void UpdateHealth()
    {
        text.text = "Health: " + PlayerController.health.ToString();
    }
}
