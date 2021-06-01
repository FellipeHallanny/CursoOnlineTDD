using System;
using Bogus;
using CursoOnline.Dominio.Cursos;
using CursoOnline.Dominio.Enum;
using CursoOnline.DominioTest._Builders;
using CursoOnline.DominioTest._Util;
using Moq;
using Xunit;

namespace CursoOnline.DominioTest.Cursos
{
    public class ArmazenadorDeCursoTest
    {
        private readonly Dominio.Cursos.CursoDTO _cursoDTO;
        private readonly Mock<Dominio.Cursos.ICursoRepositorio> _cursoRepositorioMock;
        private readonly Dominio.Cursos.ArmazenadorDeCurso _armazenadorDeCurso;

        public ArmazenadorDeCursoTest()
        {
            var fake = new Faker();

            _cursoDTO = new Dominio.Cursos.CursoDTO
            {
                Nome = fake.Random.Words(),
                Descricao = fake.Lorem.Paragraph(),
                CargaHoraria = fake.Random.Double(20, 100),
                PublicoAlvo = "Estudante",
                Valor = fake.Random.Double(1000, 2000)
            };

            _cursoRepositorioMock = new Mock<Dominio.Cursos.ICursoRepositorio>();
            _armazenadorDeCurso = new Dominio.Cursos.ArmazenadorDeCurso(_cursoRepositorioMock.Object);
        }

        [Fact]
        public void DeveAdicionarCurso()
        {
            _armazenadorDeCurso.Armazenar(_cursoDTO);


            _cursoRepositorioMock.Verify(r => r.Adicionar(
                It.Is<Curso>(
                    c => c.Nome == _cursoDTO.Nome &&
                         c.Descricao == _cursoDTO.Descricao
                )
                ));
        }

        [Fact]
        public void NaoDeveAdicionarCursoComONomeDeUmJaSalvo()
        {
            var cursoSalvo = CursoBuilder.Novo().ComNome(_cursoDTO.Nome).Build();
            _cursoRepositorioMock.Setup(r => r.ObterPeloNome(_cursoDTO.Nome)).Returns(cursoSalvo);


            Assert.Throws<ArgumentException>(() => _armazenadorDeCurso.Armazenar(_cursoDTO)).ComMensagem("Nomde do curso já existe");
        }

        [Fact]
        public void NaoDeveInformaPublicoAlvoInvalido()
        {
            var publicoAlvoInvalido = "Médico";

            _cursoDTO.PublicoAlvo = publicoAlvoInvalido;

            Assert.Throws<ArgumentException>(() => _armazenadorDeCurso.Armazenar(_cursoDTO)).ComMensagem("Publico Alvo inválido!");

        }
    }
}
