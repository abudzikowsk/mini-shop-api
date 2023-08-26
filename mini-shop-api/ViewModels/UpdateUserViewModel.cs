using System.ComponentModel.DataAnnotations;

namespace MiniShopApi.ViewModels;

public class UpdateUserViewModel
{
    [MaxLength(255)]
    public string Name { get; set; }
    
    [MaxLength(255)]
    public string Surname { get; set; }
}