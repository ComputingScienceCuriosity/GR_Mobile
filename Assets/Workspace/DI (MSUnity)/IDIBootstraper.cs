using UnityEngine;
using System.Collections;
using Microsoft.Practices.Unity;

/// <summary>
/// Script permettant de définir le prototype de chargement des dépendences
/// </summary>
public interface IDIBootstraper
{
    /// <summary>
    ///  Charges l'ensemble des dépendences dans le container 
    /// </summary>
    /// <param name="container"> UnityContainer </param>
    void Configure(IUnityContainer container);
}
