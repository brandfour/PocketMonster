﻿using MonsterStore;
using PocketBattle.Game;
using PocketBattle.Players;
using System;
using System.Collections.Generic;
using System.Text;

namespace PocketBattle.ServiceLocator
{
    public class ServiceLocator : IServiceLocator
    {
        // map that contains pairs of interfaces and
        // references to concrete implementations
        private IDictionary<object, object> services;

        public ServiceLocator()
        {
            services = new Dictionary<object, object>();

            // fill the map
            this.services.Add(typeof(IGameController), new GameController());
            this.services.Add(typeof(IPlayer), new BasicAI());
            this.services.Add(typeof(BaseMonsterFactory), new RandomMonsterCardFactory());
        }

        public T GetService<T>()
        {
            try
            {
                return (T)services[typeof(T)];
            }
            catch (KeyNotFoundException)
            {
                throw new Exception("The requested service is not registered");
            }
        }
    }
}
