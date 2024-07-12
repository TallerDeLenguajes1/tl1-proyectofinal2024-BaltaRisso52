using System.Security.Cryptography.X509Certificates;
using Mazmorras;
using Monstruos;
using Protagonista;

namespace Funciones
{
  class FuncionesVarias
  {
    public static void MostrarIntro()
    {


      Console.WriteLine(@"

              .+++*****%-                                                                           
              #:.:::--#@@=                                                                          
             %*        .=%#:                                                                        
            @@*           .-=:                                                                      
           :@@#                                  :-:.                                               
           :@@@%=                             =#@#.                                                 
           :=*@@@@%+:                         -@@.                                                  
               -*%@@@@%+-                     :@@                                                   
                  .=*%@@@@%**-                :@%         .                                         
   :                  .=#@@@@.     -:..--     :@%      ----=*-                                      
    :                    :@@@    +#.    -@*.  :@%    +%:    -@%:                                    
     -.                   @@@   %@:      =@%  :@%   #@=      -@@.                                   
      :-.:-               @@@  .@@.      :@@: :@%  .@@-       @@=                                   
         :*@@@*.          @@@   @@=      -@#  :@%   %@##:    :@@.                                   
:-=-:       =%@@*-   ..:-*@@@:  .#@-    .#*   :@@.  .*@@.    ##.                                    
  .*@@%+.    +%@@@%%##+=::----:.  .==----.   .+*#+.   .=+=--=. ..                                   
    +@@@%-                                                 .+#@=                                    
    .@@@:                          .                       -@@+    ::-.                            
     @@@:                         *                         @@=     +=                               
     @@@.                .--=-.  -%        :-=:  .:-==:     @@-            .:=  .-=-.     . ---. .   
     @@@.              -*:    @#.=@:       .%.  +=    #@+   @@-    *@@  :-#@%.---=@@:   +@:   .%@#-.
     @@@.             -@  ....@@@.@@:      +:  %*.....-@@=  @@-    =@@    :@@     +@*  +@%     %@+  
     @@@:             #@  ....... :*@=    -=  :@+.......    @@-    -@@    :@%     =@#  =@@     %@=  
     @@@:           : %@:            +%. :+   :@#           @@-    -@@    :@%     =@%   =%#: .=%-   
     @@@:          -+ +@@-     -    .#@@+*     #@*.    :.   @@:    -@@    :@%     =@%   -+....      
    :@@@*-::::---+%%   .:==+++#@%=    -*@%.     :*%#+++@@#:.@@=    =@@.   -@@     +@@  :@%*++++==-  
  .:---------------.      .....          +%.        ....   :---    ---:   ---:    ---:  +===++++*#%.
                                          -:                                          -@-         +.
                                                                                      =@*-:::::-+=.  ");
      Thread.Sleep(1300);

      string texto = @"            
            ╔════════════════════════════════════════════════════════════════╗
            ║                                                                ║
            ║     ¡Bienvenido a Solo Leveling: La Ascencion del Cazador!     ║
            ║                                                                ║
            ╠════════════════════════════════════════════════════════════════╣
            ║ En un mundo de fantasia, aventura y mazmorras,                 ║
            ║ solo los cazadores más valientes se atreven a enfrentarlas.    ║
            ║ Eres un cazador novato, pero con un potencial increíble.       ║
            ║                                                                ║
            ║ Tu objetivo es adentrarte en las mazmorras, derrotar           ║
            ║ a los monstruos que las habitan y enfrentarte al jefe final    ║
            ║ para cerrar cada mazmorra. Con cada victoria, ganarás          ║
            ║ experiencia y podrás mejorar tus estadísticas.                 ║
            ║                                                                ║
            ║ Prepara tus armas, afina tus sentidos y lánzate a la aventura. ║
            ║ El destino de la humanidad está en tus manos.                  ║
            ║                                                                ║
            ╠════════════════════════════════════════════════════════════════╣
            ║            Presiona cualquier tecla para continuar...          ║
            ╚════════════════════════════════════════════════════════════════╝ ";
      foreach (var item in texto)
      {
        Console.Write(item);
        Thread.Sleep(1);
      }
      Console.ReadKey();
      Console.Clear();

    }

    public static Personaje CrearPersonaje()
    {
      Console.Write("Antes de comenzar, por favor ingresa el nombre de tu personaje: ");
      string nombre = Console.ReadLine();

      Personaje jugador = new Personaje(nombre);

      Console.WriteLine($"¡Bienvenido, {nombre}! Tus estadísticas iniciales son:");
      jugador.MostrarCaracteristicas();

      return jugador;
    }

    public static async Task<List<Mazmorra>> CrearLista11Mazmorras()
    {
      Console.WriteLine("Preparando todo para empezar...");
      List<Mazmorra> mazmorras = new List<Mazmorra>(); // CREO LISTA DE MAZMORRAS
      Random random = new Random();
      for (int i = 0; i < 11; i++) // HAGO UN BUCLE PARA HACER 11 MAZMORRAS
      {
        // CREO 2 MONSTRUOS PARA CADA MAZMORRA
        Monstruo monstruo1 = new Monstruo((Tipos)random.Next(i, i + 2));
        Monstruo monstruo2 = new Monstruo((Tipos)random.Next(i, i + 2));

        List<Monstruo> monstruos = new List<Monstruo>(); // LISTA DE MONSTRUOS

        // AGREGO LOS MONSTRUOS A LA LISTA
        monstruos.Add(monstruo1);
        monstruos.Add(monstruo2);

        Monstruo jefe = new Monstruo((Tipos)random.Next(i + 2, i + 2)); // CREO EL JEFE DE LA MAZMORRA

        var nombre = await Mazmorra.NombreMazmorraAsync(); // PARA EL NOMBRE DE LA MAZMORRA DESDE UNA API

        Mazmorra mazmorra = new Mazmorra(nombre.name, monstruos, jefe); // CONSTRUCTOR DE MAZMORRA

        mazmorras.Add(mazmorra); // AGREGO LA MAZMORRA A LA LISTA

        if (i == 5)
        {
          Console.WriteLine("Ya estamos terminando...");
        }
      }
      Console.WriteLine("LISTO!!");
      Console.WriteLine("Presione cualquier tecla para continuar...");
      Console.ReadKey();

      return mazmorras;

    }

    public static void FelicitarJugador(Personaje jugador)
    {
      Console.WriteLine($"¡Felicitaciones, {jugador.Nombre}!");
      Console.WriteLine("¡Has completado el juego con gran éxito!");
      Console.WriteLine($"Nivel Alcanzado: {jugador.Nivel}");
      Console.WriteLine("Tu dedicación y habilidades te han llevado a la victoria.");
      Console.WriteLine("¡Esperamos que hayas disfrutado la aventura tanto como nosotros disfrutamos creando este juego para ti!");
      Console.WriteLine("¡Gracias por jugar!");
    }

    public static void Menu(Personaje personaje, List<Mazmorra> mazmorras)
    {
      bool salir = false;
      while (!salir)
      {
        Console.WriteLine("╔════════════════════════════════════════════╗");
        Console.WriteLine("║--------------------MENU--------------------║");
        Console.WriteLine("╠════════════════════════════════════════════╣");
        Console.WriteLine("║ 1. Mostrar estadisticas                    ║");
        Console.WriteLine("║ 2. Entrenar                                ║");
        Console.WriteLine("║ 3. Entrar a una mazmorra                   ║");
        Console.WriteLine("║ 4. Tomar pocion para la salud              ║");
        Console.WriteLine("║ 5. Guardar partida                         ║");
        Console.WriteLine("║ 6. Salir                                   ║");
        Console.WriteLine("╚════════════════════════════════════════════╝");
        Console.Write("Ingrese su respuesta: ");
        string respuesta = Console.ReadLine();

        switch (respuesta)
        {
          case "1":
            personaje.MostrarCaracteristicas();
            break;

          case "2":
            personaje.Entrenar();
            break;

          case "3":
            if (mazmorras.Count == 0)
            {
              Console.WriteLine("TERMINASTE TODAS LAS MAZMORRAS. CONTINUARA...");
            }
            else
            {
              bool completa = mazmorras[0].IniciarMazmorra(personaje);
              if (completa)
              {
                mazmorras.RemoveAt(0);
              }
              if (mazmorras.Count == 0)
              {
                FelicitarJugador(personaje);
              }

            }
            break;

          case "4":
            personaje.Entrenar();
            break;

          case "5":
            personaje.Entrenar();
            break;

          case "6":
            Console.WriteLine("Gracias por jugar. ¡Hasta la próxima!");
            salir = true;
            break;

          default:
            Console.WriteLine("Opción no válida. Por favor, selecciona una opción del 1 al 6.");
            break;

        }
      }
    }

    public static void EfectoMazmorra()
    {
      Thread.Sleep(300);
      int cursorLeft = Console.CursorLeft;
      int cursorTop = Console.CursorTop;
      Console.WriteLine(@"
                       .:-=+==-.                     
                   :-=%+=+****+*+=:                  
                 :*=-=*#+++**+=+#+==*=.              
               -+===--+%+-===--*#===**++.            
             -+++*#*=-=%**+#+*+#==+*#+=+*.           
            =++******+#%+=:.:-+++++++++*#*.          
           =%#+*+++*#%+-:.=%+:.=***++*#*+**:         
         :=-=*%%*+*#==-.-%@@@@*::==*#+=+***#:        
        :=+**#+=#@*=-.-#@@@@@@@%=.:*+#+*++*##.       
       .++#%#*=+#++::+@@%@@@@@@@@#:.-=#*+=++%#       
       .++++==#%--.:#@@@%%@@@@%%@@%:.-*+#*##++=      
       .*****#%--.:%@@@%%@@@@@@%@@@%-.-=*#==++*:     
       :=-=+*#-=::#@@@@@%@@@@@@#@@@@@::-=%*+#***     
       +*#++*+-:.#@@@@@@#@@@@@@#@@@@@#.:--%++++*.    
       +*%#+#--:-@@@@@@@#@@@@@@%@@@@@@=.:-#+=+=+:    
       .++***==-#@%%%%%%#%%%#########%%---+*++=.     
        --=+=-:-#%#%#%####*#*##***#*###=+=-::.-      
        :::::=+=#@@%@@@@%@@@@@@%@@@%@@%++===-=-      
        -+--++++#@@%@@@@%%@@%@@%@@%%@@%======+-      
        -:::=---#@@%#%@%%%@@@%@%@@%%@@#-:::=+--      
       .=++++*++#@@@##@%%%@@@%@%@@#%@@%****+++-      
       ---::-#::*@@@@@#@%#@@@%@%@@%#@@%-===-:--      
       ==:-++#-=*@@%@@@%%#@@%%@#@@%%@@%=-:-=---      
        =+=+**+*#@@@@@@%@%@@@@%#@@@%@@%==++*==-.     
        =--:====#%*####*****+****+***#*=+-:+++:.     
        =+**==+*#@@@@@@%%%%%%%%%%%%%%@%=+*+*++-      
       --:::::*#%@@@@@@#%%@@%%%%@@@@@@#--:=----      
       :=-:-=*=-%@@@@@%#%@@@%%%%@@@@@@#=-==++--      
        +***#*+*%@@@@%%%#@@@@%%%@@@@@@%==+*++*=::    
        -----===#@@@@%%%#@@@@%@%@@@@@@#:-=-.=*+==:   
        ------+-#@@@@@@@@@@@@@@@@@@@@@%=---::----:   ");
      Console.WriteLine("Presione una tecla para entrar a la mazmorra...");
      Console.ReadKey();
      Console.SetCursorPosition(cursorLeft, cursorTop);
      Console.WriteLine(@"
                      .......                                          
                    .::-=++==-:                                                                          
                 .==+#+++++*++**-::                                                            
               :=+=--**--===-=#===%=-                                               
             :+==++=-=#=++*+=#+=++*=++.                       
            ==+**#*+=+@*=:--+*==+*+==*#.                      
           =#++++++#%*-:.=*-:-#**++*#*++:                     
         .--=###++#+=-.=    #-:=+#*==+*+*:   =@@+.            
        .==++*-+%#=-.-%       #:-****+=+*#.-%@@@@@*:          
        ++*#*+=#++:.*           +.==#+==+#%@@@@@@@@@*.        
        +++==*%=-.:%             #:==*#+%@@@@@@@@#%@@%-       
        +++**@+-.:                %:--##@@%@%@@@@#%@@@@=      
       :===+*+-::%                 #:-%@@@%%%@@@@#%%@@@%=     
       -*#*+#::.*                   =*@@@@@%%@@@@#@@@@@@%-    
       :*##*#-::                     @@@@@@%@@@@@#%@@@@@@%    
        -++*=--+                     @@%@@@%@@@@@#%%@@@@@%:   
        :--::=-=                     %%%%%%%@@@@@%%@@@%@@#:   
        :+++****                     #***+++++++++***#***#:   
        ::::=--+                     @@%@@@%@@@@@%@@@@%%@%=   
        -=+++*+*                     @@#%@@#@%@@@#%@@@%%@%=   
       :-:.:=+:-                     @%%%@@%%%@@@#%@##@%@%=   
       :=-=+#+++                     @#%%@@#%%@@%#%%%%%%@%+   
        ----++-*                     @%#@@@#%%@@%%#%@@@%@%+   
        ---:---+                     @%%@@%#%%@@%%#%@@@%@%*   
        -=++==+%                     #######%%%@@%%%@@@@@@*   
       :=-..:++#                     %###******+********#@#   
        =+++*+=#                     @%%@@%@%%@@@%%@@@@@@@%   
        :----+-+                     @%@@@@%#%@@@#%%%@@@@@%   
        -=---*:+                     @%@@@@%#%@@@##%%@@@@@@   
                ....................:-=++*##%@@@@#%%%@@@@@@   
                                              ..:--=+*##%*:   
                                                                                       ");
    }

    public static void EfectoCombatePersonaje(Personaje jugador, Monstruo monstruo, int danioJugador)
    {
      Thread.Sleep(300);
      int cursorLeft = Console.CursorLeft;
      int cursorTop = Console.CursorTop;
      int saludMonstruoDespuesDeAtaque = monstruo.Salud - danioJugador;
      if (saludMonstruoDespuesDeAtaque < 0)
      {
        saludMonstruoDespuesDeAtaque = 0;
      }
      Console.WriteLine(@$"        SALUD: <<{monstruo.Salud}>>                                               SALUD: <<{jugador.Salud}>>         
                                                                                                                                                                           
                                                                                                                                                               
                                                                                                                                                            
                                                                                                                                                         
                                                                                                                                                    
                                      .=.                                                                                                                                                  
                          :+##+          ::-:                                                                                 
                         -@@@@@*            :=                                                                                
                         @@@@%*=             =                               .=:.                                                
                    :---*@@@@%*+=-::::======:-%=>                           :=:.=-                                               
                    =**#@@@@@%%%%#++==++++==+@:         _                   +:::-+                                                                                                   
                        %@@@@@@%@+           +         |:+**=.              +.--+*-:                                                                       
                   ..   %@@@@@@%@#          .+             -+#*-.           +:  +:.--                                                                   
           :-:..  +#+   -@@@@@@@%%        :--                 .-*#*-..+  .:-*. -= =++                                                                
         *@@@@%%%%#*---=**@@@@@@%%=   .-:.                        .=%%:++:*-+#++.-= +                                                            
       .%@@@@@@@@@%%%%%%@@@@@%@%%@+    .                            +--*::%-:::==   +                                                          
       %@@@@@@@@%@%%%%%@@@@@@@%%@@.                                     ::-   :*:::=*=                                                      
       @@@@@@@@%@@@%%%%%@@@@@@@@@-                                          .=.-: =. :=                                                  
      .@@@@@@%%%@@@@@@@@@@@@@@@@=                                          --   =++   -:                                                   
      .@@@@@@%@@@@*+#%@@@@%%@@@@#-:                                       -:  .-- :=   +                                                    
      .@@@@@+=@@@*       #@%-=+**#@-                                     :+:--:    .=  -.                                                     
      .@@@%@%@%-.        %%#     .@*                                     -=:-=       +-=+:                                                                                                 
       +@@#=+@+          *@-   +@%*=                                      +. +        *: -:                                                                                 
        *@-  @%.         #@:   :-.                                         +.-:        =: +                                                                                 
        #@+  +@#:        #%*                                              +=:::-         =-.:=                                                                               
        .@@+  =++         #@%:                                           +=:::-         =-.:=                               
                                                                                                            ");
      Thread.Sleep(300);

      Console.SetCursorPosition(cursorLeft, cursorTop);


      Console.WriteLine(@$"        SALUD: <<{monstruo.Salud}>>                                               SALUD: <<{jugador.Salud}>>         
                                                                                             _         
                                                                                          -*#=|          
                                                                                       -*%+.               
                                                                                    :*%+:            
                                                                                 :+@#-             
                                      .=.                                     #++%%=.                         
                          :+##+          ::-:                              --#.-@:                      
                         -@@@@@*            :=                            #: #=*::                       
                         @@@@%*=             =                            .*-++=---                   
                    :---*@@@@%*+=-::::======:-%=>                          -- +-::#               
                    =**#@@@@@%%%%#++==++++==+@:                             +:==-+#=.                   
                        %@@@@@@%@+           +                              *+. :* :=                   
                   ..   %@@@@@@%@#          .+                               + :-=*-**                    
           :-:..  +#+   -@@@@@@@%%        :--                                =+::::. +                    
         *@@@@%%%%#*---=**@@@@@@%%=   .-:.                                    =:     +                  
       .%@@@@@@@@@%%%%%%@@@@@%@%%@+    .                                       *  .:-+                  
       %@@@@@@@@%@%%%%%@@@@@@@%%@@.                                           -#.:.=-+:                     
       @@@@@@@@%@@@%%%%%@@@@@@@@@-                                          := .+ +   --                     
      .@@@@@@%%%@@@@@@@@@@@@@@@@=                                          +:   .**.   +                      
      .@@@@@@%@@@@*+#%@@@@%%@@@@#-:                                       +   .=-  +.  .=                       
      .@@@@@+=@@@*       #@%-=+**#@-                                     ==-:=:     =-  *                        
      .@@@%@%@%-.        %%#     .@*                                     +--==       :*:#=                                                                    
       +@@#=+@+          *@-   +@%*=                                      +  +        -*. +                              
        *@-  @%.         #@:   :-.                                        .+ -:        := .+                                                            
        #@+  +@#:        #%*                                               .#-#          +:--                     
        .@@+  =++         #@%:                                           +++--=.         -+:--                           
                                                                                                             ");
      Thread.Sleep(300);

      Console.SetCursorPosition(cursorLeft, cursorTop);

      if (saludMonstruoDespuesDeAtaque == 0)
      {
        Console.WriteLine(@$"        SALUD: <<{saludMonstruoDespuesDeAtaque}>>                                               SALUD: <<{jugador.Salud}>>         
                                                                                                                                  
                                                                                                                            
                                                                                                                            
                                                                                                                            
                                                                                                                            
                                                                                                                        
                                                                                                        
                  :=*#%%#*+-                                                                                   
                +@@@@@@@@@@@@*.                                              .=:.                                             
              -@@@@@@@@@@@@@@@@+                                            :=:.=-                                      
             :@@@@@@@@@@@@@@@@@@=                       _                   +:::-+                                                             
             *@@@@@@@@@@@@@@@@@@%                      |:+**=.              +.--+*-:                                                              
             #@@@%%%@@@@@@@%%@@@%                          -+#*-.           +:  +:.--                                      
             +@@.    +@@%.    #@#                             .-*#*-..+  .:-*. -= =++                                   
             :@%.    *@@%.    *@+                                 .=%%:++:*-+#++.-= +                               
              #@@%##@@+=@@###@@%.                                   +--*::%-:::==   +                             
               :+%@@@%  *@@@@+-                                         ::-   :*:::=*=                         
         -==.     %@@@@@@@@@.     -=-                                       .=.-: =. :=                     
        =@@@@=    .-%*@##%=:    -@@@@+                                     --   =++   -:                      
         #@@@@%=:            .-#@@@@@                                     -:  .-- :=   +                       
        .%@@@@@@@@#+-.  .-+#@@@@@@@@@-                                   :+:--:    .=  -.                        
               .:=*@@@@@@@@#=-.                                          -=:-=       +-=+:                                                                    
         .:.:-=*#%@@%#++*%@@@#*+-:.:.                                     +. +        *: -:                                     
        =@@@@@@@*=:        :=*%@@@@@@*                                     +.-:        =: +                                    
        .%@@@+.                .=@@@@:                                    +=:::-         =-.:=                     
         :#*.                     +#=                                    +=:::-         =-.:=                                      
                                                                                                               ");
      }
      else
      {
        Console.WriteLine(@$"        SALUD: <<{saludMonstruoDespuesDeAtaque}>>                                               SALUD: <<{jugador.Salud}>>         
                                                                                                                                  
                                                                                                                            
                                                                                                                            
                                                                                                                            
                                                                                                                            
                                      .=.                                                                                  
                          :+##+          ::-:                                                                              
                         -@@@@@*            :=                                                                             
                         @@@@%*=             =                               .=:.                                             
                    :---*@@@@%*+=-::::======:-%=>                           :=:.=-                                      
                    =**#@@@@@%%%%#++==++++==+@:         _                   +:::-+                                                             
                        %@@@@@@%@+           +         |:+**=.              +.--+*-:                                                              
                   ..   %@@@@@@%@#          .+             -+#*-.           +:  +:.--                                      
           :-:..  +#+   -@@@@@@@%%        :--                 .-*#*-..+  .:-*. -= =++                                   
         *@@@@%%%%#*---=**@@@@@@%%=   .-:.                        .=%%:++:*-+#++.-= +                               
       .%@@@@@@@@@%%%%%%@@@@@%@%%@+    .                            +--*::%-:::==   +                             
       %@@@@@@@@%@%%%%%@@@@@@@%%@@.                                     ::-   :*:::=*=                         
       @@@@@@@@%@@@%%%%%@@@@@@@@@-                                          .=.-: =. :=                     
      .@@@@@@%%%@@@@@@@@@@@@@@@@=                                          --   =++   -:                      
      .@@@@@@%@@@@*+#%@@@@%%@@@@#-:                                       -:  .-- :=   +                       
      .@@@@@+=@@@*       #@%-=+**#@-                                     :+:--:    .=  -.                        
      .@@@%@%@%-.        %%#     .@*                                     -=:-=       +-=+:                                                                    
       +@@#=+@+          *@-   +@%*=                                      +. +        *: -:                                     
        *@-  @%.         #@:   :-.                                         +.-:        =: +                                    
        #@+  +@#:        #%*                                              +=:::-         =-.:=                     
        .@@+  =++         #@%:                                           +=:::-         =-.:=                                      
                                                                                                               ");

        Console.SetCursorPosition(cursorLeft, cursorTop);
      }





    }

    public static void EfectoCombateMonstruo(Personaje jugador, Monstruo monstruo, int danioMonstruo)
    {
      Thread.Sleep(300);
      int cursorLeft = Console.CursorLeft;
      int cursorTop = Console.CursorTop;
      int saludJugadorDespuesDeAtaque = jugador.Salud - danioMonstruo;
      if (saludJugadorDespuesDeAtaque < 0)
      {
        saludJugadorDespuesDeAtaque = 0;
      }
      Console.WriteLine(@$"        SALUD: <<{monstruo.Salud}>>                                               SALUD: <<{jugador.Salud}>>         
                                                                                                                                                                                                                                      
                                                                                                                                    
                                                                                                                                    
                                                                                                                                    
                                                                                                                                    
                                      .=.                                                                                                
                          :+##+          ::-:                                                                                            
                         -@@@@@*            :=                                                                                           
                         @@@@%*=             =                                                  .=:.                                        
                    :---*@@@@%*+=-::::======:-%=>                                              :=:.=-                                       
                    =**#@@@@@%%%%#++==++++==+@:                            _                   +:::-+                                         
                        %@@@@@@%@+           +                            |:+**=.              +.--+*-:                                          
                   ..   %@@@@@@%@#          .+                                -+#*-.           +:  +:.--                                      
           :-:..  +#+   -@@@@@@@%%        :--                                    .-*#*-..+  .:-*. -= =++                                   
         *@@@@%%%%#*---=**@@@@@@%%=   .-:.                                           .=%%:++:*-+#++.-= +                               
       .%@@@@@@@@@%%%%%%@@@@@%@%%@+    .                                               +--*::%-:::==   +                             
       %@@@@@@@@%@%%%%%@@@@@@@%%@@.                                                        ::-   :*:::=*=                         
       @@@@@@@@%@@@%%%%%@@@@@@@@@-                                                             .=.-: =. :=                     
      .@@@@@@%%%@@@@@@@@@@@@@@@@=                                                             --   =++   -:                      
      .@@@@@@%@@@@*+#%@@@@%%@@@@#-:                                                          -:  .-- :=   +                       
      .@@@@@+=@@@*       #@%-=+**#@-                                                        :+:--:    .=  -.                        
      .@@@%@%@%-.        %%#     .@*                                                        -=:-=       +-=+:                                                                    
       +@@#=+@+          *@-   +@%*=                                                         +. +        *: -:                        
        *@-  @%.         #@:   :-.                                                            +.-:        =: +                    
        #@+  +@#:        #%*                                                                 +=:::-         =-.:=                     
        .@@+  =++         #@%:                                                              +=:::-         =-.:=                         
                                                                                                                                ");
      Thread.Sleep(300);
      Console.SetCursorPosition(cursorLeft, cursorTop);
      Console.WriteLine(@$"        SALUD: <<{monstruo.Salud}>>                                               SALUD: <<{jugador.Salud}>>         
                                                                                                                                             
                                                                                                                                       
                                                                                                                                       
                                                                                                                                       
                                                                                                                                       
                                      .=.                                                                                                 
                          :+##+          ::-:                                                                                         
                         -@@@@@*            :=                                                                                                       
                         @@@@%*=             =                                                  .=:.                                                    
                    :---*@@@@%*+=-::::     >=:-%======>                                        :=:.=-                                                   
                    =**#@@@@@%%%%#++==++++==+@:                            _                   +:::-+                                                                          
                        %@@@@@@%@+           +                            |:+**=.              +.--+*-:                                          
                   ..   %@@@@@@%@#          .+                                -+#*-.           +:  +:.--                                      
           :-:..  +#+   -@@@@@@@%%        :--                                    .-*#*-..+  .:-*. -= =++                                   
         *@@@@%%%%#*---=**@@@@@@%%=   .-:.                                           .=%%:++:*-+#++.-= +                               
       .%@@@@@@@@@%%%%%%@@@@@%@%%@+    .                                               +--*::%-:::==   +                             
       %@@@@@@@@%@%%%%%@@@@@@@%%@@.                                                        ::-   :*:::=*=                         
       @@@@@@@@%@@@%%%%%@@@@@@@@@-                                                             .=.-: =. :=                     
      .@@@@@@%%%@@@@@@@@@@@@@@@@=                                                             --   =++   -:                      
      .@@@@@@%@@@@*+#%@@@@%%@@@@#-:                                                          -:  .-- :=   +                       
      .@@@@@+=@@@*       #@%-=+**#@-                                                        :+:--:    .=  -.                        
      .@@@%@%@%-.        %%#     .@*                                                        -=:-=       +-=+:                                                                    
       +@@#=+@+          *@-   +@%*=                                                         +. +        *: -:                                             
        *@-  @%.         #@:   :-.                                                            +.-:        =: +                                            
        #@+  +@#:        #%*                                                                 +=:::-         =-.:=                     
        .@@+  =++         #@%:                                                              +=:::-         =-.:=                                            
                                                                                                                                           ");

      Thread.Sleep(300);
      Console.SetCursorPosition(cursorLeft, cursorTop);
      Console.WriteLine(@$"        SALUD: <<{monstruo.Salud}>>                                               SALUD: <<{jugador.Salud}>>         
                                                                                                                                              
                                                                                                                                        
                                                                                                                                        
                                                                                                                                        
                                                                                                                                        
                                      .=.                                                                                                           
                          :+##+          ::-:                                                                                                       
                         -@@@@@*            :=                                                                                                      
                         @@@@%*=             =                                                  .=:.                                                   
                    :---*@@@@%*+=-::::       :-%         >========>                            :=:.=-                                 
                    =**#@@@@@%%%%#++==++++==+@:                            _                   +:::-+                                         
                        %@@@@@@%@+           +                            |:+**=.              +.--+*-:                                          
                   ..   %@@@@@@%@#          .+                                -+#*-.           +:  +:.--                                      
           :-:..  +#+   -@@@@@@@%%        :--                                    .-*#*-..+  .:-*. -= =++                                   
         *@@@@%%%%#*---=**@@@@@@%%=   .-:.                                           .=%%:++:*-+#++.-= +                               
       .%@@@@@@@@@%%%%%%@@@@@%@%%@+    .                                               +--*::%-:::==   +                             
       %@@@@@@@@%@%%%%%@@@@@@@%%@@.                                                        ::-   :*:::=*=                         
       @@@@@@@@%@@@%%%%%@@@@@@@@@-                                                             .=.-: =. :=                     
      .@@@@@@%%%@@@@@@@@@@@@@@@@=                                                             --   =++   -:                      
      .@@@@@@%@@@@*+#%@@@@%%@@@@#-:                                                          -:  .-- :=   +                       
      .@@@@@+=@@@*       #@%-=+**#@-                                                        :+:--:    .=  -.                        
      .@@@%@%@%-.        %%#     .@*                                                        -=:-=       +-=+:                                                                    
       +@@#=+@+          *@-   +@%*=                                                         +. +        *: -:                                              
        *@-  @%.         #@:   :-.                                                            +.-:        =: +                                             
        #@+  +@#:        #%*                                                                 +=:::-         =-.:=                     
        .@@+  =++         #@%:                                                              +=:::-         =-.:=                                               
                                                                                                                                   ");

      Thread.Sleep(300);
      Console.SetCursorPosition(cursorLeft, cursorTop);
      Console.WriteLine(@$"        SALUD: <<{monstruo.Salud}>>                                               SALUD: <<{jugador.Salud}>>         
                                                                                                                                                 
                                                                                                                                           
                                                                                                                                           
                                                                                                                                           
                                                                                                                                           
                                      .=.                                                                                                      
                          :+##+          ::-:                                                                                                  
                         -@@@@@*            :=                                                                                                 
                         @@@@%*=             =                                                  .=:.                                              
                    :---*@@@@%*+=-::::       :-%                       >========>              :=:.=-                                             
                    =**#@@@@@%%%%#++==++++==+@:                            _                   +:::-+                                         
                        %@@@@@@%@+           +                            |:+**=.              +.--+*-:                                          
                   ..   %@@@@@@%@#          .+                                -+#*-.           +:  +:.--                                      
           :-:..  +#+   -@@@@@@@%%        :--                                    .-*#*-..+  .:-*. -= =++                                   
         *@@@@%%%%#*---=**@@@@@@%%=   .-:.                                           .=%%:++:*-+#++.-= +                               
       .%@@@@@@@@@%%%%%%@@@@@%@%%@+    .                                               +--*::%-:::==   +                             
       %@@@@@@@@%@%%%%%@@@@@@@%%@@.                                                        ::-   :*:::=*=                         
       @@@@@@@@%@@@%%%%%@@@@@@@@@-                                                             .=.-: =. :=                     
      .@@@@@@%%%@@@@@@@@@@@@@@@@=                                                             --   =++   -:                      
      .@@@@@@%@@@@*+#%@@@@%%@@@@#-:                                                          -:  .-- :=   +                       
      .@@@@@+=@@@*       #@%-=+**#@-                                                        :+:--:    .=  -.                        
      .@@@%@%@%-.        %%#     .@*                                                        -=:-=       +-=+:                                                                    
       +@@#=+@+          *@-   +@%*=                                                         +. +        *: -:                                                
        *@-  @%.         #@:   :-.                                                            +.-:        =: +                                               
        #@+  +@#:        #%*                                                                 +=:::-         =-.:=                     
        .@@+  =++         #@%:                                                              +=:::-         =-.:=                                                 
                                                                                                                                  ");

      Thread.Sleep(300);
      Console.SetCursorPosition(cursorLeft, cursorTop);

      if (saludJugadorDespuesDeAtaque == 0)
      {
        Console.WriteLine(@$"        SALUD: <<{monstruo.Salud}>>                                               SALUD: <<{saludJugadorDespuesDeAtaque}>>         
                                                                                                                                  
                                                                                                                            
                                                                                                                            
                                                                                                                            
                                                                                                                            
                                      .=.                                                                                             
                          :+##+          ::-:                                                                                         
                         -@@@@@*            :=                                               :=*#%%#*+-                                                                
                         @@@@%*=             =                                             +@@@@@@@@@@@@*.                                          
                    :---*@@@@%*+=-::::======:-%=>                                        -@@@@@@@@@@@@@@@@+                                                           
                    =**#@@@@@%%%%#++==++++==+@:                                         :@@@@@@@@@@@@@@@@@@=                                                             
                        %@@@@@@%@+           +                                          *@@@@@@@@@@@@@@@@@@%                                        
                   ..   %@@@@@@%@#          .+                                          #@@@%%%@@@@@@@%%@@@%                                          
           :-:..  +#+   -@@@@@@@%%        :--                                           +@@.    +@@%.    #@#                                          
         *@@@@%%%%#*---=**@@@@@@%%=   .-:.                                              :@%.    *@@%.    *@+                                  
       .%@@@@@@@@@%%%%%%@@@@@%@%%@+    .                                                 #@@%##@@+=@@###@@%.                             
       %@@@@@@@@%@%%%%%@@@@@@@%%@@.                                                       :+%@@@%  *@@@@+-                                  
       @@@@@@@@%@@@%%%%%@@@@@@@@@-                                                  -==.     %@@@@@@@@@.     -=-                                   
      .@@@@@@%%%@@@@@@@@@@@@@@@@=                                                  =@@@@=    .-%*@##%=:    -@@@@+                                         
      .@@@@@@%@@@@*+#%@@@@%%@@@@#-:                                                 #@@@@%=:            .-#@@@@@                                        
      .@@@@@+=@@@*       #@%-=+**#@-                                               .%@@@@@@@@#+-.  .-+#@@@@@@@@@-                                             
      .@@@%@%@%-.        %%#     .@*                                                      .:=*@@@@@@@@#=-.                                                                                    
       +@@#=+@+          *@-   +@%*=                                                .:.:-=*#%@@%#++*%@@@#*+-:.:.                                                     
        *@-  @%.         #@:   :-.                                                 =@@@@@@@*=:        :=*%@@@@@@*                                               
        #@+  +@#:        #%*                                                       .%@@@+.                .=@@@@:                                     
        .@@+  =++         #@%:                                                      :#*.                     +#=                                                             
                                                                                                               ");
      }
      else
      {
        Console.WriteLine(@$"        SALUD: <<{monstruo.Salud}>>                                               SALUD: <<{saludJugadorDespuesDeAtaque}>>         
                                                                                                                                                     
                                                                                                                                               
                                                                                                                                               
                                                                                                                                               
                                                                                                                                               
                                      .=.                                                                                                       
                          :+##+          ::-:                                                                                                   
                         -@@@@@*            :=                                                                                                  
                         @@@@%*=             =                                                  .=:.                                               
                    :---*@@@@%*+=-::::       :-%                                    >========> :=:.=-                                              
                    =**#@@@@@%%%%#++==++++==+@:                            _                   +:::-+                                         
                        %@@@@@@%@+           +                            |:+**=.              +.--+*-:                                          
                   ..   %@@@@@@%@#          .+                                -+#*-.           +:  +:.--                                      
           :-:..  +#+   -@@@@@@@%%        :--                                    .-*#*-..+  .:-*. -= =++                                   
         *@@@@%%%%#*---=**@@@@@@%%=   .-:.                                           .=%%:++:*-+#++.-= +                               
       .%@@@@@@@@@%%%%%%@@@@@%@%%@+    .                                               +--*::%-:::==   +                             
       %@@@@@@@@%@%%%%%@@@@@@@%%@@.                                                        ::-   :*:::=*=                         
       @@@@@@@@%@@@%%%%%@@@@@@@@@-                                                             .=.-: =. :=                     
      .@@@@@@%%%@@@@@@@@@@@@@@@@=                                                             --   =++   -:                      
      .@@@@@@%@@@@*+#%@@@@%%@@@@#-:                                                          -:  .-- :=   +                       
      .@@@@@+=@@@*       #@%-=+**#@-                                                        :+:--:    .=  -.                        
      .@@@%@%@%-.        %%#     .@*                                                        -=:-=       +-=+:                                                                    
       +@@#=+@+          *@-   +@%*=                                                         +. +        *: -:                               
        *@-  @%.         #@:   :-.                                                            +.-:        =: +                                          
        #@+  +@#:        #%*                                                                 +=:::-         =-.:=                     
        .@@+  =++         #@%:                                                              +=:::-         =-.:=                                            
                                                                                                                                   ");
        Console.SetCursorPosition(cursorLeft, cursorTop);
      }


    }


  }
}