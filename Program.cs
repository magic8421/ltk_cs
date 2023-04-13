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
            var surface = SDL.SDL_GetWindowSurface(wnd);
            var img = SDL_image.IMG_Load("1.png");
            if (img == IntPtr.Zero)
            {
                Console.WriteLine("IMG_Load fail");
                return;
            }
            SDL.SDL_BlitSurface(img, IntPtr.Zero, surface, IntPtr.Zero);
            SDL.SDL_UpdateWindowSurface(wnd);

            bool quit = false;
            SDL.SDL_Event e;

            while (!quit)
            {
                while (SDL.SDL_PollEvent(out e) != 0)
                {
                    if (e.type == SDL.SDL_EventType.SDL_QUIT)
                    {
                        quit = true;
                        break;
                    }
                    else if (e.type == SDL.SDL_EventType.SDL_KEYDOWN)
                    {
                        ProcessKey(e.key.keysym.sym);
                    }
                }
            }
            SDL.SDL_FreeSurface(img);
            SDL.SDL_DestroyWindow(wnd);

            SDL_image.IMG_Quit();
            SDL.SDL_Quit();


            Console.WriteLine("Press any key to exit...");
        }

        static void ProcessKey(SDL.SDL_Keycode code)
        {
            switch(code)
            {
                case SDL.SDL_Keycode.SDLK_w:
                    Console.WriteLine("Key W");
                    break;
                case SDL.SDL_Keycode.SDLK_a:
                    Console.WriteLine("Key A");
                    break;
                case SDL.SDL_Keycode.SDLK_s:
                    Console.WriteLine("Key S");
                    break;
                case SDL.SDL_Keycode.SDLK_d:
                    Console.WriteLine("Key D");
                    break;
            }
        }
    }
}
