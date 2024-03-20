using SDL2;

class Program
{
    static void Main(string[] args)
    {
        if (SDL.SDL_Init(SDL.SDL_INIT_EVERYTHING) < 0) // 전부 초기화
        {
            Console.WriteLine("Init fail");
            return;
        }

        IntPtr myWindow = SDL.SDL_CreateWindow("2D Engine", 100, 100, 640, 480, SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN); // "타이틀", 위치, 위치, 크기, 크기, 화면에 그리게함

        IntPtr myRenderer = SDL.SDL_CreateRenderer(myWindow, -1, SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED | SDL.SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC | SDL.SDL_RendererFlags.SDL_RENDERER_TARGETTEXTURE); // 화면에 그릴 붓 만들기? 그래픽 카드 기능들 PRESENTVSYNC 모니터 주파수 맞추기

        SDL.SDL_Event myEvent;
        bool isRunning = true;
        while (isRunning)
        {
            SDL.SDL_PollEvent(out myEvent);
            switch (myEvent.type)
            {
                case SDL.SDL_EventType.SDL_QUIT:
                    isRunning = false;
                    break;
            }

            // command
            SDL.SDL_SetRenderDrawColor(myRenderer, 255, 255, 255, 255);
            SDL.SDL_RenderClear(myRenderer); // 화면 지우기

            // 랜덤 100씩
            Random random = new Random();
            for (int i = 0; i < 50000; i++)
            {
                byte r = (byte)random.Next(1, 256);
                byte g = (byte)random.Next(1, 256);
                byte b = (byte)random.Next(1, 256);
                byte a = (byte)random.Next(1, 256);

                SDL.SDL_Rect myRect = new SDL.SDL_Rect();

                myRect.x = random.Next(0, 640);
                myRect.y = random.Next(0, 480);
                myRect.w = random.Next(0, 640);
                myRect.h = random.Next(0, 480);

                SDL.SDL_SetRenderDrawColor(myRenderer, r, g, b, a);
                SDL.SDL_RenderFillRect(myRenderer, ref myRect);

            }
                // execute
                SDL.SDL_RenderPresent(myRenderer);
        }
    }
}

