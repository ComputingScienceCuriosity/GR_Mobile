using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Assets.Workspace.MVC.Views;

public class MenuView : View
{
    #region MenuEvents
    /// <summary>
    /// Event du bouton Play
    /// </summary>
    internal event UEventHandler OnPlayButtonClicked;

    /// <summary>
    /// Event du bouton Help
    /// </summary>
    internal event UEventHandler OnHelpButtonClicked;

    /// <summary>
    /// Event du bouton Exit
    /// </summary>
    internal event UEventHandler OnExitButtonClicked;

    /// <summary>
    /// Event du bouton Home
    /// </summary>
    internal event UEventHandler OnHomeButtonClicked;
    #endregion 

    #region ViewComponents
    // Gameobject contenant les éléments du MenuPrincipal
    private GameObject MainMenu;

    // Gameobject contenant les éléments du MenuAide
    private GameObject HelpMenu;

    // Bouton Jouer
    private Button button_play;

    // Bouton Aide
    private Button button_help;

    // Bouton Quitter
    private Button button_exit;

    // Bouton Retour
    private Button button_home;
    #endregion 

    /// <summary>
    /// Constructeur
    /// </summary>
    public MenuView()
    {

    }

    #region Methods
    /// <summary>
    /// Récupération des Composants UI et initialisation
    /// </summary>
    internal void OnAwake()
    {
        MainMenu    = GameObject.FindGameObjectWithTag("MainMenu");
        HelpMenu    = GameObject.FindGameObjectWithTag("HelpMenu");

        button_play = GameObject.FindGameObjectWithTag("buttonPlay").GetComponent<Button>() as Button;
        button_help = GameObject.FindGameObjectWithTag("buttonHelp").GetComponent<Button>() as Button;
        button_home = GameObject.FindGameObjectWithTag("buttonHome").GetComponent<Button>() as Button;
        button_exit = GameObject.FindGameObjectWithTag("buttonExit").GetComponent<Button>() as Button;

        HelpMenu.SetActive(false);

        // Binding des events 
        button_play.onClick.AddListener(() => PlayButtonClicked(this, new EventArgs()));
        button_help.onClick.AddListener(() => HelpButtonClicked(this, new EventArgs()));
        button_exit.onClick.AddListener(() => ExitButtonClicked(this, new EventArgs()));
        button_home.onClick.AddListener(() => HomeButtonClicked(this, new EventArgs()));
    }

    /// <summary>
    /// Permet de déclencher l'action Play
    /// </summary>
    private void PlayButtonClicked(object sender, EventArgs e)
    {
        if (OnPlayButtonClicked != null)
            OnPlayButtonClicked(sender, e);
    }

    /// <summary>
    /// Permet de déclencher l'action Help
    /// </summary>
    private void HelpButtonClicked(object sender, EventArgs e)
    {
        if (MainMenu.activeSelf)
        {
            MainMenu.SetActive(false);

            iTween.MoveTo(Camera.main.gameObject, new Vector3(48f, 5f, -10.9f), 3.5f);
           
            HelpMenu.SetActive(true);
        }
        else
        {
            MainMenu.SetActive(true);
            HelpMenu.SetActive(false);
        }

        if (OnHelpButtonClicked != null)
            OnHelpButtonClicked(sender, e);
    }

    /// <summary>
    /// Permet de déclencher l'action Exit
    /// </summary>
    private void ExitButtonClicked(object sender, EventArgs e)
    {
        if (OnExitButtonClicked != null)
            OnExitButtonClicked(sender, e);

#if UNITY_ANDROID
        Application.Quit();
#endif
    }

    /// <summary>
    /// Permet de déclencher l'action Home
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void HomeButtonClicked(object sender, EventArgs e)
    {
        HelpMenu.SetActive(false);

        iTween.MoveTo(Camera.main.gameObject, new Vector3(1.9f, 1.4f, -10.9f), 3.5f);

        MainMenu.SetActive(true);

        if (OnHomeButtonClicked != null)
            OnHomeButtonClicked(sender, e);
    }

    /// <summary>
    /// Décharge les listeners des boutons
    /// </summary>
    internal void _OnDestroy()
    { 
         button_play.onClick.RemoveAllListeners();
         button_help.onClick.RemoveAllListeners();
         button_exit.onClick.RemoveAllListeners();
         button_home.onClick.RemoveAllListeners();
    }
    #endregion 
}
