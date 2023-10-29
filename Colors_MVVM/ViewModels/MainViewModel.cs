using Colors_MVVM.Commands;
using Colors_MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace Colors_MVVM.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        public ObservableCollection<ColorViewModel> colorCollection { get; set; }
        public ColorViewModel colormod;
        SolidColorBrush backgroundColor;
        public MainViewModel(ColorViewModel colormod)
        {
            colorCollection = new ObservableCollection<ColorViewModel>();
            this.colormod = colormod;
            backgroundColor = colormod.BackgroundColor;
        }
        public ObservableCollection<ColorViewModel> ColorCollection
        {
            get { return colorCollection; }
            set
            {
                if (colorCollection != value)
                {
                    colorCollection = value;
                    OnPropertyChanged(nameof(ColorCollection));
                }
            }
        }
        public byte Alpha
        {
            get { return colormod.Alpha; }
            set
            {
                colormod.Alpha = value;
                OnPropertyChanged(nameof(Alpha));
                UpdateBackgroundColor();
            }
        }
        public byte Red
        {
            get { return colormod.Red; }
            set
            {
                colormod.Red = value;
                OnPropertyChanged(nameof(Red));
                UpdateBackgroundColor();
            }
        } 
        public byte Green
        {
            get { return colormod.Green; }
            set
            {
                colormod.Green = value;
                OnPropertyChanged(nameof(Green));
                UpdateBackgroundColor();
            }
        }
        public byte Blue
        {
            get { return colormod.Blue; }
            set
            {
                colormod.Blue = value;
                OnPropertyChanged(nameof(Blue));
                UpdateBackgroundColor();
            }
        }

        #region Background
        public SolidColorBrush BackgroundColor
        {
            get { return backgroundColor; }
            set
            {
                if (backgroundColor != value)
                {
                    backgroundColor = value;
                    OnPropertyChanged(nameof(BackgroundColor));
                }
            }
        }
        private void UpdateBackgroundColor()
        {
            BackgroundColor = new SolidColorBrush(Color.FromArgb(Alpha, Red, Green, Blue));
        }
        #endregion

        #region Button Add
        private DelegateCommand addColorCommand;
        public ICommand AddColorCommand
        {
            get
            {
                if (addColorCommand == null)
                {
                    addColorCommand = new DelegateCommand(
                        execute: (obj) =>
                        {
                            AddColor(colormod);
                        },
                        canExecute: (obj) =>
                        {
                            return !ColorExists(colormod);
                        }
                    );
                }
                return addColorCommand;
            }
        }
        private bool ColorExists(ColorViewModel colorToCheck)
        {
            return ColorCollection.Any(color => color.ColorValue == colorToCheck.ColorValue);
        }
        private void AddColor(ColorViewModel colorToAdd)
        {
            if (!ColorExists(colorToAdd))
            {
                ColorCollection.Add(colorToAdd.Copy());
            }
        }
        #endregion

        #region Button Delete in ColorCollection
        private DelegateCommand deleteColorCommand;
        public ICommand DeleteColorCommand
        {
            get
            {
                if (deleteColorCommand == null)
                {
                    deleteColorCommand = new DelegateCommand(
                        execute: (obj) =>
                        {
                            if (obj is ColorViewModel colorToDelete)
                            {
                                ColorCollection.Remove(colorToDelete);
                            }
                        }, null);
                }
                return deleteColorCommand;
            }
        }
        #endregion

        #region CheckBox 
        private DelegateCommand isAlphaActive;
        public ICommand IsAlphaActive => isAlphaActive ??= new DelegateCommand(obj => IsAlphaActiveMethod(), null);

        private bool isAlphaSliderActive = true;
        public bool IsAlphaSliderActive
        {
            get { return isAlphaSliderActive; }
            set
            {
                if (isAlphaSliderActive != value)
                {
                    isAlphaSliderActive = value;
                    OnPropertyChanged(nameof(IsAlphaSliderActive));
                }
            }
        }
        private void IsAlphaActiveMethod()
        {
            IsAlphaSliderActive = !IsAlphaSliderActive;
        }

        private DelegateCommand isRedActive;
        public ICommand IsRedActive => isRedActive ??= new DelegateCommand(obj => IsRedActiveMethod(), null);

        private bool isRedSliderActive = true;
        public bool IsRedSliderActive
        {
            get { return isRedSliderActive; }
            set
            {
                if (isRedSliderActive != value)
                {
                    isRedSliderActive = value;
                    OnPropertyChanged(nameof(IsRedSliderActive));
                }
            }
        }
        private void IsRedActiveMethod()
        {
            IsRedSliderActive = !IsRedSliderActive;
        }

        private DelegateCommand isGreenActive;
        public ICommand IsGreenActive => isGreenActive ??= new DelegateCommand(obj => IsGreenActiveMethod(), null);

        private bool isGreenSliderActive = true;
        public bool IsGreenSliderActive
        {
            get { return isGreenSliderActive; }
            set
            {
                if (isGreenSliderActive != value)
                {
                    isGreenSliderActive = value;
                    OnPropertyChanged(nameof(IsGreenSliderActive));
                }
            }
        }
        private void IsGreenActiveMethod()
        {
            IsGreenSliderActive = !IsGreenSliderActive;
        }

        private DelegateCommand isBlueActive;
        public ICommand IsBlueActive => isBlueActive ??= new DelegateCommand(obj => IsBlueActiveMethod(), null);

        private bool isBlueSliderActive = true;
        public bool IsBlueSliderActive
        {
            get { return isBlueSliderActive; }
            set
            {
                if (isBlueSliderActive != value)
                {
                    isBlueSliderActive = value;
                    OnPropertyChanged(nameof(IsBlueSliderActive));
                }
            }
        }
        private void IsBlueActiveMethod()
        {
            IsBlueSliderActive = !IsBlueSliderActive;
        }
        #endregion 
    }
}
