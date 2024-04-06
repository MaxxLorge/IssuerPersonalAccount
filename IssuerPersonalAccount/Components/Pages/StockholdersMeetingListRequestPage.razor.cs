using IssuerPersonalAccount.Models;

using Microsoft.AspNetCore.Components.Forms;

namespace IssuerPersonalAccount.Components.Pages;

public partial class StockholdersMeetingListRequestPage
{
    private string[] _meetingTypes = new[]
    {
        "Годовое",
        "Внеочередное",
        "Совместное присутствие",
        "Заочное голосование",
    };
    
    private int _currentStep = 1;

    private StockholdersMeetingListRequestModel _model = new();

    private EditContext? _editContext;

    protected override void OnInitialized()
    {
        _editContext = new EditContext(_model);
    }
}