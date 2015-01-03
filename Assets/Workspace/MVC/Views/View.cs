using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Workspace.MVC.Views
{
    /// <summary>
    /// Delegate principal 
    /// </summary>
    /// <param name="sender">object qui envoyé l'événement</param>
    /// <param name="e"> information sur l'evenement </param>
    public delegate void UEventHandler(object sender, EventArgs e);

    /// <summary>
    /// Delegate principal 
    /// </summary>
    /// <param name="value"> valeur float de progression du slider </param>
    /// <param name="sender"> object qui envoyé l'événement </param>
    /// <param name="e"> information sur l'evenement </param>
    public delegate void UEventHandler_slider(float value, object sender, EventArgs e);

    public class View 
    {
         
    }
}
