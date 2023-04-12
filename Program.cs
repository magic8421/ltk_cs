using System;
using SDL2;

namespace ltk_cs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            SDL.SDL_SetHint(SDL.SDL_HINT_WINDOWS_DISABLE_THREAD_NAMING, "1");
            if (SDL.SDL_Init(SDL.SDL_INIT_VIDEO) < 0)
            {
                Console.WriteLine("SDL_Init fail");
                return;
            }
            var wnd = SDL.SDL_CreateWindow("Hello", 40, 40, 800, 600, SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN);
            if (wnd == IntPtr.Zero)
            {
                Console.WriteLine("SDL_CreateWindow fail");
                return;
            }
            var img_flags = SDL_image.IMG_InitFlags.IMG_INIT_PNG;
            if (SDL_image.IMG_Init(img_flags) != (int)img_flags)
            {
                Console.WriteLine("IMG_Init fail");
                return;
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }
    }
}
