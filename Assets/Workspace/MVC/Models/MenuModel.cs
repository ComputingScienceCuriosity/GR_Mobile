using UnityEngine;
using System.Collections;
using Assets.Workspace.MVC.Models;

/// <summary>
/// Modèle du Menu du jeu
/// </summary>
public class MenuModel : Model
{

    public MenuModel()
    { 
    
    }

    internal void OnAwake()
    {
        // On charge la config par défault du jeu 
        GlobalVariables.Instance.loadConfig();
    }

    /// <summary>
    /// Lances le permier niveau du jeu
    /// </summary>
    internal void switchToGame()
    {
        Canvas canvasLoading = GameObject.FindGameObjectWithTag("loading").GetComponent<Canvas>() as Canvas;
        canvasLoading.enabled = true;
        Application.LoadLevel("Level1");
    }
}
