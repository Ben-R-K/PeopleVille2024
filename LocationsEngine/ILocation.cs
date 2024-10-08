﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationsEngine
{
    public interface ILocation
    {
        public string Name { get; }

        /// <summary>
        /// The max amount of people that can be in this location.
        /// </summary>
        public int MaxPopulation { get; }
    }
}
