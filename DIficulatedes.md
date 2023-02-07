# Retos y dificultades del proyecto de migración Xamarin a Maui version non-shell
Este readme tiene como proposito como fue para mi el proceso de migración de Xamarin a Maui usando la documentación adjuntada para dicho proyecto de prueba. 
##  Proceso de migración de Xamarin a Maui, version non-shell
Como primer punto encontramos los ejemplos de como inicia y termina el proyecto, solo al final de migrarlo me di cuenta de las dificultades que encontre en este, ya que el inicio y el final tiene partes muy distintas en la documentación. Haciendo que termine creando una documentación propia como se lee en el readme. 
- Proyecto usado de ejemplo [ArtAuction App Sin Migrar (non-Shell)](https://github.com/Sweekriti91/ArtAuction/tree/main)
- Proyecto completamente migrado [ArtAuction App Migrado (non-Shell)](https://github.com/Sweekriti91/ArtAuction/tree/maui-projecthead)
## Paso 1: reconocimiento de los dispositivos en MAUI
Esto no estaba en la documentación, luego de terminar la migración me estaba preguntando el porque no eran reconocidos los dispositivos, y me di cuenta que la causante de dicho problema es que en la documentación no te especificaron que el archivo `Directory.Build.targets` es el que hace esa función en `Maui` haciendo que luego de pruebas de diferencias entre mi proyecto migrado y el que sale en el link de arriba me termino tendando probar dicho archivo que termino dando la solución del problema.

Tambien se encontraron diferencias en el archivo  `csproj` padre de los tres proyectos, que tampoco estaba en la documentación y causa error a la hora de montar las aplicaciones en los diferentes dispositivos. Lo solucione viendo que hacia cada linea y que lo diferenciaba con la migrada.

## Paso 2: Actualización de los archivos csproj
Aqui se siguio la documentación al pie de la letra
## Paso 3: Actualizar el codigo
Explicare cada error que me tope en esta seccion:
- `AssemblyInfo.cs`

  En la documentación te dicen que comentes o elimines su contenido, tambien borrar dicho archivo, pero unicamente esto aplica para `Android`, para los otros dos, llevan un contenido distintoque en la misma documentacion no esta dicha pero si en el proyecto migrado.
- `Info.plist`

  La version que hay que poner es la `15.2`, pero extrañamente el proyecto migrado solo funciona con `15.4` y yo tuve que usar la `16.1` para que funcionara en `iOS`

- `Resource.designer.cs`

  Este archivo se debe borrar y tampoco la documentación lo indico dando como resultado una aplicación que se montaba dos veces dando error. La solucion siempre es eliminarlo en los arhcivos `Android` donde suele encontrarse.

- `UI`

  Fue otro inconveniente que no pude solucionar, hacer que la UI de Xamarin fuera como la de Maui, es algo que aun no logre hacer, pero eso ya es parte del mismo diseño. 