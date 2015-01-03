using UnityEngine;
using System.Collections;
using Microsoft.Practices.Unity;
using System;

public class DInjectionInvoker : DInjectionBootstraper, IDIInvoker 
{
    public IUnityContainer _container;
    /// <summary>
    /// Appel le Invoke après le chargement des injections 
    /// </summary>
    
    //MVCInitialiser rfInitMVC;

    public override void Awake()
    {
        this._container = gameObject.GetComponent<DInjectionBootstraper>().container as IUnityContainer;
        this.InvokeIOC();
    }

    public override void Start()
    {
    }

    /// <summary>
    /// Fait l'inversion du controle et l'appel
    /// des Invoke de chacune des dépendences injectées
    /// </summary>
    public virtual void InvokeIOC()
    {
        //MenuController ctrl = _container.Resolve<MenuController>();
       // rfInitMVC = this._container.Resolve<MVCInitialiser>();
       // rfInitMVC._Awake();
    }

    public override void Update()
    {

       // rfInitMVC._Update();
    }

}
