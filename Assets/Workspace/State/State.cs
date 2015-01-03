using UnityEngine;
using System.Collections;

public abstract class State : MonoBehaviour
{
    /// <summary>
    /// Crée une référence vers l'objet qui implémente state 
    /// </summary>
    /// <param name="Context"></param>
    public abstract void Handle(StateContext Context);

    /// <summary>
    /// Appelé lors de l'ouverture du state 
    /// </summary>
    public abstract void OnEnter();

    /// <summary>
    /// Appelé lors de la fermeture/changement du state
    /// </summary>
    public abstract void OnExit();
    
    /// <summary>
    /// Appelé pour mettre à jour le Update du state
    /// </summary>
    public abstract void OnUpdate();


}
