using CasesControl.Entities;

namespace CasesControl.DTO;

public class ResponseDTO
{
    public ResponseDTO(Case caseEntity)
    {
    }

    public string? Id { get; }
    public string? DataAtendimento { get; set; }
    public string? NumeroCaso { get; set; }
    public string? StatusAtendimento { get; set; }
    public string? NovoStatus { get; set; }
    public string? Tarefas { get; set; }
    public string? Print { get; set; }
    public string? Hora { get; set; }
    public string? Time { get; set; }
}