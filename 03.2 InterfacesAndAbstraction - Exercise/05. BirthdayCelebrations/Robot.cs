﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayCelebrations
{
    public class Robot 
    {

        public Robot(string model, string id)
        {
            Model = model;
            Id = id;
        }
        public string Model { get; set; }
        public string Id { get; set; }
    }
}
