using System.Security.Cryptography.X509Certificates;
using Historial;
using Mazmorras;
using Monstruos;
using Partida;
using Protagonista;

namespace Funciones
{

  public static class FuncionesPersonaje
  {
    public static Personaje CrearPersonaje()
    {

      Console.Write("Antes de comenzar, por favor ingresa el nombre de tu personaje: ");
      string nombre = Console.ReadLine();

      //Retorna true si la cadena es null, una cadena vacía ("") o contiene solo caracteres de espacio en blanco (' '), y false en cualquier otro caso.
      while (string.IsNullOrWhiteSpace(nombre) || nombre.Length > 25)
      {
        Console.WriteLine("El nombre no puede ser vacio y no debe superar los 25 caracteres.");
        Console.Write("Antes de comenzar, por favor ingresa el nombre de tu personaje: ");
        nombre = Console.ReadLine();
      }

      Personaje jugador = new Personaje(nombre);

      Console.WriteLine($"¡Bienvenido, {nombre}! Tus estadísticas iniciales son:");
      Console.WriteLine($"Edad: {jugador.Datos.Edad}");
      string fecha = jugador.Datos.Fechanac.ToString("dd MMMM yyyy");
      Console.WriteLine($"Fecha de nacimiento: {fecha}");
      jugador.MostrarCaracteristicas();

      return jugador;
    }
  }

