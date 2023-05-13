using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;

namespace BasicOpenTK
{
    public sealed class VertexArray : IDisposable
    {
        private bool disposed;

        public readonly int VertexArrayHandle;
        public readonly VertexBuffer VertexBuffer;

        public VertexArray(VertexBuffer vertexBuffer)
        {
            disposed = false;

            if(vertexBuffer is null) throw new ArgumentNullException(nameof(vertexBuffer));
            VertexBuffer = vertexBuffer;

            int vertexSizeInBytes = VertexBuffer.VertexInfo.SizeInBytes;

            this.VertexArrayHandle = GL.GenVertexArray();
            GL.BindVertexArray(VertexArrayHandle);

            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBuffer.VertexBufferHandle);

            foreach (var attr in VertexBuffer.VertexInfo.VertexAttributes)
            {
                GL.VertexAttribPointer(attr.Index, attr.ComponentCount, VertexAttribPointerType.Float, false, vertexSizeInBytes, attr.Offset);
                GL.EnableVertexAttribArray(attr.Index);
            }

            GL.BindVertexArray(0);
        }

        ~VertexArray()
        {
            this.Dispose();
        }

        public void Dispose()
        {
            if (disposed) return;
            disposed = true;

            GL.BindVertexArray(0);
            GL.DeleteVertexArray(VertexArrayHandle);
            GC.SuppressFinalize(this);
        }
    }
}
