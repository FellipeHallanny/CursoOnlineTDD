using System;
using Xunit;

namespace CursoOnline.DominioTest._Util
{
    public static class AssertExtension
    {
        public static void ComMensagem(this ArgumentException exception, string mensagem)
        {
            if (exception.Message.Equals(mensagem))
                Assert.True(true);
            else
                Assert.False(true, $"Esperava a mensagem '{mensagem}'");
        }
    }
}
