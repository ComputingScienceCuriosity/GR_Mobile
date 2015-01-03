using UnityEngine;
using System.Collections;
using Assets.Workspace.MVC.Controllers;
using Microsoft.Practices.Unity;
using System;
using Assets.Workspace.MVC.Views;

/// <summary>
/// Class permettant de controller l'ensemble des mouvements du personnage 
/// </summary>
public class TouchJoystickController : Controller {

    /// <summary>
    /// Instance de CharacterCtrlModel
    /// </summary>
    private CharacterCtrlModel characterCtrlModel { get; set; }

    /// <summary>
    /// Model du joystick
    /// </summary>
    private TouchJoystickModel touchJoystickModel { get; set; }

    /// <summary>
    /// Vue du joystick
    /// </summary>
    private TouchJoystickView touchJoystickView { get; set; }

    private ThirdPersonController character;

    [InjectionConstructor]
    public TouchJoystickController( CharacterCtrlModel _characterCtrlModel, TouchJoystickModel _touchJoystickModel, TouchJoystickView _touchJoystickView)
    {
        characterCtrlModel = _characterCtrlModel;
        touchJoystickModel = _touchJoystickModel;
        touchJoystickView  = _touchJoystickView;
    }

    // Init
    public void OnAwake()
    { 
    
    }

	// Init des données 
	public void OnStart (ThirdPersonController _character) {
        if (touchJoystickModel != null)
            touchJoystickModel.OnStart();
        else 
            Debug.Log("touchModel null");

        character = _character;

        UpdateDataValues();

        if (touchJoystickView  != null)
            touchJoystickView.OnStart(touchJoystickModel.JoyRect, touchJoystickModel.DefaultHPosition);

        touchJoystickView.OnJoystickInRightDirection  += guiJoyRightTouchChanged;
        touchJoystickView.OnJoystickInLeftDirection   += guiJoyLeftTouchChanged;
        touchJoystickView.OnJoystickInMiddleDirection += guiJoyMiddleTouchChanged;
	}

    private void guiJoyMiddleTouchChanged(object sender, EventArgs e)
    {
        characterCtrlModel.Move((int)CharacterCtrlModel.Mouvements.PlayerHorizontalDirection.middle, character);

    }

    private void guiJoyLeftTouchChanged(object sender, EventArgs e)
    {
        characterCtrlModel.Move((int)CharacterCtrlModel.Mouvements.PlayerHorizontalDirection.left, character);
    }

    private void guiJoyRightTouchChanged(object sender, EventArgs e)
    {
        characterCtrlModel.Move((int)CharacterCtrlModel.Mouvements.PlayerHorizontalDirection.right, character);
    }

    private void UpdateDataValues()
    {
        touchJoystickView.JoyRect           = touchJoystickModel.JoyRect;
        touchJoystickView.DefaultHPosition  = touchJoystickModel.DefaultHPosition;
    }

	// Mise à jour 
    public void OnUpdate()
    {
        touchJoystickView.OnUpdate();
	}

    /// <summary>
    /// Détachement 
    /// </summary>
    public void OnDestroy()
    {
        touchJoystickView.OnJoystickInRightDirection  -= guiJoyRightTouchChanged;
        touchJoystickView.OnJoystickInLeftDirection   -= guiJoyLeftTouchChanged;
        touchJoystickView.OnJoystickInMiddleDirection -= guiJoyMiddleTouchChanged;
    }
}
