using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FiapCheckPoint02.WEB.Models
{
    public class Aluno
    {
        [HiddenInput]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }

        [Display(Name = "Sexo")]
        public Sexo? Sexo { get; set; }
        public string? Curso { get; set; }
    }
    public enum Sexo
    {
        Feminino, Masculino, Outros
    }
}
