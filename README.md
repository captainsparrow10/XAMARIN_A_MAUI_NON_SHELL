# Migracion de Xamarin.Forms a MAUI
### Proyecto Migrado
---
# Guia
---
- Proyecto usado de ejemplo [ArtAuction App Sin Migrar (non-Shell)](https://github.com/Sweekriti91/ArtAuction/tree/main)
- Proyecto completamente migrado [ArtAuction App Migrado (non-Shell)](https://github.com/Sweekriti91/ArtAuction/tree/maui-projecthead)
## Paso 1: Econocimiento de los dispositivos
---
A la hora de pasar ``Xamarin.Forms`` a ``MAUI``, se pierde la compatibilidad a la hora de reconocer los dispositivos. Esto se arregla de la siguiente manera:
- Se va a la carpeta fuera del proyecto, la que contiene los tres proyectos:

  ![screen1](https://cdn.discordapp.com/attachments/894620271275827302/1069994064411381881/image.png)
  
- Se crea un archivo llamado ``Directory.Build.targets`` y se le colocara lo siguiente: 
  ```C#
  <Project>
    <PropertyGroup>
      <!-- Required - Enable Launch Profiles for .NET 6 iOS/Android -->
      <_KeepLaunchProfiles>true</_KeepLaunchProfiles>
    </PropertyGroup>
    <ItemGroup>
      <!-- Optional - Enables a list of TFM's and device categories in the debug menu -->
      <!-- This allows easily toggling of debug target TFM by selecting the platform -->
      <!-- If removed, Top level debug targets show as a list of devices for the selected TFM -->
      <ProjectCapability Include="XamarinStaticLaunchProfiles" />
    </ItemGroup>

    <!-- Required - Overwrite tasks that are not needed when multitargeting -->
    <Target Name="ValidateWinUIPlatform" />
    <Target Name="BinPlaceBootstrapDll" />
  </Project>
  ```
- Luego se actualizara el ``main project``, en nuestro caso ``ArtAuction.sln``, colocandole lo siguiente :
  ```C#
  Microsoft Visual Studio Solution File, Format Version 12.00
  # Visual Studio Version 17
  VisualStudioVersion = 17.2.32329.656
  MinimumVisualStudioVersion = 10.0.40219.1
  Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "ArtAuction.Android", "ArtAuction.Android\ArtAuction.Android.csproj", "{E04C4F5F-DAB1-4E80-B587-A0F636C7AE20}"
  EndProject
  Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "ArtAuction.iOS", "ArtAuction.iOS\ArtAuction.iOS.csproj", "{75989C42-3D80-4DD0-8491-D4A236F59060}"
  EndProject
  Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "ArtAuction", "ArtAuction\ArtAuction.csproj", "{1DA2BE49-892A-4533-92BA-CDDA568441B8}"
  EndProject
  Global
    GlobalSection(SolutionConfigurationPlatforms) = preSolution
      Debug|Any CPU = Debug|Any CPU
      Debug|iPhone = Debug|iPhone
      Debug|iPhoneSimulator = Debug|iPhoneSimulator
      Release|Any CPU = Release|Any CPU
      Release|iPhone = Release|iPhone
      Release|iPhoneSimulator = Release|iPhoneSimulator
    EndGlobalSection
    GlobalSection(ProjectConfigurationPlatforms) = postSolution
      {E04C4F5F-DAB1-4E80-B587-A0F636C7AE20}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
      {E04C4F5F-DAB1-4E80-B587-A0F636C7AE20}.Debug|Any CPU.Build.0 = Debug|Any CPU
      {E04C4F5F-DAB1-4E80-B587-A0F636C7AE20}.Debug|Any CPU.Deploy.0 = Debug|Any CPU
      {E04C4F5F-DAB1-4E80-B587-A0F636C7AE20}.Debug|iPhone.ActiveCfg = Debug|Any CPU
      {E04C4F5F-DAB1-4E80-B587-A0F636C7AE20}.Debug|iPhone.Build.0 = Debug|Any CPU
      {E04C4F5F-DAB1-4E80-B587-A0F636C7AE20}.Debug|iPhoneSimulator.ActiveCfg = Debug|Any CPU
      {E04C4F5F-DAB1-4E80-B587-A0F636C7AE20}.Debug|iPhoneSimulator.Build.0 = Debug|Any CPU
      {E04C4F5F-DAB1-4E80-B587-A0F636C7AE20}.Release|Any CPU.ActiveCfg = Release|Any CPU
      {E04C4F5F-DAB1-4E80-B587-A0F636C7AE20}.Release|Any CPU.Build.0 = Release|Any CPU
      {E04C4F5F-DAB1-4E80-B587-A0F636C7AE20}.Release|iPhone.ActiveCfg = Release|Any CPU
      {E04C4F5F-DAB1-4E80-B587-A0F636C7AE20}.Release|iPhone.Build.0 = Release|Any CPU
      {E04C4F5F-DAB1-4E80-B587-A0F636C7AE20}.Release|iPhoneSimulator.ActiveCfg = Release|Any CPU
      {E04C4F5F-DAB1-4E80-B587-A0F636C7AE20}.Release|iPhoneSimulator.Build.0 = Release|Any CPU
      {75989C42-3D80-4DD0-8491-D4A236F59060}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
      {75989C42-3D80-4DD0-8491-D4A236F59060}.Debug|iPhone.ActiveCfg = Debug|iPhone
      {75989C42-3D80-4DD0-8491-D4A236F59060}.Debug|iPhone.Build.0 = Debug|iPhone
      {75989C42-3D80-4DD0-8491-D4A236F59060}.Debug|iPhoneSimulator.ActiveCfg = Debug|iPhoneSimulator
      {75989C42-3D80-4DD0-8491-D4A236F59060}.Debug|iPhoneSimulator.Build.0 = Debug|iPhoneSimulator
      {75989C42-3D80-4DD0-8491-D4A236F59060}.Release|Any CPU.ActiveCfg = Release|iPhoneSimulator
      {75989C42-3D80-4DD0-8491-D4A236F59060}.Release|Any CPU.Build.0 = Release|iPhoneSimulator
      {75989C42-3D80-4DD0-8491-D4A236F59060}.Release|iPhone.ActiveCfg = Release|iPhone
      {75989C42-3D80-4DD0-8491-D4A236F59060}.Release|iPhone.Build.0 = Release|iPhone
      {75989C42-3D80-4DD0-8491-D4A236F59060}.Release|iPhoneSimulator.ActiveCfg = Release|iPhoneSimulator
      {75989C42-3D80-4DD0-8491-D4A236F59060}.Release|iPhoneSimulator.Build.0 = Release|iPhoneSimulator
      {1DA2BE49-892A-4533-92BA-CDDA568441B8}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
      {1DA2BE49-892A-4533-92BA-CDDA568441B8}.Debug|Any CPU.Build.0 = Debug|Any CPU
      {1DA2BE49-892A-4533-92BA-CDDA568441B8}.Debug|iPhone.ActiveCfg = Debug|Any CPU
      {1DA2BE49-892A-4533-92BA-CDDA568441B8}.Debug|iPhone.Build.0 = Debug|Any CPU
      {1DA2BE49-892A-4533-92BA-CDDA568441B8}.Debug|iPhoneSimulator.ActiveCfg = Debug|Any CPU
      {1DA2BE49-892A-4533-92BA-CDDA568441B8}.Debug|iPhoneSimulator.Build.0 = Debug|Any CPU
      {1DA2BE49-892A-4533-92BA-CDDA568441B8}.Release|Any CPU.ActiveCfg = Release|Any CPU
      {1DA2BE49-892A-4533-92BA-CDDA568441B8}.Release|Any CPU.Build.0 = Release|Any CPU
      {1DA2BE49-892A-4533-92BA-CDDA568441B8}.Release|iPhone.ActiveCfg = Release|Any CPU
      {1DA2BE49-892A-4533-92BA-CDDA568441B8}.Release|iPhone.Build.0 = Release|Any CPU
      {1DA2BE49-892A-4533-92BA-CDDA568441B8}.Release|iPhoneSimulator.ActiveCfg = Release|Any CPU
      {1DA2BE49-892A-4533-92BA-CDDA568441B8}.Release|iPhoneSimulator.Build.0 = Release|Any CPU
    EndGlobalSection
    GlobalSection(SolutionProperties) = preSolution
      HideSolutionNode = FALSE
    EndGlobalSection
    GlobalSection(ExtensibilityGlobals) = postSolution
      SolutionGuid = {1E1A31A5-EF70-4755-AC9A-884C60282102}
    EndGlobalSection
  EndGlobal
  ```
- Quedando de la siguiente manera:

  ![screen2](https://cdn.discordapp.com/attachments/894620271275827302/1069995731601068124/image.png)

## Paso 2
---
## Paso 3
---
## Paso 4
---