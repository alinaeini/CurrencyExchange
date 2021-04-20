using System;

namespace CurrencyExchange.Application.Utilities.Design_Patterns.Creational_Design_Patterns.AbstractFactory
{
    public class AbstractFactory
    {
        public interface IButton
        {
            void Paint();
        }

        public class OSXButton : IButton // Executes fourth if OS:OSX
        {
            public void Paint() => System.Console.WriteLine("I'm an OSXButton");
        }

        public class WinButton : IButton // Executes fourth if OS:WIN
        {
            public void Paint()
            {
                System.Console.WriteLine("I'm a WinButton");
            }
        }

        public interface IGUIFactory
        {
            IButton CreateButton();
        }

        public class OSXFactory : IGUIFactory // Executes third if OS:OSX
        {
            IButton IGUIFactory.CreateButton()
            {
                return new OSXButton();
            }
        }

        public class WinFactory : IGUIFactory // Executes third if OS:WIN
        {
            IButton IGUIFactory.CreateButton()
            {
                return new WinButton();
            }
        }

        public class Application
        {
            public Application(IGUIFactory factory)
            {
                IButton button = factory.CreateButton();
                button.Paint();
            }
        }

        public class ApplicationRunner
        {
            static IGUIFactory CreateOsSpecificFactory() // Executes second
            {
                // Contents of App{{Not a typo|.}}Config associated with this C# project
                //<?xml version="1.0" encoding="utf-8" ?>
                //<configuration>
                // <appSettings>
                // <!-- Uncomment either Win or OSX OS_TYPE to test -->
                // <add key="OS_TYPE" value="Win" />
                // <!-- <add key="OS_TYPE" value="OSX" /> -->
                // </appSettings>
                //</configuration>
                string sysType = "Get(OS_TYPE)"; // sample Code
                if (sysType == "Win")
                {
                    return new WinFactory();
                }
                else
                {
                    return new OSXFactory();
                }
            }

            static void Main(string[] args) // Executes first
            {
                new Application(CreateOsSpecificFactory());
                Console.ReadLine();
            }
        }
    }
}