using UnityEngine;
using System.Collections;

public abstract class Command {

    /// <summary>
    /// Execute une commande à un instant t
    /// </summary>
    public abstract void Execute();

    /// <summary>
    /// Reviens sur la commande à l'instant passé t-1
    /// </summary>
    public abstract void UnExecute();
}
