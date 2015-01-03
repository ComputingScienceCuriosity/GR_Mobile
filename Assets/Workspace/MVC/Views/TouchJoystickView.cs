using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
using Assets.Workspace.MVC.Views;

/// <summary>
/// Class de la vue du joystick controller, ce dernier peut étre utilisé facilement sans avoir besoin à faire un déplacement à chaque frame 
/// ou d'utiliser les hitTest avec les guitextures | fait pour le déplacement horizontal
/// </summary>
/// <param name="eventData"></param>
/// <param name="sender"></param>
/// <param name="e"></param>
public class TouchJoystickView : View
{
    /// <summary>
    /// Évenement lié au joystick de déplacement 
    /// </summary>
    internal event EventHandler OnJoystickInRightDirection;

    /// <summary>
    /// Évenement lié au joystick de déplacement 
    /// </summary>
    internal event EventHandler OnJoystickInLeftDirection;

    /// <summary>
    /// Évenement lié au joystick de déplacement 
    /// </summary>
    internal event EventHandler OnJoystickInMiddleDirection;


    // trigger de la partie droite
    internal EventTrigger rightJoyButtonTrigger;

    // trigger de la partie gauche
    private EventTrigger leftJoyButtonTrigger;

    // définit si le pointeur est en haut 
    private bool isPointerUp = false;

    // définit si le pointeur est hors zone d'intéraction
    private bool isPointerOut = false;

    // Recttransform du joystick pour récupérer la taille du joy par rapport au canvas
    private RectTransform joyRect;
            
    // position par défault du joystick
    private float defaultHPosition;

    // Getters / Setters
    internal RectTransform JoyRect { get { return joyRect; } set { joyRect = value; } }

    internal float DefaultHPosition { get { return defaultHPosition; } set { defaultHPosition = value; } }

    internal void OnStart(RectTransform _joyRect, float _defaultHPosition)
    {
        // Récupération des composantes EventTrigger
        rightJoyButtonTrigger = GameObject.FindGameObjectWithTag("rightJoyButton").GetComponent<EventTrigger>() as EventTrigger;
        leftJoyButtonTrigger  = GameObject.FindGameObjectWithTag("leftJoyButton") .GetComponent<EventTrigger>() as EventTrigger;

        // ajout interne de l'action Enter
        AddEventTrigger(RightJoyButtonEnter,    EventTriggerType.PointerEnter,  rightJoyButtonTrigger);

        // ajout interne de l'action Enter
        AddEventTrigger(LeftJoyButtonEnter,     EventTriggerType.PointerEnter,  leftJoyButtonTrigger);

        // ajout interne de l'action Exit
        AddEventTrigger(RightJoyButtonExit,     EventTriggerType.PointerExit,   rightJoyButtonTrigger);

        // ajout interne de l'action Exit
        AddEventTrigger(LeftJoyButtonExit,      EventTriggerType.PointerExit,   leftJoyButtonTrigger);

        // ajout interne de l'action Up
        AddEventTrigger(RightJoyButtonUp,       EventTriggerType.PointerUp,     rightJoyButtonTrigger);

        // ajout interne de l'action Up
        AddEventTrigger(LeftJoyButtonUp,        EventTriggerType.PointerUp,     leftJoyButtonTrigger);
    
        // récupération du RectTransform à partir du modele 
        joyRect = _joyRect;

        // récupération de la position à partir du modele 
        defaultHPosition = _defaultHPosition;
    }

    /// <summary>
    /// Fonction qui permet d'ajouter une Action à un composant, est ajouté la callback en question  
    /// </summary>
    /// <param name="action"></param>
    /// <param name="triggerType"></param>
    /// <param name="eventTrigger"></param>
    private void AddEventTrigger(UnityAction<BaseEventData> action, EventTriggerType triggerType, EventTrigger eventTrigger)
    {
        EventTrigger.TriggerEvent trigger = new EventTrigger.TriggerEvent();

        // binding du listener 
        trigger.AddListener((eventData) => action(eventData));

        EventTrigger.Entry entry = new EventTrigger.Entry() { callback = trigger, eventID = triggerType };
        eventTrigger.delegates.Add(entry);
    }

