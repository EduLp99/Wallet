namespace WalletProject.Application.InputModels;

public class CreateUserInputModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public string Cpf { get; set; }
}