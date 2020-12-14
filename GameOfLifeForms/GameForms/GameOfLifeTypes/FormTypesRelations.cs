using System;
using System.Collections.Generic;

namespace GameOfLifeLibary.GameForms.GameOfLifeTypes
{
    public static class FormTypesRelations
    {
        public static Dictionary<FormTypes, Type> FormTypesRelationsDict = new Dictionary<FormTypes, Type>()
        {
            {FormTypes.StillLifes, typeof(StillLifeFormTypes)},
            {FormTypes.Oscillators, typeof(OscillatorFormTypes)},
            {FormTypes.SpaceShips, typeof(SpaceshipFormTypes)},
            {FormTypes.Guns, typeof(GunFormTypes)}
        };
    }
}
