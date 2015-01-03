using UnityEngine;
using System.Collections;
using System;
using Microsoft.Practices.Unity;
using Assets.Workspace.MVC.Models;

public class CharacterCtrlModel : Model  
{
    public static class Mouvements
    {
        /// <summary>
        /// Enum permettant de définir la position horizontal du personnage
        /// </summary>
        public enum PlayerHorizontalDirection
        { 
            none    = -2,
            left    = -1,
            right   =  1,
            middle  =  0,
        }public static PlayerHorizontalDirection etatMenusBoutons;
    }

    private ThirdPersonController character;

    /// <summary>
    /// Récupération de l'instance  
    /// </summary>
    internal void OnAwake(ThirdPersonController _character)
    {
        character = _character;
    }

    /// <summary>
    /// Saut
    /// </summary>
    internal void Jump()
    {
       
        character.lastJumpButtonTime = Time.time;
    }

    /// <summary>
    /// Met le personnage en pause
    /// </summary>
    internal void Pause()
    {
        if (character.pauseCommand)
            character.pauseCommand = false;
        else
            character.pauseCommand = true;
    }

    /// <summary>
    /// Déplacement latéral
    /// </summary>
    /// <param name="direction"></param>
    internal void Move(int direction, ThirdPersonController _character)
    {
        _character.newhDir  = direction;
        _character.newZdest = -direction;
    }
}

