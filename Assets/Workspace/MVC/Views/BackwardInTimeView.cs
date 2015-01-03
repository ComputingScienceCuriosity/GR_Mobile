using Assets.Workspace.MVC.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class BackwardInTimeView : View
{
    #region BackInTimeEvents
    /// <summary>
    /// Évenement permettant de valider le choix (OUI) de l'utilisateur sur l'utilisation du retour dans le temps
    /// </summary>
    public event UEventHandler OnValidateBackwardYes;

    /// <summary>
    /// Évenement permettant de valider le choix (NON) de l'utilisateur sur l'utilisation du retour dans le temps
    /// </summary>
    public event UEventHandler OnValidateBackwardNo;

    /// <summary>
    /// Évenement de retour en arriere (Undo)
    /// </summary>
    /// <returns></returns>
    public event UEventHandler OnForwarded;

    /// <summary>
    /// Évenement de retour en avant   (Redo)
    /// </summary>
    /// <returns></returns>
    public event UEventHandler OnBackwarded;

    /// <summary>
    /// Évenement liée au slider (représentation gui de nombre d'action Undo/Redo Possibles)
    /// </summary>
    public event UEventHandler_slider OnSliderChanged;
    #endregion 

    private GameObject MessageContainer  = null;

    private GameObject ButtonsContainer  = null;

    private GameObject SandTimeContainer = null;

    // Bouton de validation  du choix (Oui) de l'application de la fonction de retour 
    private Button button_validate_y;
     
    // Bouton de validation du choix  (Non) de l'application de la fonction de retour 
    private Button button_validate_n;
   
    // Bouton retour en arriere 
    private Button button_back;
    public Button Button_back { get { return button_back; } set { button_back = value; } }

    // Bouton retour en avant 
    private Button button_forward;
    public Button Button_forward { get { return button_forward; } set { button_forward = value; } }

    private Text  txt_percent_amount;

    private Slider slider_time;

    public Slider Slider_time { get { return slider_time; } set { slider_time = value; } }

    public BackwardInTimeView()
    { }

    internal void OnAwake()
    {
        // Récupération des gameobjects
        MessageContainer  = GameObject.FindGameObjectWithTag("BackwardContainer");
        ButtonsContainer  = GameObject.FindGameObjectWithTag("BackwardContainerUR");
        SandTimeContainer = GameObject.FindGameObjectWithTag("SandTimeContainer");

        // Récupération des boutons
        button_validate_y = GameObject.FindGameObjectWithTag("buttonValidateYesBK").GetComponent<Button>() as Button;
        button_validate_n = GameObject.FindGameObjectWithTag("buttonValidateNoBK").GetComponent<Button>()  as Button;
        button_back       = GameObject.FindGameObjectWithTag("buttonBackU").GetComponent<Button>()         as Button;
        button_forward    = GameObject.FindGameObjectWithTag("buttonForwR").GetComponent<Button>()         as Button;

        // Récupération du Text
        txt_percent_amount = GameObject.FindGameObjectWithTag("PercentAmout").GetComponent<Text>()         as Text;

        // Récupération du Slider
        slider_time        = SandTimeContainer.GetComponent<Slider>() as Slider;

        // Désactivation des gameobjects 
        ActivateSandTimeContainer  (false);
        ActivateChoiceMenuContainer(false);

        // Binding des events
        button_validate_y.onClick.AddListener(() => ValidateBackwardYClicked(this, new EventArgs()));
        button_validate_n.onClick.AddListener(() => ValidateBackwardNClicked(this, new EventArgs()));
        button_back      .onClick.AddListener(() => BackClicked(this, new EventArgs()));
        button_forward   .onClick.AddListener(() => ForwardClicked(this, new EventArgs()));

        slider_time.onValueChanged.AddListener((float value) => SliderChanged(value, this, new EventArgs())) ;
    }

    /// <summary>
    /// Permet de déclencher l'action validation du choix 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ValidateBackwardYClicked(object sender, EventArgs e)
    {
        MessageContainer.SetActive(false);

        if (OnValidateBackwardYes != null)
            OnValidateBackwardYes(sender, new EventArgs());
    }

    /// <summary>
    /// Permet de déclencher l'action validation du choix 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ValidateBackwardNClicked(object sender, EventArgs e)
    {
        MessageContainer.SetActive(false);

        if (OnValidateBackwardNo != null)
            OnValidateBackwardNo(sender, new EventArgs());
    }

    /// <summary>
    /// Permet de déclencher l'action de retour en arriere 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void BackClicked(object sender, EventArgs e)
    {
        if (OnBackwarded != null)
            OnBackwarded(sender, new EventArgs());
    }

    /// <summary>
    /// Permet de déclencher l'action de retour en avant 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ForwardClicked(object sender, EventArgs e)
    {
        if (OnForwarded != null)
            OnForwarded(sender, new EventArgs());
    }

    /// <summary>
    /// Permet de déclencher l'action si le slider à changé de valeur
    /// </summary>
    /// <param name="value"> valeur de progression du slider </param>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void SliderChanged(float value, object sender, EventArgs e)
    {
        txt_percent_amount.text = Mathf.RoundToInt(value * 100) + "%";
        if (OnSliderChanged != null)
            OnSliderChanged(value, sender, new EventArgs());
    }
    
    /// <summary>
    /// Fonction Permettant d'activer/désactiver les panel contenant le menu de dialogue
    /// </summary>
    /// <param name="value"></param>
    internal void ActivateChoiceMenuContainer(bool value)
    {
        MessageContainer.SetActive(value);
    }

    /// <summary>
    /// Fonction Permettant d'activer/désactiver les panel contenant les boutons Undo / Redo est 
    /// le slider du sable du temps
    /// </summary>
    /// <param name="value"></param>
    internal void ActivateSandTimeContainer(bool value)
    {
        SandTimeContainer.SetActive(value);
        ButtonsContainer .SetActive(value);
    }

    /// <summary>
    /// Fonction permettant d'activer/désactiver l'interaction les boutons Undo/Redo
    /// </summary>
    /// <param name="isUndoPossible"></param>
    /// <param name="isRedoPossible"></param>
    internal void ButtonsURInteraction(bool isUndoPossible, bool isRedoPossible)
    {
        Button_back.interactable    = isUndoPossible;
        Button_forward.interactable = isRedoPossible;
    }

    /// <summary>
    /// Décharge les listeners des boutons
    /// </summary>
    internal void OnDestroy()
    { 
        button_validate_y.onClick.RemoveAllListeners();
        button_validate_n.onClick.RemoveAllListeners();
        button_back      .onClick.RemoveAllListeners();
        button_forward   .onClick.RemoveAllListeners();
        slider_time.onValueChanged.RemoveAllListeners();
    }
}

