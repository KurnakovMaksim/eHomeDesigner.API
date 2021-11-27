﻿using eHomeDesigner.Application.Interfaces.POCOs.Devices;
using System;

namespace eHomeDesigner.Application.POCOs.Devices
{
    public class Computer : IDevice
    {
        public Guid Id { get; }

        public string Type => GetType().Name;

        public int Price { get; }
        public int SquareMeters { get; }
        public int EnergyPerHour { get; }

        public string Author { get; }


        private const int DAY = 24;
        private const double COMPUTER_ENERGY_PERCENTAGE = 0.3;

        public Computer(
                   Guid id,
                   int price,
                   int squareMeters,
                   int energyPerHour,
                   string author
               )
        {
            Id = id;
            Price = price;
            SquareMeters = squareMeters;
            EnergyPerHour = energyPerHour;
            Author = author;
        }

        public int CalculateEnergyPerDay(int days)
        {
            int energy = (EnergyPerHour * DAY) * days;
            return energy;
        }

        public int CalculateEnergyPrice(int energy)
        {
            int price = (int)(energy * COMPUTER_ENERGY_PERCENTAGE);
            return price;
        }
    }
}