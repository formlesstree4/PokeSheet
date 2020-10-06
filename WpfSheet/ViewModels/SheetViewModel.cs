using DryIoc;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using WpfSheet.Content;
using WpfSheet.Models;
using WpfSheet.Mvvm;

namespace WpfSheet.ViewModels
{
    public sealed partial class SheetViewModel : ViewModelBase
    {
        private Pokemon _selectedPokemon;
        private ObservableCollection<Pokemon> _pokemonSource;
        private int _currentLevel;
        private int _currentExperience;
        private string _nickname;
        private ICommand _calculateExperienceForLevel;
        private ObservableCollection<string> _genders;
        private string _selectedGender;
        private ObservableCollection<PokemonType> _pokemonTypes;
        private PokemonType _firstType;
        private PokemonType _secondType;


        #region EXTERNAL PROPERTIES

        public Pokemon SelectedPokemon
        {
            get => _selectedPokemon;
            set => Set(nameof(SelectedPokemon), ref _selectedPokemon, value, HandlePokemonChange, others: new[] { nameof(Nickname), nameof(DisplayName) });
        }

        public ObservableCollection<Pokemon> PokemonSource
        {
            get => _pokemonSource;
            set => Set(nameof(PokemonSource), ref _pokemonSource, value);
        }
        public ObservableCollection<PokemonType> Types
        {
            get => _pokemonTypes;
            set => Set(nameof(Types), ref _pokemonTypes, value);
        }

        #endregion EXTERNAL PROPERTIES

        #region SHEET PROPERTIES
        public int CurrentLevel { get => _currentLevel; set => Set(nameof(CurrentLevel), ref _currentLevel, value, others: new[] { nameof(MaximumRemainingStatPoints), nameof(CurrentStab) }); }
        public int CurrentExperience { get => _currentExperience; set => Set(nameof(CurrentExperience), ref _currentExperience, value, CheckForLevelChange); }
        public string Nickname { get => _nickname; set => Set(nameof(Nickname), ref _nickname, value, others: nameof(DisplayName)); }
        public string DisplayName => !string.IsNullOrWhiteSpace(Nickname) ? $"{Nickname} ({SelectedPokemon.Name})" : SelectedPokemon.Name;
        public ObservableCollection<string> Genders { get => _genders; set => Set(nameof(Genders), ref _genders, value); }
        public string SelectedGender { get => _selectedGender; set => Set(nameof(SelectedGender), ref _selectedGender, value); }
        public int CurrentStab { get => CalculateStab(CurrentLevel); }
        public PokemonType FirstType { get => _firstType; set => Set(nameof(FirstType), ref _firstType, value); }
        public PokemonType SecondType { get => _secondType; set => Set(nameof(SecondType), ref _secondType, value); }
        #endregion SHEET PROPERTIES

        #region COMMANDS

        public ICommand CalculateExperienceForLevel { get => _calculateExperienceForLevel; set => Set(nameof(CalculateExperienceForLevel), ref _calculateExperienceForLevel, value); }

        #endregion COMMANDS



        public SheetViewModel(PokemonCollection p, NatureCollection n, TypesCollection t)
        {
            Types = t.PokemonTypes;
            PokemonSource = p.Pokemon;
            SelectedPokemon = PokemonSource.FirstOrDefault();
            Natures = n.Natures;
            SelectedNature = Natures?.FirstOrDefault();

            // Create commands
            CurrentLevel = 1;
            CalculateExperienceForLevel = new RelayCommand(SetExperienceForLevel);
        }



        private void SetExperienceForLevel()
        {
            CurrentExperience = ResourceHandler.GetExperienceForLevel(CurrentLevel);
        }

        private void CheckForLevelChange()
        {
            var currentLevel = CurrentLevel;
            var currentExperience = CurrentExperience;
            while (true)
            {
                var experienceAtNextLevel = ResourceHandler.GetExperienceForLevel(currentLevel + 1);
                if (experienceAtNextLevel <= currentExperience) currentLevel += 1;
                else break;
            }
            CurrentLevel = currentLevel;
        }

        private void HandlePokemonChange()
        {
            Genders = new ObservableCollection<string>(ResourceHandler.RetrievePokemonGenders(SelectedPokemon));
            SelectedGender = Genders.First();
            FirstType = GetPokemonType(SelectedPokemon.Types.First);
            SecondType = GetPokemonType(SelectedPokemon.Types.Second);
        }

        private int CalculateStab(int level)
        {
            return (int)Math.DivRem((long)level, 5, out _);
        }

        private PokemonType GetPokemonType(string typeName)
        {
            var noneType = Types.First(c => c.Name.Equals("none", StringComparison.OrdinalIgnoreCase));
            if (string.IsNullOrWhiteSpace(typeName)) return noneType;
            return Types.FirstOrDefault(c => c.Name.Equals(typeName, StringComparison.OrdinalIgnoreCase)) ?? noneType;
        }

    }
}
