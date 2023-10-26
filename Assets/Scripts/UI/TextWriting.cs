using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class TextWriting : MonoBehaviour
{
    public float interval;
    [TextArea(15, 20)]
    public string text;
    public TextMeshProUGUI textMesh;
    public UnityEvent onReachedEnd;

    float currentInterval;
    int current = 0;
    string writtenOutText = "";
    bool start;

    // Update is called once per frame
    void Update()
    {

        if (start && currentInterval <= 0 && current < text.Length && current >= 0)
        {
            writtenOutText += text[current];
            textMesh.text = writtenOutText;
            current++;
            if (current >= text.Length)
            {
                onReachedEnd.Invoke();
            }
            currentInterval = interval;
        }
        currentInterval -= Time.unscaledDeltaTime;


        if (start && Input.anyKeyDown) { 
            Skip(); 
        }
    } 

    public void Skip()
    {
        writtenOutText = text;
        textMesh.text = writtenOutText;
        current = writtenOutText.Length;
        onReachedEnd.Invoke();
    }

    public void StartText()
    {
        if (!start)
        {
            ResetText();
            start = true;
        }
        
        
    }

    public void ResetText()
    {
        textMesh.text = "";
        writtenOutText = "";
        currentInterval = interval;
        current = 0;
    }
}
