using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using PtaSheet3.Core.Models;
using PtaSheet3.Services.Interfaces;
using System.Collections.ObjectModel;

namespace PtaSheet3.Modules.AbilityEditor.ViewModels
{
    public class AbilityEditorViewModel : BindableBase, IRegionMemberLifetime
    {
        private readonly IAbilityDataProvider abilityDataProvider;
        private readonly IWindowProvider windowProvider;
        private Ability selectedAbility;

        public bool KeepAlive => false;


        public Ability SelectedAbility
        {
            get => selectedAbility;
            set
            {
                SetProperty(ref selectedAbility, value);
                if (selectedAbility is null)
                {
                    windowProvider.SetWindowTitle($"Ability Editor (no ability selected)");
                }
                else
                {
                    windowProvider.SetWindowTitle($"Ability Editor ({selectedAbility.Name})");
                }
            }
        }

        public ObservableCollection<Ability> Abilities
        {
            get => abilityDataProvider.RetrieveAbilities().Abilities;
        }


        public DelegateCommand AddNewAbilityCommand { get; private set; }



        public AbilityEditorViewModel(
            IAbilityDataProvider abilityDataProvider,
            IWindowProvider windowProvider)
        {
            windowProvider.SetWindowTitle("Ability Editor");
            this.abilityDataProvider = abilityDataProvider;
            this.windowProvider = windowProvider;
            AddNewAbilityCommand = new DelegateCommand(AddNewAbility);
        }



        private void AddNewAbility()
        {
            var ability = new Ability
            {
                Name = "New Ability"
            };
            Abilities.Add(ability);
            SelectedAbility = ability;
        }

    }
}
