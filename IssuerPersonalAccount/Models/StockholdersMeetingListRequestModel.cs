using System.ComponentModel.DataAnnotations;

namespace IssuerPersonalAccount.Models;

public class StockholdersMeetingListRequestModel
{
    /// <summary>
    /// Список лиц, имеющих право на участие в общем собрании акционеров
    /// </summary>
    public bool EntitledToParticipateInTheGeneralMeetingShareholders { get; set; }

    /// <summary>
    /// Список лиц, осуществляющих права по ценным бумагам
    /// </summary>
    public bool ExercisingSecuritiesRights { get; set; }

    /// <summary>
    /// Список лиц, имеющих право на участие в общем собрании акционеров,  без персональных данных и данных о волеизъявлении для ознакомления
    /// </summary>
    public bool EntitledToParticipateInTheGeneralMeetingShareholdersWithoutPersonalData { get; set; }

    /// <summary>
    /// Дата определения фиксации лиц
    /// </summary>
    [Required(ErrorMessage = "Необходимо выбрать дату")]
    public DateOnly? PersonsFixationDate { get; set; }

    
    public string? CustomSmiIssuer { get; set; }

    [Required]
    public string Number { get; set; } = null!;

    [Required(ErrorMessage = "Необходимо выбрать дату")]
    public DateOnly? DecisionDate { get; set; }
}