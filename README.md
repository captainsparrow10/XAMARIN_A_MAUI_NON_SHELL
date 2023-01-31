# Migracion de Xamarin.Forms a MAUI

### Proyecto Migrado

---

# Guia

---

- Proyecto usado de ejemplo [ArtAuction App Sin Migrar (non-Shell)](https://github.com/Sweekriti91/ArtAuction/tree/main)
- Proyecto completamente migrado [ArtAuction App Migrado (non-Shell)](https://github.com/Sweekriti91/ArtAuction/tree/maui-projecthead)

## Paso 1: reconocimiento de los dispositivos en MAUI

---

A la hora de pasar `Xamarin.Forms` a `MAUI`, se pierde el reconocimiento de los dispositivos. Esto se arregla de la siguiente manera:

- Se va a la carpeta fuera del proyecto, la que contiene los tres proyectos:

  ![screen1](https://cdn.discordapp.com/attachments/894620271275827302/1069994064411381881/image.png)

- Se crea un archivo llamado `Directory.Build.targets` y se le colocara lo siguiente:

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

- Luego se actualizara el `main project`, en nuestro caso `ArtAuction.sln`, colocandole lo siguiente :
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

## Paso 2: Actualización de los archivos csproj

---

- Iremos a la carpeta principal, en nuestro caso `ArtAction`, la que deberia verse de la siguiente manera:

  ![screen3](https://cdn.discordapp.com/attachments/894620271275827302/1069997298932793355/image.png)

- Iremos al archivo que contenga el `.csproj` de la carpeta, y lo reemplazaremos por lo siguiente:
  ```C#
  <Project Sdk="Microsoft.NET.Sdk">
    <PropertyGroup>
      <TargetFrameworks>net6.0-ios;net6.0-android</TargetFrameworks>
      <UseMaui>True</UseMaui>
      <OutputType>Library</OutputType>
      <ImplicitUsings>enable</ImplicitUsings>
      <!-- Required for C# Hot Reload -->
      <UseInterpreter Condition="'$(Configuration)' == 'Debug'">True</UseInterpreter>
      <SupportedOSPlatformVersion Condition="'$(TargetFramework)' == 'net6.0-ios'">15.4</SupportedOSPlatformVersion>
      <SupportedOSPlatformVersion Condition="'$(TargetFramework)' == 'net6.0-android'">31.0</SupportedOSPlatformVersion>
    </PropertyGroup>
    <ItemGroup>
      <MauiFont Include="Resources\*" />
    </ItemGroup>
  </Project>
  ```
- Haremos lo mismo, pero en sus respectivas plataforma `IOS` y `Android`

  - En `Android`, se reemplazara su contenido con lo siguiente:

    ```C#
    <Project Sdk="Microsoft.NET.Sdk">
      <PropertyGroup>
        <UseMaui>true</UseMaui>
        <TargetFramework>net6.0-android</TargetFramework>
        <OutputType>Exe</OutputType>
        <ImplicitUsings>enable</ImplicitUsings>
        <SupportedOSPlatformVersion Condition="'$(TargetFramework)' == 'net6.0-android'">31.0</SupportedOSPlatformVersion>
      </PropertyGroup>
      <PropertyGroup>
        <UseInterpreter Condition="$(TargetFramework.Contains('-android'))">True</UseInterpreter>
      </PropertyGroup>
      <ItemGroup>
        <AndroidResource Include="Resources\values\styles.xml" />
        <AndroidResource Include="Resources\values\colors.xml" />
        <AndroidResource Include="Resources\mipmap-anydpi-v26\icon.xml" />
        <AndroidResource Include="Resources\mipmap-anydpi-v26\icon_round.xml" />
        <AndroidResource Include="Resources\mipmap-hdpi\icon.png" />
        <AndroidResource Include="Resources\mipmap-hdpi\launcher_foreground.png" />
        <AndroidResource Include="Resources\mipmap-mdpi\icon.png" />
        <AndroidResource Include="Resources\mipmap-mdpi\launcher_foreground.png" />
        <AndroidResource Include="Resources\mipmap-xhdpi\icon.png" />
        <AndroidResource Include="Resources\mipmap-xhdpi\launcher_foreground.png" />
        <AndroidResource Include="Resources\mipmap-xxhdpi\icon.png" />
        <AndroidResource Include="Resources\mipmap-xxhdpi\launcher_foreground.png" />
        <AndroidResource Include="Resources\mipmap-xxxhdpi\icon.png" />
        <AndroidResource Include="Resources\mipmap-xxxhdpi\launcher_foreground.png" />
      </ItemGroup>
      <ItemGroup>
        <ProjectReference Include="..\ArtAuction\ArtAuction.csproj">
          <Project>{1DA2BE49-892A-4533-92BA-CDDA568441B8}</Project>
          <Name>ArtAuction</Name>
        </ProjectReference>
      </ItemGroup>
    </Project>
    ```

  - En `IOS`, se reemplazara su contenido con lo siguiente:
    ```C#
    <Project Sdk="Microsoft.NET.Sdk">
      <PropertyGroup>
        <UseMaui>true</UseMaui>
        <TargetFramework>net6.0-ios</TargetFramework>
        <OutputType>Exe</OutputType>
        <ImplicitUsings>enable</ImplicitUsings>
      </PropertyGroup>
      <!-- <ItemGroup>
        <InterfaceDefinition Include="Resources\LaunchScreen.storyboard" />
      </ItemGroup> -->
      <ItemGroup>
        <ProjectReference Include="..\ArtAuction\ArtAuction.csproj">
          <Project>{1DA2BE49-892A-4533-92BA-CDDA568441B8}</Project>
          <Name>ArtAuction</Name>
        </ProjectReference>
      </ItemGroup>
    </Project>
    ```

## Paso 3: Actualizar el codigo

---

Aqui empezaremos a reemplazar todo lo que tenga que ver con `Xamarin.Forms` a `MAUI`

- Iremos a la carpeta principal de nuevo, para volver a cambiar algunas cosas, por si acaso no recuerdan cual es, es esta:

  ![screen4](https://cdn.discordapp.com/attachments/894620271275827302/1069997298932793355/image.png)

- Dentro de la carpeta `ArtAuction`, crearemos el archivo `MauiProgram.cs` y pegaremos lo siguiente:
  ```C#
  namespace ArtAuction;
  public static class MauiProgram
  {
    public static MauiApp CreateMauiApp()
    {
      var builder = MauiApp.CreateBuilder();
      builder
        .UseMauiApp<App>()
        .ConfigureFonts(fonts =>
        {
          fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
        });
      return builder.Build();
    }
  }
  ```
- Dentro de la carpeta `ArtAuction.Android`, crearemos el archivo `MainProgram.cs` y pegaremos lo siguiente:

  ```C#
  using System;
  using Android.App;
  using Android.Runtime;
  using Microsoft.Maui;
  using Microsoft.Maui.Hosting;
  using ArtAuction;

  namespace ArtAuction.Droid
  {

    [Application]
    public class MainApplication : MauiApplication
    {
      public MainApplication(IntPtr handle, JniHandleOwnership ownership)
        : base(handle, ownership)
      {
      }
      protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
  }
  ```

- Dentro de la anterior mencionada, modificaremos el archivo `MainActivity.cs`
  ```C#
  using System;
  using Microsoft.Maui;
  using Android.App;
  using Android.Content.PM;
  using Android.Runtime;
  using Android.OS;
  namespace ArtAuction.Droid
  {
      [Activity(Label = "ArtAuction", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
      public class MainActivity : MauiAppCompatActivity
    {
      protected override void OnCreate(Bundle savedInstanceState)
      {
        base.OnCreate(savedInstanceState);
      }
    }
  }
  ```
- Dentro de la anterior mencionada, iremos a su carpeta `Properties`, en el archivo `AndroidManifest` y cambiaremos lo siguiente `android:targetSdkVersion="31"`
- Ahora nos vamos a la carpeta `ArtAuction.iOS`, al archivo `AppDelegate.cs` y pegaremos lo siguiente:
  ```C#
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using Microsoft.Maui;
  using Foundation;
  using UIKit;
  using ArtAuction;
  namespace ArtAuction.iOS
  {
    [Register("AppDelegate")]
    public partial class AppDelegate : MauiUIApplicationDelegate
      {
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
      }
  }
  ```
- En la Carpeta de IOS, iremos al archivo `Info.plist` y cambiaremos `MinimumOSVersion` a `15.2`.
- En cada carpeta main, hay un archivo `AssemblyInfo.cs`, en `IOS` y `Android` se encuentra en `properties`.

  - En `IOS` se colocara lo siguiente en ella:

    ```C#
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    [assembly: ComVisible(false)]
    [assembly: Guid("72bdc44f-c588-44f3-b6df-9aace7daafdd")]
    ```

  - En `Android`, se borrara `AssemblyInfo.cs` y tambien `Resource.designer.cs` que se encuentra en la carpeta `Resources`.
  - En la carpeta main, se dejara el archivo `AssemblyInfo.cs`, de la siguiente manera: 
    ```C#
    using Microsoft.Maui.Controls.Xaml;
    [assembly: XamlCompilation(XamlCompilationOptions.Compile)]
    ```
- Aqui se usara el buscador en el editor de codigo y se actualizara las siguientes por las nuevas:

  | namespace a reemplazar  | namespace nuevos|
  | ------------- | ------------- |
  | ``xmlns="http://xamarin.com/schemas/2014/forms"``  | ``xmlns="http://schemas.microsoft.com/dotnet/2021/maui"``  |
  | ``using Xamarin.Forms`` | ``using Microsoft.Maui y using Microsoft.Maui.Controls`` |
   | ``using Xamarin.Forms.Xaml``| ``using Microsoft.Maui.Controls.Xaml``  |
- Actualizar el XAML de ``XAMARIN`` a ``MAUI``, en este caso
  ```C#
  <?xml version="1.0" encoding="utf-8"?>
  <ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui" xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml" xmlns:ios="clr-namespace:Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;assembly=Microsoft.Maui.Controls" ios:Page.UseSafeArea="True" x:Class="ArtAuction.MainPage" BackgroundColor="#f7f4fa">
    <Grid Padding="10,0,10,0">
      <Grid.RowDefinitions>
        <RowDefinition Height="0.05*"/>
        <RowDefinition Height="0.05*"/>
        <RowDefinition Height="0.5*"/>
        <RowDefinition Height="0.05*"/>
        <RowDefinition Height="0.45*"/>
      </Grid.RowDefinitions>
      <Label Text="Live Auctions" Grid.Row="0" FontAttributes="Bold" FontSize="Large"/>

      <ScrollView Orientation="Horizontal" Grid.Row="1">
        <StackLayout x:Name="CategoriesCollection" Orientation="Horizontal">
          <BindableLayout.ItemTemplate>
            <DataTemplate>
              <Frame Margin="4,2,4,2" Padding="10,4,10,4" HasShadow="False">
                <Label Text="{Binding .}" TextColor="Green" FontAttributes="Bold"/>
              </Frame>
            </DataTemplate>
          </BindableLayout.ItemTemplate>
        </StackLayout>
      </ScrollView>

      <ScrollView Orientation="Horizontal" Grid.Row="2" Padding="10">
        <StackLayout x:Name="FeaturedAuctions" Orientation="Horizontal">
          <BindableLayout.ItemTemplate>
            <DataTemplate>
              <StackLayout>
                <Label Text="{Binding Name}" FontAttributes="Bold" HorizontalTextAlignment="Start"/>
                <Frame Padding="1" Margin="4" BackgroundColor="Gray">
                  <Grid>
                    <Grid.RowDefinitions>
                      <RowDefinition Height="0.9*"/>
                      <RowDefinition Height="0.13*"/>
                      <RowDefinition Height="0.05*"/>
                    </Grid.RowDefinitions>
                    <Label Text="{Binding DaysLeft}" FontAttributes="Bold" HorizontalTextAlignment="Center"/>
                    <Image Source="{Binding Image}" VerticalOptions="Fill" Aspect="AspectFill" Grid.RowSpan="3"/>
                    <Frame Margin="4,2,4,2" Padding="10,4,10,4" HasShadow="False" BackgroundColor="#1bda5d" Grid.Row="1" HorizontalOptions="Center">
                      <Label Text="{Binding DaysLeft}" FontAttributes="Bold" HorizontalTextAlignment="Center"/>
                    </Frame>
                  </Grid>
                </Frame>
              </StackLayout>
            </DataTemplate>
          </BindableLayout.ItemTemplate>
        </StackLayout>
      </ScrollView>

      <Label Text="Top Sellers" Grid.Row="3" FontAttributes="Bold" FontSize="Large"/>
      <CollectionView x:Name="SellersCollection" Grid.Row="4">
        <CollectionView.ItemTemplate>
          <DataTemplate>
            <Grid HeightRequest="80">
              <Grid.ColumnDefinitions>
                <ColumnDefinition Width="0.2*"/>
                <ColumnDefinition Width="0.7*"/>
                <ColumnDefinition Width="0.15*"/>

              </Grid.ColumnDefinitions>
              <Grid.RowDefinitions>
                <RowDefinition Height="0.5*"/>
                <RowDefinition Height="0.5*"/>

              </Grid.RowDefinitions>

              <Image Source="{Binding Image}" Grid.Column="0" Grid.RowSpan="2" Aspect="AspectFill" VerticalOptions="Center" HeightRequest="70" WidthRequest="70">
                <Image.Clip>
                  <EllipseGeometry RadiusX="30" RadiusY="30" Center="30,30"/>
                </Image.Clip>
              </Image>

              <Label Text="{Binding Name}" Grid.Column="1" Grid.Row="0" FontAttributes="Bold" HorizontalOptions="Fill" VerticalTextAlignment="End"/>
              <Label Grid.Column="1" Grid.Row="1" Text="{Binding SoldValueBTC}" VerticalTextAlignment="Start" TextColor="Gray"/>

              <Image Source="https://upload.wikimedia.org/wikipedia/commons/thumb/c/c0/Eo_circle_green_arrow-up.svg/1024px-Eo_circle_green_arrow-up.svg.png" Grid.Column="2" Grid.RowSpan="2" HeightRequest="20" WidthRequest="20" Aspect="AspectFit"/>
            </Grid>
          </DataTemplate>
        </CollectionView.ItemTemplate>
      </CollectionView>
    </Grid>
  </ContentPage>
  ```
## Paso 4: Actualizacion de los nugets

---
- Eliminar ``Xamarin.Forms`` y ``Xamarin.Essentials `` de las nuget references.
- Reemplazar ``Xamarin.Community Toolkit`` con la ultima versión de ``.NET MAUI Community Toolkit``
- Reemplazar ``SkiaSharp`` con su ultima versión:
  - [SkiaSharp.Views.Maui.Controls](https://www.nuget.org/packages/SkiaSharp.Views.Maui.Controls/2.88.0-preview.232)
  - [SkiaSharp.Views.Maui.Core](https://www.nuget.org/packages/SkiaSharp.Views.Maui.Core/2.88.0-preview.232)
  - [SkiaSharp.Views.Maui.Controls.Compatibility](https://www.nuget.org/packages/SkiaSharp.Views.Maui.Controls.Compatibility/2.88.0-preview.232)