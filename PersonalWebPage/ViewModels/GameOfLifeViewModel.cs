﻿using GameOfLifeLibary.GameForms.GameOfLifeTypes;
using GameOfLifeLibary.TableCreation;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalWebPage.GameOfLife;
using System;
using System.Threading;

namespace PersonalWebPage.ViewModels
{
    public class GameOfLifeViewModel : PageModel
    {
        private string selectedType;
        private Timer timer;
        private TableGenerator tableGenerator = TableGenerator.GetTableGenerator();
        private Action notifyPropertyChangedMethod;

        public int Length = 70;
        public int Width = 150;
        public int TempLength;
        public int TempWidth;
        public int[,] GeneratedTable;
        public int StartingPopulation = 1000;
        public string SelectedForm;
        public bool autoSimulate = false;

        public GameOfLifeViewModel(Action notifyPropertyChanged)
        {
            notifyPropertyChangedMethod = notifyPropertyChanged;
            OnInit();
        }

        public string SelectedType
        {
            get { return selectedType; }
            set
            {
                SelectedForm = null;
                selectedType = value;
            }
        }
        public void OnInit()
        {
            TempLength = Length;
            TempWidth = Width;
            GeneratedTable = tableGenerator.GenrateTableWithPopulation(StartingPopulation, Length, Width);
        }

        public void BtnDecrementLength()
        {
            if (TempLength >= 0)
            {
                TempLength -= 10;
            }
        }

        public void BtnIncrementLength()
        {
            TempLength += 10;
        }

        public void BtnDecrementWidth()
        {
            if (TempWidth >= 0)
            {
                TempWidth -= 10;
            }
        }
        public void BtnIncrementWidth()
        {
            TempWidth += 10;
        }

        public void BtnDecrementStartingPopulation()
        {
            if (StartingPopulation >= 0)
            {
                StartingPopulation -= 100;
            }
        }

        public void BtnIncrementStartingPopulation()
        {
            StartingPopulation += 100;
        }

        public void BtnGeneratePopulationClick()
        {
            Length = TempLength;
            Width = TempWidth;
            GeneratedTable = InitialSpawner.SpawnStarters(StartingPopulation, Length, Width);
            autoSimulate = false;
        }

        public void BtnStopSimulationClick()
        {
            autoSimulate = false;
        }

        public void BtnStartSimulationClick()
        {
            autoSimulate = true;
            if (timer == null)
            {
                timer = new Timer(new TimerCallback(timer =>
                {
                    if (autoSimulate == true)
                    {
                        GeneratedTable = tableGenerator.SimulateNextStep(GeneratedTable);
                        this.notifyPropertyChangedMethod();
                    }
                    else
                    {
                        return;
                    }
                }), null, 300, 300);
            }
        }


        public void BtnStepSimulationClick()
        {
            autoSimulate = false;
            GeneratedTable = tableGenerator.SimulateNextStep(GeneratedTable);
        }

        public void BtnGenerateForm()
        {
            autoSimulate = false;
            int[,] tempTable;
            switch (Enum.Parse<FormTypes>(SelectedType))
            {
                case FormTypes.StillLifes:
                    tempTable = tableGenerator.GenrateTableWithForm(Enum.Parse<StillLifeFormTypes>(SelectedForm));
                    break;
                case FormTypes.Oscillators:
                    tempTable = tableGenerator.GenrateTableWithForm(Enum.Parse<OscillatorFormTypes>(SelectedForm));
                    break;
                case FormTypes.SpaceShips:
                    tempTable = tableGenerator.GenrateTableWithForm(Enum.Parse<SpaceshipFormTypes>(SelectedForm));
                    break;
                case FormTypes.Guns:
                    tempTable = tableGenerator.GenrateTableWithForm(Enum.Parse<GunFormTypes>(SelectedForm));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            Width = tempTable.GetUpperBound(0) + 1;
            Length = tempTable.GetUpperBound(1) + 1;
            GeneratedTable = tempTable;
        }

    }
}
