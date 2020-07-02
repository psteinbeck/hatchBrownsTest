using System;
using Autofac;
namespace hatchBrownsTest.iOS
{
    public class Bootstrapper: hatchBrownsTest.Bootstrapper
    {
        protected override void Initialize()
        {
            base.Initialize();

            ContainerBuilder.RegisterType<PhotoImporter>().As<IPhotoImporter>().SingleInstance();
        }
    }
}
