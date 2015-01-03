using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using Microsoft.Practices.Unity;
using Assets.Workspace.MVC.Controllers;


public class MenuController : Controller 
{
    // Modele du menu
    [Dependency]
    private MenuModel menuModel{ get; set;}

    // Vue du menu
    [Dependency]
    private MenuView  menuView { get; set; }

    /// <summary>
    /// Constructeur
    /// </summary>
    public MenuController(MenuModel _menuModel, MenuView _menuView)
    {
        menuModel = _menuModel;
        menuView  = _menuView;
    }

    /// <summary>
    /// Init du VM
    /// </summary>
    public void OnAwake()
    {
        menuModel.OnAwake();
        menuView. OnAwake();
    }

    /// <summary>
    /// Chargement dans  la liste d'invocations du delegate
    /// </summary>
    public void OnStart()
    {
        menuView.OnPlayButtonClicked += PlayButtonClicked;
        menuView.OnHelpButtonClicked += HelpButtonClicked;
        menuView.OnExitButtonClicked += ExitButtonClicked;
        menuView.OnHomeButtonClicked += HomeButtonClicked;
    }

    /// <summary>
    /// Une fois que la vue à lancé la fonction, le model (Play) sera mis à jour à partir du controlleur
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void PlayButtonClicked(object sender, EventArgs e)
    {
        menuModel.switchToGame();
    }

    /// <summary>
    /// Une fois que la vue à lancé la fonction, le model (Help) sera mis à jour à partir du controlleur
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void HelpButtonClicked(object sender, EventArgs e)
    {

    }
    
    /// <summary>
    /// Une fois que la vue à lancé la fonction, le model (Exit) sera mis à jour à partir du controlleur
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ExitButtonClicked(object sender, EventArgs e)
    {
 
    }

    /// <summary>
    /// Une fois que la vue à lancé la fonction, le model (Home) sera mis à jour
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void HomeButtonClicked(object sender, EventArgs e)
    {
    
    }

    /// <summary>
    /// Décharger la fonction de la liste d'invocations du delegate
    /// </summary>
    public void OnDestroy ()
    {
        menuView.OnPlayButtonClicked -= PlayButtonClicked;
        menuView.OnHelpButtonClicked -= HelpButtonClicked;
        menuView.OnPlayButtonClicked -= ExitButtonClicked;
        menuView.OnHomeButtonClicked -= HomeButtonClicked;

        menuView._OnDestroy();
    }
}
