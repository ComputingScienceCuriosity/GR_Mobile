using UnityEngine;
using System.Collections;

/// <summary>
/// Classe qui sera implémenté par le composant <MVCInitialiser>
/// </summary>
public interface IMVCInitialiser 
{

    /// <summary>
    /// Créer une nouvelle instance de(s) gameobject(s) qui vont étre utilisé par la composante MVC 
    /// </summary>
    void IntializeGO();
    
    /// <summary>
    /// Attache les scripts au(x) gameobject(s) concernés 
    /// </summary>
    void AttachIntializedGO();
}
