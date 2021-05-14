using CursoOnline.DominioTest._Util;
using ExpectedObjects;
using System;
using Xunit;

namespace CursoOnline.DominioTest.Cursos
{
    public class CursoTest
    {
        [Fact]
        public void DeveCriarCurso()
        {

            var cursoEsperado = new
            {
                Nome = "Informatica básica",
                CargaHoraria = (double)80,
                PublicoAlvo = EnumPublicoAlvo.Estudante,
                Valor = (double)950
            };


            var curso = new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor);

            cursoEsperado.ToExpectedObject().ShouldMatch(curso);

        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveCursoTerNomeInvalido(string nomeInvalido)
        {

            var cursoEsperado = new
            {
                Nome = "Informatica básica",
                CargaHoraria = (double)80,
                PublicoAlvo = EnumPublicoAlvo.Estudante,
                Valor = (double)950
            };

            Assert.Throws<ArgumentException>(() => new Curso(nomeInvalido, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor)).ComMensagem("Nome Inválido!");

        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void NaoDeveCursoTerUmaCargaHorariaMenorQue1(double cargaHorariaInvalida)
        {
            var cursoEsperado = new
            {
                Nome = "Informatica básica",
                CargaHoraria = (double)80,
                PublicoAlvo = EnumPublicoAlvo.Estudante,
                Valor = (double)950
            };

            Assert.Throws<ArgumentException>(() => new Curso(cursoEsperado.Nome, cargaHorariaInvalida, cursoEsperado.PublicoAlvo, cursoEsperado.Valor)).ComMensagem("Carga Horaria Inválido!");

        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void NaoDeveCursoTerUmaValorMenorQue1(double valorInvalido)
        {
            var cursoEsperado = new
            {
                Nome = "Informatica básica",
                CargaHoraria = (double)80,
                PublicoAlvo = EnumPublicoAlvo.Estudante,
                Valor = (double)950
            };

            Assert.Throws<ArgumentException>(() => new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, valorInvalido)).ComMensagem("Valor Inválido!");

        }

    }

    public enum EnumPublicoAlvo
    {
        Estudante,
        Universitario,
        Empregado,
        Empreendedor
    }

    internal class Curso
    {
        public Curso(string nome, double cargaHoraria, EnumPublicoAlvo publicoAlvo, double valor)
        {

            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("Nome Inválido!");

            if (cargaHoraria < 1)
                throw new ArgumentException("Carga Horaria Inválido!");

            if (valor < 1)
                throw new ArgumentException("Valor Inválido!");

            Nome = nome;
            CargaHoraria = cargaHoraria;
            PublicoAlvo = publicoAlvo;
            Valor = valor;
        }

        public string Nome { get; private set; }
        public double CargaHoraria { get; private set; }
        public EnumPublicoAlvo PublicoAlvo { get; private set; }
        public double Valor { get; private set; }
    }
}
