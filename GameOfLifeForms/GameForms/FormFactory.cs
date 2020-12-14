using GameOfLifeForms.StillLifeForms;
using GameOfLifeLibary.GameForms.GameOfLifeTypes;
using GameOfLifeLibary.GameForms.GunForms;
using GameOfLifeLibary.GameForms.OscillatorForms;
using GameOfLifeLibary.GameForms.SpaceshipForms;
using GameOfLifeLibary.GameForms.StillLifeForms;
using System;

namespace GameOfLifeForms
{
    public static class FormFactory
    {
        public static Form GenerateStillLifeForm(StillLifeFormTypes FormType)
        {
            switch (FormType)
            {
                case StillLifeFormTypes.Block:
                    return GenerateBlock();
                case StillLifeFormTypes.Beehive:
                    return GenerateBeehive();
                case StillLifeFormTypes.Table:
                    return GenerateTable();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static Form GenerateOscillatorForm(OscillatorFormTypes oscillatorFormType)
        {
            switch (oscillatorFormType)
            {
                case OscillatorFormTypes.Blinker:
                    return GenerateBlinker();
                case OscillatorFormTypes.Toad:
                    return GenerateToad();
                case OscillatorFormTypes.Pulsar:
                    return GeneratePulsar();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static Form GenerateSpaceshipForm(SpaceshipFormTypes spaceshipFormType)
        {
            switch (spaceshipFormType)
            {
                case SpaceshipFormTypes.Glider:
                    return GenerateGlider();
                case SpaceshipFormTypes.LightWeightSpaceship:
                    return GenerateLightWeightSpacheship();
                case SpaceshipFormTypes.HeavyWeightSpaceship:
                    return HeavyWeightSpaceship();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static Form GenerateGun(GunFormTypes gunFormType)
        {
            switch (gunFormType)
            {
                case GunFormTypes.GosperGliderGun:
                    return GenerateGosperGliderGun();
                case GunFormTypes.Period22GliderGun:
                    return GeneratePeriod22GliderGun();
                case GunFormTypes.BiGun:
                    return GenerateBiGun();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static Form GenerateBiGun()
        {
            return new BiGun();
        }

        private static Form GeneratePeriod22GliderGun()
        {
            return new Period22GliderGun();
        }

        private static Form GenerateGosperGliderGun()
        {
            return new GosperGliderGun();
        }

        private static Form HeavyWeightSpaceship()
        {
            return new HeavyWeightSpaceship();
        }

        private static Form GenerateLightWeightSpacheship()
        {
            return new LightWeightSpaceship();
        }

        private static Form GenerateGlider()
        {
            return new Glider();
        }

        private static Form GenerateToad()
        {
            return new Toad();
        }

        private static Form GeneratePulsar()
        {
            return new Pulsar();
        }

        private static Form GenerateBlinker()
        {
            return new Blinker();
        }

        private static Form GenerateTable()
        {
            return new Table();
        }

        private static Form GenerateBeehive()
        {
            return new Beehive();
        }

        private static Form GenerateBlock()
        {
            return new Block();
        }
    }
}
