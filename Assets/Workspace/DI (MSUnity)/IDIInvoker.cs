using UnityEngine;
using System.Collections;
using Microsoft.Practices.Unity;

/// <summary>
/// Permet de définir le prototype de déchargement des valeurs d'injections
/// appelé après l'initialisation du DIBootstraper
/// </summary>
public interface IDIInvoker 
{
    /// <summary>
    /// Fait l'inversion du controle et l'appel
    /// des Invoke de chacune des dépendences injectées
    /// </summary>
    void InvokeIOC();
}
