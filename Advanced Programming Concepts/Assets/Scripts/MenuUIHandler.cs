using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public ColorPicker ColorPicker;

    public void NewColorSelected(Color color)
    {
        // add code here to handle when a color is selected
    }
    
    private void Start()
    {
        ColorPicker.Init();
        //this will call the NewColorSelected function when the color picker have a color button clicked.
        ColorPicker.onColorChanged += NewColorSelected;
    }

    #region menuButtons
    public void startGame()
    {
        SceneManager.LoadScene(1);

    }

    public void exitGame()
    {
        //if the game is running in the editor)
#if (UNITY_EDITOR)
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
        
    }

    #endregion
}