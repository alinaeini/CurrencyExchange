using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyExchange.Application.Utilities.Design_Patterns.Creational_Design_Patterns.Factory_Method
{
    public class FactoryMethodSample
    {
        /// <summary>
        /// allows adherence to the Open/closed principle and makes the final product more flexible in the event of change.
        /// </summary>

        // Empty vocabulary of actual object
        public interface IPerson
        {
            string GetName();
        }

        public class Villager : IPerson
        {
            public string GetName()
            {
                return "Village Person";
            }
        }

        public class CityPerson : IPerson
        {
            public string GetName()
            {
                return "City Person";
            }
        }

        public enum PersonType
        {
            Rural,
            Urban
        }

        // create Factory
        public interface IFactory
        {
             IPerson GetPerson(PersonType type);
        }
        /// <summary>
        /// Implementation of Factory - Used to create objects.
        /// ConcreteCreator  Factory
        /// </summary>
        public class Factory:IFactory
        {
            public IPerson GetPerson(PersonType type)
            {
                switch (type)
                {
                    case PersonType.Rural:
                        return new Villager();
                    case PersonType.Urban:
                        return new CityPerson();
                    default:
                        throw new NotSupportedException();
                }
            }
            

        }
    }
}
