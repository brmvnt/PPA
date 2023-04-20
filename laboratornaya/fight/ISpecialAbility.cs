using System;
namespace age_of_war
{
    public interface ISpecialAbility
    {
        public SAEnumeration Ability { get; }
        public int range { get; }
        public void Action(ISpecialAbility special, Army army1, Army army2, int i, int j) { }
    }
}
