﻿using Dereck_RPG.entities.bases;
using Dereck_RPG.entities.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dereck_RPG.entities
{
    public class Regions : BaseDBEntity
    {
        private String name;
        private Climate climate;
        private List<Donjon> donjon;

        public List<Donjon> Donjon
        {
            get { return donjon; }
            set { donjon = value; }
        }

        public Climate Climate
        {
            get { return  climate; }
            set {  climate = value; }
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

    }
}
