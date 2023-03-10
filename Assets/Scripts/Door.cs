using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string doorPosition;
    public string destinationScene; // Actual scene name to travel to
    public string destinationSceneLabel; // Label for mouseover  
    private SpriteRenderer mySpriteRenderer;

    // This function is called just one time by Unity the moment the component loads
   private void Awake()
   {
        // get a reference to the SpriteRenderer component on this gameObject
        mySpriteRenderer = GetComponent<SpriteRenderer>();
   }

    // Start is called before the first frame update
    void Start()
    {
        // Right positioned door is default
        switch (this.doorPosition)
        {
            case "left":
                mySpriteRenderer.flipX = true;
                break;
            case "middle": // TODO: Middle will need a second sprite - can't just be flipped
                break;
        }
        
    }

    private void OnMouseDown()
    {
        SceneManager.LoadScene(destinationScene);
    }
}
