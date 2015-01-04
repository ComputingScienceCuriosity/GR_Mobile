using Assets.Workspace.MVC.Controllers;
using Assets.Workspace.MVC.Models;
using Assets.Workspace.MVC.Views;
using Microsoft.Practices.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class BackwardInTimeController : Controller
{
    [Dependency]
    private BackwardInTimeView backwardInTimeView   { get; set; }

    [Dependency]
    private BackwardInTimeModel backwardInTimeModel { get; set; }
    
    [Dependency]
    private User player { get; set; }

    // Donnée du model permettant de mettre à jour son Coroutine
    public bool isModelCoroutineInvoked    = false;

    // Pointeur vers la Coroutine du model
    public URoutine backTimeModelRoutine = null;

    // Constructeur(s)
    public BackwardInTimeController(BackwardInTimeView _backwardInTimeView, BackwardInTimeModel _backwardInTimeModel, User _player)
    {
        backwardInTimeView  = _backwardInTimeView;
        backwardInTimeModel = _backwardInTimeModel;
        player              = _player;
    }

    /// <summary>
    /// Init du VM
    /// </summary>
    public void OnAwake()
    {
        backwardInTimeView .OnAwake();
        backwardInTimeModel.OnAwake();
    }

    /// <summary>
    /// Chargement dans  la liste d'invocations du delegate
    /// </summary>
    public void OnStart()
    {
        backTimeModelRoutine = new URoutine(backwardInTimeModel.WaitForRate); 
        
        backwardInTimeModel.player = player;

        backwardInTimeView.OnBackwarded          += BackwardedButtonClicked;
        backwardInTimeView.OnForwarded           += ForwardedButtonClicked;
        backwardInTimeView.OnValidateBackwardYes += ValidateBackwardClickedYes;
        backwardInTimeView.OnValidateBackwardNo  += ValidateBackwardClickedNo;
        backwardInTimeView.OnSliderChanged       += SliderValueChanged;
    }

    /// <summary>
    /// Mise à jour en boucle
    /// </summary>
    public void OnUpdate()
    {
        isModelCoroutineInvoked = backwardInTimeModel.isCoroutineInvoked;
        backwardInTimeModel.OnUpdate();
        backwardInTimeView.ButtonsURInteraction(player.isUndoPossible(), player.isRedoPossible());
    }

    /// <summary>
    /// Fonction permettant de désactiver la coroutine du model 
    /// </summary>
    public void DisableModelRoutine()
    {
        isModelCoroutineInvoked = false; 
        backTimeModelRoutine -= backwardInTimeModel.WaitForRate;
    }

    /// <summary>
    /// Une fois que la vue à lancé la fonction, le model (BackwardInTimeModel) sera mis à jour
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ValidateBackwardClickedYes(object sender, EventArgs e)
    {
       
        // Ici on lance le choix des command
        backwardInTimeView.ActivateSandTimeContainer(true);
        // Fait le chargement du sable du temps avec la scroll bar

    }

    /// <summary>
    /// Une fois que la vue à lancé la fonction, le model (BackwardInTimeModel) sera mis à jour
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ValidateBackwardClickedNo(object sender, EventArgs e)
    {
        backwardInTimeView.ActivateSandTimeContainer(false);
        GameObject LimitGo = GameObject.FindGameObjectWithTag("Limit");
        LimitGo.GetComponent<Limit>().SetChoice(true);
    }

    /// <summary>
    /// Une fois que la vue à lancé la fonction, le model (BackwardInTimeModel) sera mis à jour
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ForwardedButtonClicked(object sender, EventArgs e)
    {
        if (player.isRedoPossible())
        {
            player.Redo(1);
            backwardInTimeView.Slider_time.value -= (1.0f / (float)(player.CurrentIndex * 3));
        }
    }

    /// <summary>
    /// Une fois que la vue à lancé la fonction, le model (BackwardInTimeModel) sera mis à jour
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void BackwardedButtonClicked(object sender, EventArgs e)
    {
        if (player.isUndoPossible())
        {
            player.Undo(1);
            backwardInTimeView.Slider_time.value -= (1.0f / (float)(player.CurrentIndex * 3));
        }
    }

    private void SliderValueChanged(float value, object sender, EventArgs e)
    {
        if (value <= (1.0f / (float)(player.CurrentIndex * 3)))
        {
            backwardInTimeView.ActivateSandTimeContainer(false);
            --GlobalVariables.Instance.backwardNumber;
            GlobalVariables.Instance.isPaused = false;
            backwardInTimeModel.Character.pauseCommand = false;
        }
    }

    public void ActivateViewContainer(bool value)
    {
        backwardInTimeView.ActivateChoiceMenuContainer(value);
    }

    /// <summary>
    /// Décharger la fonction de la liste d'invocations du delegate
    /// </summary>
    public void OnDestroy()
    {
        backwardInTimeView.OnBackwarded          -= BackwardedButtonClicked;
        backwardInTimeView.OnForwarded           -= ForwardedButtonClicked;
        backwardInTimeView.OnValidateBackwardYes -= ValidateBackwardClickedYes;
        backwardInTimeView.OnValidateBackwardNo  -= ValidateBackwardClickedNo;
        backwardInTimeView.OnDestroy();
    }

}

