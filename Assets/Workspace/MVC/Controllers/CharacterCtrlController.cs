using UnityEngine;
using System.Collections;
using Assets.Workspace.MVC.Controllers;
using Microsoft.Practices.Unity;

public class CharacterCtrlController : Controller
{
    [Dependency]
    private CharacterCtrlModel characterCtrlModel { get; set; }

    [Dependency]
    private CharacterCtrlView characterCtrlView     { get; set; }

    public CharacterCtrlController(CharacterCtrlModel _characterCtrlModel, CharacterCtrlView _characterCtrlView)
    {
        characterCtrlModel = _characterCtrlModel;
        characterCtrlView  = _characterCtrlView;
    }

    // Init du VM
    public void OnAwake(ThirdPersonController _character)
    {
        characterCtrlModel.OnAwake(_character);
        characterCtrlView .OnAwake();


    }

    /// <summary>
    /// Chargement dans  la liste d'invocations du delegate
    /// </summary>
    public void OnStart()
    {
        characterCtrlView.OnJumpButtonClicked += JumpButtonClicked;
    }

    // <summary>
    /// Une fois que la vue à lancé la fonction, le model (characterCtrlModel) sera mis à jour à partir du controlleur
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void JumpButtonClicked(object sender, System.EventArgs e)
    {
        characterCtrlModel.Jump();
    }

    public void PauseModel()
    {
        characterCtrlModel.Pause();
    }

    /// <summary>
    /// Décharger la fonction de la liste d'invocations du delegate
    /// </summary>
    public void OnDestroy()
    {
        characterCtrlView.OnJumpButtonClicked -= JumpButtonClicked;

        characterCtrlView._OnDestroy();
    }

}
