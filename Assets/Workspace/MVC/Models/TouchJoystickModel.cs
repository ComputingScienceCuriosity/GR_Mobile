using UnityEngine;
using System.Collections;
using Assets.Workspace.MVC.Models;

/// <summary>
/// Class représentant le modele du joystick
/// </summary>
public class TouchJoystickModel : Model
{
    // Recttransform du joystick pour récupérer la taille du joy par rapport au canvas
    private RectTransform joyRect;

    // position par défault du joystick
    private float defaultHPosition;

    #region setters/getters
    // Rectangle du joystick
    public RectTransform JoyRect { get { return joyRect; } set { joyRect = value;} }

    // Position horizontal par défault (position initiale du joystick dans la partie milieu)
    public float DefaultHPosition { get { return defaultHPosition; } set { defaultHPosition = value;} }
    #endregion 

    internal void OnStart()
    {
        joyRect = GameObject.FindGameObjectWithTag("Joystick").GetComponent<RectTransform>() as RectTransform;
        defaultHPosition = joyRect.position.x;
    }
}
