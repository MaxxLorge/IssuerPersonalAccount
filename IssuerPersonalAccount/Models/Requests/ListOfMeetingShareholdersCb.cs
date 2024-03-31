using System.Text.Json.Serialization;

namespace IssuerPersonalAccount.Models.Requests;

public class ListOfMeetingShareholdersCb
{
    public string ReportName => nameof(ListOfMeetingShareholdersCb);

    public bool IsSaveToStorage => true;

    public int IssuerId { get; set; }

    //Нужен метод для регистрации, пока давайте константу 1/ИСХ
    public string RegOutInfo => "1/ИСХ";

    public string GeneralReportHeader { get; set; }
    
    /// <summary>
    /// Дата начала периода, на который готовится отчет в формате yyyy-MM-dd
    /// </summary>
    public DateOnly DtMod { get; set; }

    /// <summary>
    /// Раскрывать списки НД
    /// </summary>
    public bool NomList { get; set; }

    /// <summary>
    /// Группировать эмитентов по подразделениям
    /// </summary>
    public bool IsPodr => false;

    /// <summary>
    /// Отображать количество ЦБ и голосов
    /// </summary>
    public bool ViewCb => true;

    /// <summary>
    /// Группировать выпуски ЦБ по категории
    /// </summary>
    public bool IsCateg => false;

    /// <summary>
    /// Отображать нераскрытых НД одной строкой
    /// </summary>
    public bool IsOneRecAllNomin { get; set; }

    /// <summary>
    /// Вид и форма собрания
    /// <remarks>true - годовое, false - внеочередное</remarks>
    /// </summary>
    public bool IsCategMeeting { get; set; }

    /// <summary>
    /// Вид и форма собрания
    /// <remarks>true - годовое, false - внеочередное</remarks>
    /// </summary>
    public bool IsRangeMeeting { get; set; }

    /// <summary>
    /// Выбираемая дата для годового или внеочередного собрания
    /// <remarks>Дата проведения собрания с формы</remarks>
    /// </summary>
    [JsonPropertyName("Dt_Begsobr")]
    public DateOnly DtBegsobr { get; set; }

    /// <summary>
    /// Сокращенная форма отчета
    /// </summary>
    public bool IsSocr => false;

    /// <summary>
    /// Печатать номер ЛС для клиентов НД
    /// </summary>
    public bool IsFillSchNd => false;

    /// <summary>
    /// Печатать дату рождения
    /// </summary>
    public bool IsBirthday => false;

    /// <summary>
    /// Печатать телефоны
    /// </summary>
    public bool IsViewPhone => true;
    
    /// <summary>
    /// Печатать e-mail
    /// </summary>
    public bool IsViewEmail => true;

    /// <summary>
    /// Печатать способ доведения Сообщения об ОСА
    /// </summary>
    public bool IsViewMeetNotify => true;

    /// <summary>
    /// Добавление подписи ген. дир-а
    /// </summary>
    public bool IsViewGenDirect => false;

    public bool IsViewInn => false;

    public bool ViewLs => false;

    public bool IsSignBox => false;

    public bool OfNumbers => false;

    public bool IsExcelFormat => false;

    public bool PrintDt => false;

    public string CurrentUser => "LK";

    public string Operator => "Кузнецов А.С";

    public bool IsViewDirect => false;

    public bool IsViewCtrl => false;

    public bool IsViewElecStamp => true;
    
    /// Нужен метод для регистрации, пока давайте просто произвольный GUID
    public Guid Guid => Guid.NewGuid();
}