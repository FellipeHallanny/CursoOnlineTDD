using System;
using CursoOnline.Dominio.Cursos;
using CursoOnline.Dominio.Enum;
using Moq;
using Xunit;

namespace CursoOnline.DominioTest.Cursos
{
    public class ArmazenadorDeCursoTest
    {
        [Fact]
        public void DeveAdicionarCurso()
        {
            var cursoDTO = new CursoDTO
            {
                Nome = "Curso A",
                Descricao = "Descricao",
                CargaHoraria = 80,
                PublicoAlvo = 1,
                Valor = 850.00
            };

            var cursoRepositorioMock = new Mock<ICursoRepositorio>();

            var armazenadorDeCurso = new ArmazenadorDeCurso(cursoRepositorioMock.Object);

            armazenadorDeCurso.Armazenar(cursoDTO);

            cursoRepositorioMock.Verify(r => r.Adicionar(It.IsAny<Curso>()));
        }

        public interface ICursoRepositorio
        {
            void Adicionar(Curso curso);
        }

        public class ArmazenadorDeCurso
        {
            private readonly ICursoRepositorio _cursoRepositorio;

            public ArmazenadorDeCurso(ICursoRepositorio cursoRepositorio)
            {
                _cursoRepositorio = cursoRepositorio;
            }

            internal void Armazenar(CursoDTO cursoDTO)
            {
                var curso = new Curso(cursoDTO.Nome, cursoDTO.Descricao, cursoDTO.CargaHoraria,
                    EnumPublicoAlvo.Estudante, cursoDTO.Valor);

                _cursoRepositorio.Adicionar(curso);
            }
        }

        public class CursoDTO
        {
            public string Nome { get; set; }
            public string Descricao { get; set; }
            public int CargaHoraria { get; set; }
            public int PublicoAlvo { get; set; }
            public double Valor { get; set; }
        }
    }
}
