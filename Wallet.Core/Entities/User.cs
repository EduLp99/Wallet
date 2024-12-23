using System.ComponentModel.DataAnnotations;

namespace WalletProject.Core.Entities;

public class User 
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public string Cpf { get; set; }
    public List<WalletUser> Wallets { get; set; }
}