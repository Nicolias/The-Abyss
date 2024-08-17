﻿using Zenject;

public class MenuInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<SaveLoader>().FromNew().AsSingle();
    }
}
