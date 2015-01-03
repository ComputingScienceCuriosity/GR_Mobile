using UnityEngine;
using System.Collections;
using Assets.Workspace.MVC.Controllers;
using Microsoft.Practices.Unity;
using Assets.Workspace.MVC.Models;

public class GamePlay : State{

    /// <summary>
    /// Composants utilisant l'injection de dépendences
    /// </summary>
    public CharacterCtrlController  characterCtrlController;

    public BackwardInTimeController backwardInTimeController;

    private TouchJoystickController touchJoystickController;
   
    /// <summary>
    /// Objet permettant de faire l'injection de dépendences et l'inversion du controle
    /// </summary>
    private UnityContainer container;

    /// <summary>
    /// Récupération du contexte de l'état courant
    /// </summary>
    /// <param name="Context"></param>
    public override void Handle(StateContext Context)
    {
        Context.State = new GamePlay();
    }

    /// <summary>
    /// Attachement des composants
    /// </summary>
    public override void OnEnter()
    {
        container = new UnityContainer();

        #region Injection 
        // Character Dependency
        container.RegisterType<CharacterCtrlModel>();
        container.RegisterType<CharacterCtrlView>();
        // Joystick  Dependency
        container.RegisterType<TouchJoystickModel>();
        container.RegisterType<TouchJoystickView>();
        // Backward  Dependency
        container.RegisterType<BackwardInTimeModel>();
        container.RegisterType<BackwardInTimeView>();
        // Command   Dependency 
        container.RegisterType<User>();
        #endregion 

        #region IOC
        // Inversion of control
        characterCtrlController  = container.Resolve<CharacterCtrlController> ();
        touchJoystickController  = container.Resolve<TouchJoystickController> ();
        backwardInTimeController = container.Resolve<BackwardInTimeController>();
        
        var character = FindObjectOfType<ThirdPersonController>() as ThirdPersonController;
        #endregion

        characterCtrlController .OnAwake(character);
        characterCtrlController .OnStart();
        touchJoystickController .OnAwake();
        touchJoystickController .OnStart(character);
        backwardInTimeController.OnAwake();
        backwardInTimeController.OnStart();

    }

    /// <summary>
    /// Détachement des composants
    /// </summary>
    public override void OnExit()
    {
        characterCtrlController .OnDestroy();
        touchJoystickController .OnDestroy();
        backwardInTimeController.OnDestroy();
    }

    /// <summary>
    /// Mise à jour Update
    /// </summary>
    public override void OnUpdate()
    {
        if (touchJoystickController != null)
            touchJoystickController.OnUpdate();

        if ( !backwardInTimeController.isModelCoroutineInvoked 
            && GlobalVariables.Instance.backwardNumber > 0)
        {
            if (backwardInTimeController.backTimeModelRoutine != null)
            StartCoroutine(backwardInTimeController.backTimeModelRoutine.Invoke());
        }

            backwardInTimeController.OnUpdate();
    }
}