  public static class FuncionesPartida
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
            ║ En un mundo asolado por la aparición de mazmorras,             ║
            ║ donde criaturas siniestras y secretos ancestrales              ║
            ║ yacen en su interior,                                          ║
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
            ╠════════════════════════════════════════════════════════════════╣
            ║                Presiona enter para continuar...                ║
            ╚════════════════════════════════════════════════════════════════╝ ";
      foreach (var item in texto)
      {
        if (item == ' ')
        {
          Console.Write(item);
        }
        else
        {
          Console.Write(item);
          Thread.Sleep(1);
        }


      }
      LimpiarBuffer();
      Console.ReadKey();
      Console.Clear();

    }

    public static void Menu(Personaje personaje, List<Mazmorra> mazmorras)
    {
      bool salir = false;
      while (!salir)
      {
        LimpiarBuffer();
        Console.WriteLine("╔════════════════════════════════════════════╗");
        Console.WriteLine("║--------------------MENU--------------------║");
        Console.WriteLine("╠════════════════════════════════════════════╣");
        Console.WriteLine("║ 1. Mostrar estadisticas                    ║");
        Console.WriteLine("║ 2. Entrenar                                ║");
        Console.WriteLine("║ 3. Entrar a una mazmorra                   ║");
        Console.WriteLine("║ 4. Tomar pocion para la salud              ║");
        Console.WriteLine("║ 5. Guardar partida                         ║");
        Console.WriteLine("║ 6. Volver                                  ║");
        Console.WriteLine("╚════════════════════════════════════════════╝");
        Console.Write("Ingrese su respuesta: ");
        string respuesta = Console.ReadLine();

        switch (respuesta)
        {
          case "1":
            Console.Clear();
            personaje.MostrarCaracteristicas();
            break;

          case "2":
            personaje.Entrenar();
            break;

          case "3":
            if (mazmorras.Count == 0)
            {
              Console.Clear();
              Console.WriteLine("TERMINASTE TODAS LAS MAZMORRAS. CONTINUARA...");
            }
            else
            {
              bool completa = mazmorras[0].IniciarMazmorra(personaje);
              if (completa)
              {
                mazmorras.RemoveAt(0);
              }
              else
              {
                personaje.Estadisticas.Salud1();
              }
              Console.WriteLine($"Numero de mazmorras restantes: {mazmorras.Count}");
              if (mazmorras.Count == 0)
              {
                LimpiarBuffer();
                Console.WriteLine("Presione enter para continuar...");
                FelicitarJugador(personaje);
                HistorialJson.AgregarHistorialDeGanadores(personaje);
              }

            }
            break;

          case "4":
            Console.Clear();
            Console.WriteLine("------------------------");
            Console.WriteLine("Salud restaurada al 100%");
            Console.WriteLine("------------------------");
            personaje.Estadisticas.Salud100(); // Salud al 100%
            break;

          case "5":
            Console.Clear();
            Console.Write("Ingrese el nombre de su partida: ");
            string nombre = Console.ReadLine();
            PartidaJson.GuardarPartida(personaje, mazmorras, nombre);
            break;

          case "6":
            Console.Clear();
            salir = true;
            break;

          default:
            Console.Clear();
            Console.WriteLine("Opción no válida. Por favor, selecciona una opción del 1 al 6.");
            break;

        }
      }
    }

    public static void FelicitarJugador(Personaje jugador)
    {
      Console.Clear();
      Console.WriteLine(@"
    ### ###  ### ###  ####       ####     # ###    ####   ### #        ##   ### #    ### ###    # ###  
     ##  ##   ##  ##   ##         ##     ##   #     ##     ## ##       ##    ## ##    ##  ##   ##  ##  
     ##       #        ##         ##    ###         ##     ##  ##    # ##    ##  ##   #        ##      
     ## ##    ## ##    ##         ##    ###         ##     ##  ##    #  ##   ##  ##   ## ##     ####   
     ##       ##       ##   #     ##    ###         ##     ##  ##   # ####   ##  ##   ##           ##  
     ##       ##  ##   ##  ##     ##     ##   #     ##     ## ##    #   ##   ## ##    ##  ##   ##  ##  
    ####      #  ###  #######    ####     # ###    ####    #  #    ### ###   #  #     #  ###   ## ##   ");
      Console.WriteLine($"¡Felicitaciones, {jugador.Datos.Nombre}!");
      Console.WriteLine("¡Has completado el juego con gran éxito!");
      Console.WriteLine($"Nivel Alcanzado: {jugador.Estadisticas.Nivel}");
      Console.WriteLine("Tu dedicación y habilidades te han llevado a la victoria.");
      Console.WriteLine("¡Esperamos que hayas disfrutado la aventura tanto como nosotros disfrutamos creando este juego para ti!");
      Console.WriteLine("¡Gracias por jugar!");
      Console.WriteLine("Presione enter para continuar...");
      Console.ReadKey();

    }

    public static void LimpiarBuffer()
    {

      while (Console.KeyAvailable)
      {
        Console.ReadKey(true);
      }

    }
  }

  public static class FuncionesMazmorra

  {
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

        if (nombre.name == "Mazmorra") // NOMBRE DE LA MAZMORRA GENERICO
        {
          nombre.name = "Mazmorra " + (i + 1);
        }

        Mazmorra mazmorra = new Mazmorra(nombre.name, monstruos, jefe); // CONSTRUCTOR DE MAZMORRA

        mazmorras.Add(mazmorra); // AGREGO LA MAZMORRA A LA LISTA

        if (i == 4)
        {
          Console.WriteLine("Ya estamos terminando...");
        }
        if (i == 8)
        {
          Console.WriteLine("Ya casii...");
        }
      }
      Console.WriteLine("LISTO!!");
      Console.WriteLine("Presione enter para continuar...");
      FuncionesPartida.LimpiarBuffer();
      Console.ReadKey();

      return mazmorras;

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
      Console.WriteLine("Presione enter para entrar a la mazmorra...");
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
      Console.WriteLine(@$"        SALUD: <<{monstruo.Salud}>>                                               SALUD: <<{jugador.Estadisticas.Salud}>>         
                                                                                                                                                                           
                                                                                                                                                               
                                                                                                                                                            
                                                                                                                                                         
                                                                                                                                                    
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
      Thread.Sleep(200);

      Console.SetCursorPosition(cursorLeft, cursorTop);


      Console.WriteLine(@$"        SALUD: <<{monstruo.Salud}>>                                               SALUD: <<{jugador.Estadisticas.Salud}>>         
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
      Thread.Sleep(200);

      Console.SetCursorPosition(cursorLeft, cursorTop);

      if (saludMonstruoDespuesDeAtaque == 0)
      {
        Console.WriteLine(@$"        SALUD: <<{saludMonstruoDespuesDeAtaque}>>                                               SALUD: <<{jugador.Estadisticas.Salud}>>         
                                                                                                                                  
                                                                                                                            
                                                                                                                            
                                                                                                                            
                                                                                                                            
                                                                                                                        
                                                                                                        
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
        Console.WriteLine(@$"        SALUD: <<{saludMonstruoDespuesDeAtaque}>>                                               SALUD: <<{jugador.Estadisticas.Salud}>>         
                                                                                                                                  
                                                                                                                            
                                                                                                                            
                                                                                                                            
                                                                                                                            
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
      int saludJugadorDespuesDeAtaque = jugador.Estadisticas.Salud - danioMonstruo;
      if (saludJugadorDespuesDeAtaque < 0)
      {
        saludJugadorDespuesDeAtaque = 0;
      }
      Console.WriteLine(@$"        SALUD: <<{monstruo.Salud}>>                                               SALUD: <<{jugador.Estadisticas.Salud}>>         
                                                                                                                                                                                                                                      
                                                                                                                                    
                                                                                                                                    
                                                                                                                                    
                                                                                                                                    
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
      Thread.Sleep(100);
      Console.SetCursorPosition(cursorLeft, cursorTop);
      Console.WriteLine(@$"        SALUD: <<{monstruo.Salud}>>                                               SALUD: <<{jugador.Estadisticas.Salud}>>         
                                                                                                                                             
                                                                                                                                       
                                                                                                                                       
                                                                                                                                       
                                                                                                                                       
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

      Thread.Sleep(100);
      Console.SetCursorPosition(cursorLeft, cursorTop);
      Console.WriteLine(@$"        SALUD: <<{monstruo.Salud}>>                                               SALUD: <<{jugador.Estadisticas.Salud}>>         
                                                                                                                                              
                                                                                                                                        
                                                                                                                                        
                                                                                                                                        
                                                                                                                                        
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

      Thread.Sleep(100);
      Console.SetCursorPosition(cursorLeft, cursorTop);
      Console.WriteLine(@$"        SALUD: <<{monstruo.Salud}>>                                               SALUD: <<{jugador.Estadisticas.Salud}>>         
                                                                                                                                                 
                                                                                                                                           
                                                                                                                                           
                                                                                                                                           
                                                                                                                                           
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

      Thread.Sleep(100);
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