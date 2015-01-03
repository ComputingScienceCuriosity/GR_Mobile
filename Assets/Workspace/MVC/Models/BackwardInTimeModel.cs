using Assets.Workspace.MVC.Models;
using Microsoft.Practices.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class BackwardInTimeModel : Model
{
    // définition d'un rate de collection des commands en secondes
    private float backwardFrameRate = 5.0f;

    internal User player {get; set;}

    private GameCommand.GameCommandElements cmdElts;

    private ThirdPersonController character = null;

    public ThirdPersonController Character { get { return character; } }

    private Transform characterTransform = null;

    internal bool isCoroutineInvoked = false;

    public BackwardInTimeModel()
    {

	}

    internal void OnAwake()
    {
       
    }

    internal void OnUpdate() 
    {
        if (Input.GetKeyUp(KeyCode.Z))
        {
            player.Undo(1);
        }

        if (Input.GetKeyUp(KeyCode.Y))
        {
            player.Redo(1);
        }

        if (Input.GetKeyUp(KeyCode.R))
            GlobalVariables.Instance.isPaused = true;
	}

    /// <summary>
    /// Coroutine permettant de faire un Collect chaque 'backwardFrameRate' secondes 
    /// </summary>
    /// <returns></returns>
    internal IEnumerator WaitForRate()
    {
        isCoroutineInvoked = true;
        if(player != null) gameCollect();
        yield return new WaitForSeconds(backwardFrameRate);
        Debug.Log("5 seconds elapsed");
        isCoroutineInvoked = false;
    }

    /// <summary>
    /// Récupéres l'ensemble des élements du jeu en mémoire pour l'utilisation dans le command
    /// </summary>
    private void gameCollect()
    {
        cmdElts               = new GameCommand.GameCommandElements();
        cmdElts.Score         = GlobalVariables.Instance.LevelScore;
        cmdElts.Time          = GlobalVariables.Instance.currentTime;
        character             = GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdPersonController>() 
                                                                                        as ThirdPersonController;
        characterTransform    = GameObject.FindGameObjectWithTag("Player").transform;
        cmdElts.Characterpos  = characterTransform.position;
        cmdElts.CharacterRot  = characterTransform.rotation;

        // TODO: A REVOIR COMMENT PASSER LE TRANSFORM SEULEMENT pos & rot
        cmdElts.CharTransform = characterTransform;
        player.Apply(cmdElts);
        Debug.Log("Commande will be executed here");
    }
}

