using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;

namespace BasicOpenTK
{
    public sealed class IndexBuffer : IDisposable
    {
        public static readonly int MinIndexCount = 1;
        public static readonly int MaxnIndexCount = 250_000;

        private bool disposed;

        public readonly int IndexBufferHandle;
        public readonly int IndexCount;
        public readonly bool IsStatic;

        public IndexBuffer(int indexCount, bool isStatic = true)
        {
            if(indexCount < MinIndexCount ||
                indexCount > MaxnIndexCount)
            {
                throw new ArgumentOutOfRangeException(nameof(IndexCount));
            }
            disposed = false;

            this.IndexCount = indexCount;
            this.IsStatic = isStatic;

            BufferUsageHint hint = BufferUsageHint.StaticDraw;

            if(!this.IsStatic)
            {
                hint = BufferUsageHint.StreamDraw;
            }

            this.IndexBufferHandle = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, this.IndexBufferHandle);
            GL.BufferData(BufferTarget.ElementArrayBuffer, IndexCount * sizeof(int), IntPtr.Zero, hint);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);

        }

        ~IndexBuffer()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (disposed) return;

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
            GL.DeleteBuffer(IndexBufferHandle);

            disposed = true;
            GC.SuppressFinalize(this);
        }
        public void SetData(int[] data, int count)
        {
            if(data is null) throw new ArgumentNullException(nameof(data));
            if(data.Length <= 0) throw new ArgumentOutOfRangeException(nameof(data));
            if(count<=0 || count >this.IndexCount || count>data.Length) throw new ArgumentOutOfRangeException(nameof(count));

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, this.IndexBufferHandle);
            GL.BufferSubData(BufferTarget.ElementArrayBuffer, IntPtr.Zero, count * sizeof(int), data);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer,0);
        }
    }
}
