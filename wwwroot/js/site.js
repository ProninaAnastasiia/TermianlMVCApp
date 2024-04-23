function updateActionUrl() {
    var terminalId = document.getElementById("terminalId").value;
    var form = document.getElementById("myForm");
    form.action = "/terminals/" + terminalId + "/commands";
}
function updateCommandId(input) {
    var selectedOption = input.list.querySelector('option[value="' + input.value + '"]');
    var commandId = selectedOption.getAttribute('data-id');
    document.getElementById('hiddenInput').value = commandId;
}
document.addEventListener('DOMContentLoaded', () => {
    const commandInput = document.getElementById('commandInput');
    const lablesContainer = document.getElementById('lablesContainer');
    const parametersContainer = document.getElementById('parametersContainer');
    const parameterLabels = Array.from(lablesContainer.getElementsByTagName('label'));
    const parameterInputs = Array.from(parametersContainer.getElementsByTagName('input'));

    function clearParametersContainer() {
        parameterLabels.forEach(label => {
            label.style.display = 'none';
        });
        parameterInputs.forEach(input => {
            input.style.display = 'none';
        });
    }

    function updateParameters() {
        clearParametersContainer();
        const selectedCommand = commandInput.value;
        const selectedCommandType = commandTypeData.find(commandType => commandType.name === selectedCommand);

        if (selectedCommandType) {
            const parameterCount = Object.keys(selectedCommandType).filter(key => key.startsWith('parameter_name')).length;

            for (let i = 1; i <= parameterCount; i++) {
                const parameterLabel = parameterLabels[i - 1];
                const parameterInput = parameterInputs[i - 1];

                const parameterName = selectedCommandType['parameter_name' + i];
                const parameterDefaultValue = selectedCommandType['parameter_default_value' + i];

                if (parameterName !== null) {
                    parameterLabel.textContent = parameterName;
                    parameterLabel.style.display = 'flex';
                    parameterInput.style.display = 'flex';
                    parameterInput.value = parameterDefaultValue;
                }
            }
        }

        if (selectedCommandType && Object.keys(selectedCommandType).some(key => key.startsWith('parameter_name') && selectedCommandType[key] !== null)) {
            lablesContainer.style.display = 'flex';
            parametersContainer.style.display = 'flex';
        } else {
            lablesContainer.style.display = 'none';
            parametersContainer.style.display = 'none';
        }
    }

    commandInput.addEventListener('change', updateParameters);
    updateParameters();
});