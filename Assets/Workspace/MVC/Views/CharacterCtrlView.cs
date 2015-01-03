using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Assets.Workspace.MVC.Views;

public class CharacterCtrlView : View
{
    /// <summary>
    /// Event du bouton Jump
    /// </summary>
    internal event UEventHandler OnJumpButtonClicked;

    #region ViewComponents

    private Button jumpButton;

    #endregion

    internal void OnAwake()
    {
        jumpButton = GameObject.FindGameObjectWithTag("btnJump").GetComponent<Button>() as Button;
        jumpButton.onClick.AddListener(() => onJumpButtonClicked(this, new EventArgs()));
    }

    internal void onJumpButtonClicked(object sender, EventArgs e)
    {
        if (OnJumpButtonClicked != null)
            OnJumpButtonClicked(sender, e);
    }

    internal void _OnDestroy()
    {
        jumpButton.onClick.RemoveAllListeners();
    }
}
