using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FontBlink : MonoBehaviour
{
    [SerializeField] [Range(0, 1)] private float maxOpacity = 1f;
    [SerializeField] [Range(0, 1)] private float minOpacity = 0;
    [SerializeField] private float intervalBreathRate = 0.1f;
    Text txt;
    private bool isInc;

    private void Awake()
    {
        isInc = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<Text>();
        Color newTxtColor = txt.color;
        txt.color = newTxtColor;
    }

    // Update is called once per frame
    void Update()
    {
        Color newTxtColor = txt.color;
        float aVal = newTxtColor.a;
        if (isInc)
        {
            aVal += intervalBreathRate * Time.deltaTime;
            if (aVal > maxOpacity)
            {;
                aVal = maxOpacity;
                isInc = !isInc;
            }
        }
        else
        {
            aVal -= intervalBreathRate * Time.deltaTime;
            if (aVal < minOpacity)
            {
                aVal = minOpacity;
                isInc = !isInc;
            }
        }

        newTxtColor.a = aVal;
        txt.color = newTxtColor;
    }
}
