using DryIoc;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using WpfSheet.Content;
using WpfSheet.Models;
using WpfSheet.Mvvm;

namespace WpfSheet.ViewModels
{
    public sealed class SheetViewModel : ViewModelBase
    {
        private int _healthStat;
        private int _attackStat;
        private int _defenseStat;
        private int _specialAttackStat;
        private int _specialDefenseStat;
        private int _speedStat;
        private Pokemon _selectedPokemon;
        private ObservableCollection<Pokemon> _pokemonSource;
        private int _currentLevel;
        private int _currentExperience;
        private string _nickname;
        private ICommand _calculateExperienceForLevel;
        private ObservableCollection<string> _genders;
        private string _selectedGender;


        #region EXTERNAL PROPERTIES

        public Pokemon SelectedPokemon
        {
            get => _selectedPokemon;
            set => Set(nameof(SelectedPokemon), ref _selectedPokemon, value, HandlePokemonChange);
        }
        public ObservableCollection<Pokemon> PokemonSource
        {
            get => _pokemonSource;
            set => Set(nameof(PokemonSource), ref _pokemonSource, value);
        }

        #endregion EXTERNAL PROPERTIES

        #region SHEET PROPERTIES

        public int HealthStat { get => _healthStat; set => Set(nameof(HealthStat), ref _healthStat, value, others: nameof(MaximumRemainingStatPoints)); }
        public int AttackStat { get => _attackStat; set => Set(nameof(AttackStat), ref _attackStat, value, others: nameof(MaximumRemainingStatPoints)); }
        public int DefenseStat { get => _defenseStat; set => Set(nameof(DefenseStat), ref _defenseStat, value, others: nameof(MaximumRemainingStatPoints)); }
        public int SpecialAttackStat { get => _specialAttackStat; set => Set(nameof(SpecialAttackStat), ref _specialAttackStat, value, others: nameof(MaximumRemainingStatPoints)); }
        public int SpecialDefenseStat { get => _specialDefenseStat; set => Set(nameof(SpecialDefenseStat), ref _specialDefenseStat, value, others: nameof(MaximumRemainingStatPoints)); }
        public int SpeedStat { get => _speedStat; set => Set(nameof(SpeedStat), ref _speedStat, value, others: nameof(MaximumRemainingStatPoints)); }
        public int CurrentLevel { get => _currentLevel; set => Set(nameof(CurrentLevel), ref _currentLevel, value, others: nameof(MaximumRemainingStatPoints)); }
        public int CurrentExperience { get => _currentExperience; set => Set(nameof(CurrentExperience), ref _currentExperience, value); }
        public string Nickname { get => _nickname; set => Set(nameof(Nickname), ref _nickname, value, others: nameof(DisplayName)); }
        public string DisplayName => !string.IsNullOrWhiteSpace(Nickname) ? $"{Nickname} ({SelectedPokemon.Name})" : SelectedPokemon.Name;
        public int MaximumRemainingStatPoints { get => CalculateRemainingStatPoints(); }
        public ObservableCollection<string> Genders { get => _genders; set => Set(nameof(Genders), ref _genders, value); }
        public string SelectedGender { get => _selectedGender; set => Set(nameof(SelectedGender), ref _selectedGender, value); }

        #endregion SHEET PROPERTIES

        #region COMMANDS

        public ICommand CalculateExperienceForLevel { get => _calculateExperienceForLevel; set => Set(nameof(CalculateExperienceForLevel), ref _calculateExperienceForLevel, value); }

        #endregion COMMANDS


        public SheetViewModel()
        {
            // Container will probably be NULL in design time
            if (Container is null) return;
            PokemonSource = Container.Resolve<PokemonCollection>()?.Pokemon;
            SelectedPokemon = PokemonSource.FirstOrDefault();


            // Create commands
            CalculateExperienceForLevel = new RelayCommand(SetExperienceForLevel);

        }





        private int CalculateRemainingStatPoints()
        {
            var maxPoints = ResourceHandler.CalculateAvailablePoints(CurrentLevel);
            return maxPoints - (HealthStat + AttackStat + DefenseStat + SpecialAttackStat + SpecialDefenseStat + SpeedStat);
        }


        private void SetExperienceForLevel()
        {
            CurrentExperience = ResourceHandler.GetExperienceForLevel(CurrentLevel);
        }



        private void HandlePokemonChange()
        {
            // Force the nickname field to update itself
            OnPropertyChanged(nameof(Nickname));
            OnPropertyChanged(nameof(DisplayName));
            Genders = new ObservableCollection<string>(ResourceHandler.RetrievePokemonGenders(SelectedPokemon));
            SelectedGender = Genders.First();
        }



    }
}
