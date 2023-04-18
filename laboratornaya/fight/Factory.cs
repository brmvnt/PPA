using System;
namespace age_of_war
{
    abstract class Factory
    {
        abstract public Unit Create();
    }

    class LIFactory : Factory
    {
        public override Unit Create()
        {
            return new LightInfantry();
        }
    }
    class HIFactory : Factory
    {
        public override Unit Create()
        {
            return new HeavyInfantry();
        }
    }
    class KFactory : Factory
    {
        public override Unit Create()
        {
            return new Knight();
        }
    }
    class ArrowFactory : Factory
    {
        public override Unit Create()
        {
            return new Arrow();
        }
    }
    class HealerFactory : Factory
    {
        public override Unit Create()
        {
            return new Healer();
        }
    }
    class ClonerFactory : Factory
    {
        public override Unit Create()
        {
            return new Cloner();
        }
    }
}
