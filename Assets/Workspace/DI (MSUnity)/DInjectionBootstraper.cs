using UnityEngine;
using System.Collections;
using Microsoft.Practices.Unity;

public class DInjectionBootstraper : MonoBehaviour, 
    IDIBootstraper
{
    // Injection container
    public IUnityContainer container;

    public virtual void Awake()
    {
        this.container = new UnityContainer();
        this.Configure(container);
        this.gameObject.AddComponent<DInjectionInvoker>();
        DontDestroyOnLoad(this);
    }

    public virtual void Start() 
    {

    }

    public virtual void Update()
    {

    }

    /// <summary>
    ///  Charges l'ensemble des dépendences dans le container 
    /// </summary>
    /// <param name="container"> UnityContainer </param>
    public virtual void Configure(IUnityContainer container)
    {
        //container.RegisterType<MVCInitialiser>();

    }  
}
