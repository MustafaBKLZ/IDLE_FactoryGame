using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace IDLE_FactoryGame
{
    class Resources
    {
        static public List<string> ActiveMaterialList = new List<string>();
        public static void ComputeResource()
        {
            Machines.Machine.Calculate_PowerProductandFund();
            Machines.Machine.Calculate_ProductandFund();
        }
    }
    class MyResource
    {
        private static double _POWER = 0;
        public static double POWER
        {
            get { return _POWER; }
            set { _POWER = value; }
        }
        private static double _COAL = 0;
        public static double COAL
        {
            get { return _COAL; }
            set { _COAL = value; }
        }
        private static double _IRON_ORE = 0;
        public static double IRON_ORE
        {
            get { return _IRON_ORE; }
            set { _IRON_ORE = value; }
        }
        private static double _IRON_INGOT = 0;
        public static double IRON_INGOT
        {
            get { return _IRON_INGOT; }
            set { _IRON_INGOT = value; }
        }
        private static double _IRON_PLATE = 0;
        public static double IRON_PLATE
        {
            get { return _IRON_PLATE; }
            set { _IRON_PLATE = value; }
        }
        private static double _IRON_BEAM = 0;
        public static double IRON_BEAM
        {
            get { return _IRON_BEAM; }
            set { _IRON_BEAM = value; }
        }
        private static double _COPPER_ORE = 0;
        public static double COPPER_ORE
        {
            get { return _COPPER_ORE; }
            set { _COPPER_ORE = value; }
        }
        private static double _COPPER_INGOT = 0;
        public static double COPPER_INGOT
        {
            get { return _COPPER_INGOT; }
            set { _COPPER_INGOT = value; }
        }
        private static double _CONDUCTING_WIRE = 0;
        public static double CONDUCTING_WIRE
        {
            get { return _CONDUCTING_WIRE; }
            set { _CONDUCTING_WIRE = value; }
        }
        private static double _COPPER_ROD = 0;
        public static double COPPER_ROD
        {
            get { return _COPPER_ROD; }
            set { _COPPER_ROD = value; }
        }
        private static double _IRON_ROD = 0;
        public static double IRON_ROD
        {
            get { return _IRON_ROD; }
            set { _IRON_ROD = value; }
        }
        private static double _IRON_SCREW = 0;
        public static double IRON_SCREW
        {
            get { return _IRON_SCREW; }
            set { _IRON_SCREW = value; }
        }
        private static double _COPPER_PLATE = 0;
        public static double COPPER_PLATE
        {
            get { return _COPPER_PLATE; }
            set { _COPPER_PLATE = value; }
        }
        private static double _STONE = 0;
        public static double STONE
        {
            get { return _STONE; }
            set { _STONE = value; }
        }
        private static double _STONE_BLOCK = 0;
        public static double STONE_BLOCK
        {
            get { return _STONE_BLOCK; }
            set { _STONE_BLOCK = value; }
        }
        private static double _MAGNET = 0;
        public static double MAGNET
        {
            get { return _MAGNET; }
            set { _MAGNET = value; }
        }
        private static double _COIL = 0;
        public static double COIL
        {
            get { return _COIL; }
            set { _COIL = value; }
        }
    }
}