    #region ensemble des listeners
    /// <summary>
    /// L'utilisateur a levé son doight du bouton virtuel droite 
    /// </summary>
    /// <param name="eventData"></param>
    private void RightJoyButtonUp(BaseEventData eventData)
    {
        isPointerUp = true;
        joyRect.position = new Vector3(defaultHPosition - JoyRect.rect.width, JoyRect.position.y, JoyRect.position.z);

        JoystickInMiddleDirection(new EventArgs());
    }

    /// <summary>
    /// L'utilisateur a levé son doight du bouton virtuel gauche 
    /// </summary>
    /// <param name="eventData"></param>
    private void LeftJoyButtonUp(BaseEventData eventData)
    {
        isPointerUp = true;
        joyRect.position = new Vector3(defaultHPosition + joyRect.rect.width, joyRect.position.y, joyRect.position.z);

        JoystickInMiddleDirection(new EventArgs());
    }

    /// <summary>
    /// L'utilisateur a entré son doight du bouton virtuel gauche 
    /// </summary>
    /// <param name="eventData"></param>
    private void LeftJoyButtonEnter(BaseEventData eventData)
    {
        isPointerUp  = false;
        isPointerOut = false;
        joyRect.position = new Vector3(defaultHPosition - joyRect.rect.width, JoyRect.position.y, joyRect.position.z);
        
        // On déclenche l'action
        JoystickInLeftDirection(new EventArgs());
    }

    /// <summary>
    /// L'utilisateur a entré son doight du bouton virtuel droite 
    /// </summary>
    /// <param name="eventData"></param>
    private void RightJoyButtonEnter(BaseEventData eventData)
    {
        isPointerUp  = false;
        isPointerOut = false;
        joyRect.position = new Vector3(defaultHPosition + joyRect.rect.width, joyRect.position.y, joyRect.position.z);
        
        // On déclenche l'action 
        JoystickInRightDirection(new EventArgs());
    }


    /// <summary>
    /// L'utilisateur a fait sortir son doight du bouton virtuel droite 
    /// </summary>
    /// <param name="eventData"></param>
    private void LeftJoyButtonExit(BaseEventData eventData)
    {
        isPointerOut = true;
        joyRect.position = new Vector3(defaultHPosition, joyRect.position.y, joyRect.position.z);
        
        // On déclenceh l'action 
        JoystickInMiddleDirection(new EventArgs());
    }

    /// <summary>
    /// L'utilisateur a fait sortir son doight du bouton virtuel droite 
    /// </summary>
    /// <param name="eventData"></param>
    private void RightJoyButtonExit(BaseEventData eventData)
    {
        isPointerOut = true;
        joyRect.position = new Vector3(defaultHPosition, joyRect.position.y, joyRect.position.z);
 
        JoystickInMiddleDirection(new EventArgs());
    }
    #endregion 

    #region ensemble des actions 

    internal void JoystickInRightDirection(EventArgs e)
    {
        if (OnJoystickInRightDirection != null)
            OnJoystickInRightDirection(this, e);
    }

    internal void JoystickInLeftDirection(EventArgs e)
    {
        if (OnJoystickInLeftDirection != null)
            OnJoystickInLeftDirection(this, e);
    }

    internal void JoystickInMiddleDirection(EventArgs e)
    {
        if (OnJoystickInMiddleDirection != null)
            OnJoystickInMiddleDirection(this, e);
    }
    #endregion 

    /// <summary>
	/// Remise du Joystick au milieu 
	/// </summary>
    internal void OnUpdate() 
    {
        if (isPointerOut || isPointerUp)
        {
            joyRect.position = new Vector3(defaultHPosition, joyRect.position.y, joyRect.position.z);
        }
	}
}
