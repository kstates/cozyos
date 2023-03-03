using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class DialogSystem : MonoBehaviour
{
    public TextAsset dialogJson;
    public Text dialogText;
    private DialogPanels dialogPanels;
    
    // Start is called before the first frame update
    void Start()
    {
        dialogPanels = JsonUtility.FromJson<DialogPanels>(dialogJson.text);
        dialogText.text = dialogPanels.passages[0].text;

        foreach (DialogPanel dialogPanel in dialogPanels.passages) 
        {
           Debug.Log("Found dialog: " + dialogPanel.text); 
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
