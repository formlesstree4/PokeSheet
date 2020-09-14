using DryIoc;
using System.Collections.ObjectModel;
using System.Linq;
using WpfSheet.Models;

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



        // public string DisplayName => 


        public Pokemon SelectedPokemon { get => _selectedPokemon; set => Set(nameof(SelectedPokemon), ref _selectedPokemon, value, nameof(DisplayName)); }
        public ObservableCollection<Pokemon> PokemonSource { get => _pokemonSource; set => Set(nameof(PokemonSource), ref _pokemonSource, value); }
        public int HealthStat { get => _healthStat; set => Set(nameof(HealthStat), ref _healthStat, value); }
        public int AttackStat { get => _attackStat; set => Set(nameof(AttackStat), ref _attackStat, value); }
        public int DefenseStat { get => _defenseStat; set => Set(nameof(DefenseStat), ref _defenseStat, value); }
        public int SpecialAttackStat { get => _specialAttackStat; set => Set(nameof(SpecialAttackStat), ref _specialAttackStat, value); }
        public int SpecialDefenseStat { get => _specialDefenseStat; set => Set(nameof(SpecialDefenseStat), ref _specialDefenseStat, value); }
        public int SpeedStat { get => _speedStat; set => Set(nameof(SpeedStat), ref _speedStat, value); }
        public int CurrentLevel { get => _currentLevel; set => Set(nameof(CurrentLevel), ref _currentLevel, value); }
        public int CurrentExperience { get => _currentExperience; set => Set(nameof(CurrentExperience), ref _currentExperience, value); }
        public string Nickname { get => _nickname; set => Set(nameof(Nickname), ref _nickname, value, nameof(DisplayName)); }
        public string DisplayName => !string.IsNullOrWhiteSpace(Nickname) ? $"{Nickname} ({SelectedPokemon.Name})" : SelectedPokemon.Name;


        public SheetViewModel()
        {
            // Container will probably be NULL in design time
            if (Container is null) return;
            PokemonSource = Container.Resolve<PokemonCollection>()?.Pokemon;
            SelectedPokemon = PokemonSource.FirstOrDefault();
        }


    }
}
