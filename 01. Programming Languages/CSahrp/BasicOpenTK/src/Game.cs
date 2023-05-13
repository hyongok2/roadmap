using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;


namespace BasicOpenTK
{
    public class Game : GameWindow
    {
        private VertexBuffer vertexBuffer;
        private IndexBuffer indexBuffer;
        private VertexArray vertexArray;
        private ShaderProgram shaderProgram;

        private int vertexCount;
        private int indexCount;

        private float colorFactor = 1f;
        private float deltaColorFactor = 1f/2400;

        public Game(int width = 1280, int height = 768, string title = "Game1") 
            : base(
                  GameWindowSettings.Default, 
                  new NativeWindowSettings()
                  {
                      Title = title,
                      Size = new Vector2i(width, height),
                      WindowBorder = WindowBorder.Fixed,
                      StartVisible = false,
                      StartFocused = true,
                      API = ContextAPI.OpenGL,
                      Profile = ContextProfile.Core,
                      APIVersion = new Version(3,3)
                  })
        {
            this.CenterWindow();
        }

        protected override void OnLoad()
        {
            this.IsVisible = true;

            //GL.ClearColor(new Color4(0.3f,0.4f,0.5f,0.4f));
            GL.ClearColor(0.8f,0.8f,0.8f,1f);

            Random rnd = new Random();

            int windowWidth = ClientSize.X;
            int windowHeight = ClientSize.Y;

            int boxCount = 100;

            VertexPositionColor[] vertices = new VertexPositionColor[boxCount * 4];
            vertexCount = 0;

            for (int i = 0; i < boxCount; i++)
            {
                int w = rnd.Next(32,128);
                int h = rnd.Next(32,128);
                int x = rnd.Next(0, windowWidth-w);
                int y = rnd.Next(0, windowHeight-h);

                float r = (float)rnd.NextDouble();
                float g = (float)rnd.NextDouble();
                float b = (float)rnd.NextDouble();

                vertices[vertexCount++] = new VertexPositionColor(new Vector2(x, y + h), new Color4(r, g, b, 1f));
                vertices[vertexCount++] = new VertexPositionColor(new Vector2(x + w, y + h), new Color4(r, g, b, 1f));
                vertices[vertexCount++] = new VertexPositionColor(new Vector2(x + w, y), new Color4(r, g, b, 1f));
                vertices[vertexCount++] = new VertexPositionColor(new Vector2(x, y), new Color4(r, g, b, 1f));
            }


            int[] indices = new int[boxCount * 6];
            indexCount = 0;
            vertexCount = 0;
            for (int i = 0; i < boxCount; i++)
            {
                indices[indexCount++] = 0 + vertexCount;
                indices[indexCount++] = 1 + vertexCount;
                indices[indexCount++] = 2 + vertexCount;
                indices[indexCount++] = 0 + vertexCount;
                indices[indexCount++] = 2 + vertexCount;
                indices[indexCount++] = 3 + vertexCount;

                vertexCount += 4;
            }


            vertexBuffer = new VertexBuffer(VertexPositionColor.VertexInfo, vertices.Length, true);
            vertexBuffer.SetData(vertices, vertices.Length);

            indexBuffer = new IndexBuffer(indices.Length, true);
            indexBuffer.SetData(indices, indices.Length);

            vertexArray = new VertexArray(vertexBuffer);


            string vertexShaderCode =
                @"
                #version 330 core

                uniform vec2 ViewportSize;                
                uniform float ColorFactor;

                layout (location = 0) in vec2 aPosition;
                layout (location = 1) in vec4 aColor;
                
                out vec4 vColor;
                
                void main()
                {
                    float nx = aPosition.x / ViewportSize.x * 2.0f - 1.0f;
                    float ny = aPosition.y / ViewportSize.y * 2.0f - 1.0f;
                   
                    gl_Position = vec4(nx, ny, 0.0f, 1.0f);
                    vColor = aColor * ColorFactor;
                }
                ";

            string pixelShaderCode =
                @"
                #version 330
                
                in vec4 vColor;

                 out vec4 outputColor;

                 void main()
                   {
                      outputColor = vColor;
                   }
                ";

            shaderProgram = new ShaderProgram(vertexShaderCode, pixelShaderCode);

            int[] viewport = new int[4];

            GL.GetInteger(GetPName.Viewport, viewport);

            shaderProgram.SetUniform("ViewportSize", (float)viewport[2], (float)viewport[3]);
            

            base.OnLoad();
        }

        protected override void OnUnload()
        {
            vertexArray?.Dispose();
            indexBuffer?.Dispose();
            vertexBuffer?.Dispose();
            shaderProgram?.Dispose();

            base.OnUnload();
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            GL.Viewport(0,0,e.Width,e.Height);
            base.OnResize(e);
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            colorFactor += deltaColorFactor;

            if(colorFactor>=1f)
            {
                colorFactor = 1f;
                deltaColorFactor *= -1f;
            }

            if(colorFactor<=0f)
            {
                colorFactor = 0f;
                deltaColorFactor *= -1f;
            }
            shaderProgram.SetUniform("ColorFactor", colorFactor);
            base.OnUpdateFrame(args);
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            GL.UseProgram(shaderProgram.ShaderProgramHandle);

            GL.BindVertexArray(vertexArray.VertexArrayHandle);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, indexBuffer.IndexBufferHandle);
            GL.DrawElements(PrimitiveType.Triangles, indexCount, DrawElementsType.UnsignedInt, 0);

            this.Context.SwapBuffers();
            base.OnRenderFrame(args);
        }


    }
}
