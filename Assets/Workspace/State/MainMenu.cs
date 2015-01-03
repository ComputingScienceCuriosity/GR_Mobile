using UnityEngine;
using System.Collections;
using Microsoft.Practices.Unity;

public class MainMenu : State 
{
    /// <summary>
    /// Objet permettant de faire l'injection de dépendences et l'inversion du controle
    /// </summary>
    private UnityContainer container;

    /// <summary>
    /// Composant utilisant l'injection de dépendences
    /// </summary>
    private MenuController MainMenuController;

    /// <summary>
    /// Récupération du contexte de l'état courant
    /// </summary>
    /// <param name="Context"></param>
    public override void Handle(StateContext Context)
    {
        Context.State = new MainMenu();
    }

    /// <summary>
    /// Attachement des composants
    /// </summary>
    public override void OnEnter()
    {
        container = new UnityContainer();

        #region Injection
        // MainMenu Dependency
        container.RegisterType<MenuModel>();
        container.RegisterType<MenuView>();
        #endregion

        #region IOC
        MainMenuController = container.Resolve<MenuController>();
        #endregion

        MainMenuController.OnAwake();
        MainMenuController.OnStart();
    }

    /// <summary>
    /// Détachement des composants
    /// </summary>
    public override void OnExit()
    {
        MainMenuController.OnDestroy();
    }

    /// <summary>
    /// Mise à jour Update
    /// </summary>
    public override void OnUpdate()
    {

    }
}
