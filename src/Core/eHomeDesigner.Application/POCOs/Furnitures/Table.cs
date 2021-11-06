﻿using eHomeDesigner.Application.Interfaces.POCOs.Furnitures;
using System;

namespace eHomeDesigner.Application.POCOs.Furnitures
{
    public class Table : IFurniture
    {
        public Guid Id { get; }

        public int Price { get; }
        public int SquareMeters { get; }

        public Table(Guid id, int price, int squareMeters)
        {
            Id = id;
            Price = price;
            SquareMeters = squareMeters;
        }
    }
}
