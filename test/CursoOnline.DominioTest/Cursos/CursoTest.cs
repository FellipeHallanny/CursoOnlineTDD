using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CursoOnline.DominioTest.Cursos
{
    public class CursoTest
    {
        [Fact]
        public void DeveCriarCurso()
        {
            string nome = "Informatica básica";
            double cargaHoraria = 80;
            string publicoAlvo = "Estudante";
            double valor = 950;

            var curso = new Curso(nome, cargaHoraria, publicoAlvo, valor);

            Assert.Equal(nome, curso.Nome);
            Assert.Equal(cargaHoraria, curso.CargaHoraria);
            Assert.Equal(publicoAlvo, curso.PublicoAlvo);
            Assert.Equal(valor, curso.Valor);

        }
    }

    internal class Curso
    {
        public Curso(string nome, double cargaHoraria, string publicoAlvo, double valor)
        {
            Nome = nome;
            CargaHoraria = cargaHoraria;
            PublicoAlvo = publicoAlvo;
            Valor = valor;
        }

        public string Nome { get; private set; }
        public double CargaHoraria { get; private set; }
        public string PublicoAlvo { get; private set; }
        public double Valor { get; private set; }
    }
}
