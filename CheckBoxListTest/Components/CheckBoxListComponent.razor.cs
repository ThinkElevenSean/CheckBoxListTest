using Microsoft.AspNetCore.Components;

namespace CheckBoxListTest.Components
{
    public partial class CheckBoxListComponent
    {
		[Parameter]
        public string? Label { get; set; }

        [Parameter]
        public int? DefaultSelectedIndex { get; set; }

        private void CheckboxClicked(string selectedValue, object? isChecked)
        {
            if (CurrentValue is not null)
            {
                var selectedItem = CurrentValue.FirstOrDefault(x => x.Text.Equals(selectedValue));

                if (selectedItem is not null && isChecked is not null)
                {
                    selectedItem.Selected = (bool)isChecked;
                }

                if (CurrentValue.All(x => !x.Selected) && DefaultSelectedIndex is not null && CurrentValue.Count > DefaultSelectedIndex)
                {
                    CurrentValue[DefaultSelectedIndex.Value].Selected = true;
                }
            }
        }

        protected override bool TryParseValueFromString(string? value, out List<CheckBoxListItem> result, out string validationErrorMessage)
        {
            result = [];
            validationErrorMessage = "";
            return true;
        }
    }
}
