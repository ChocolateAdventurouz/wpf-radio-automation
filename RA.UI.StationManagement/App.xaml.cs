﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MySqlConnector;
using RA.DAL;
using RA.Database;
using RA.UI.Core.Factories;
using RA.UI.Core.Services;
using RA.UI.Core.Services.Interfaces;
using RA.UI.Core;
using RA.UI.StationManagement.Components.MediaLibrary.ViewModels;
using RA.UI.StationManagement.Components.MediaLibrary.ViewModels.ImportItems;
using RA.UI.StationManagement.Components.MediaLibrary.ViewModels.MainContent;
using RA.UI.StationManagement.Components.MediaLibrary.Views;
using RA.UI.StationManagement.Components.MediaLibrary.Views.ImportItems;
using RA.UI.StationManagement.Components.MediaLibrary.Views.MainContent;
using RA.UI.StationManagement.Components.Planner.View.Clocks;
using RA.UI.StationManagement.Components.Planner.Views.MainContent;
using RA.UI.StationManagement.Components.Planner.View.Schedule;
using RA.UI.StationManagement.Components.Planner.ViewModels;
using RA.UI.StationManagement.Components.Planner.ViewModels.Clocks;
using RA.UI.StationManagement.Components.Planner.ViewModels.MainContent;
using RA.UI.StationManagement.Components.Planner.ViewModels.Schedule;
using RA.UI.StationManagement.Components.Planner.Views;
using RA.UI.StationManagement.Dialogs.CategorySelectDialog;
using RA.UI.StationManagement.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using RA.UI.Core.Themes;
using RA.UI.StationManagement.Components.Planner.View.Templates;
using RA.UI.StationManagement.Components.Planner.ViewModels.Templates;
using RA.UI.StationManagement.Components.Planner.Views.Schedule;
using RA.UI.StationManagement.Components.Planner.ViewModels.Playlists;
using RA.UI.StationManagement.Components.Planner.View.Playlists;
using RA.UI.StationManagement.Components.MediaLibrary.ViewModels.Categories;
using RA.UI.StationManagement.Components.MediaLibrary.Views.Categories;
using RA.UI.StationManagement.Dialogs.TrackSelectDialog;
using RA.UI.StationManagement.Dialogs.TemplateSelectDialog;
using RA.Logic.TrackFileLogic;
using RA.UI.StationManagement.Dialogs.ArtistSelectDialog;
using RA.UI.StationManagement.Components.Planner.Views.Templates;
using RA.Logic.PlanningLogic;
using RA.UI.StationManagement.Components.Planner.Views.Clocks;
using RA.UI.StationManagement.Components.Reports.ViewModels;
using RA.UI.StationManagement.Components.Reports.Views;
using RA.UI.StationManagement.Components.Settings.ViewModels;
using RA.UI.StationManagement.Components.Settings.Views;
using RA.UI.Core.Shared.DatabaseConfiguration;

namespace RA.UI.StationManagement
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost? AppHost { get; private set; }
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTc3ODYwNUAzMjMxMmUzMTJlMzMzNWc2NlM4V1ZTSm9xU0htNmhzSE1GZDBicktpMWZKY1VoaHdMb3pSaWhmclU9");


            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddDbContextFactory<AppDbContext>(options =>
                    {
                        String connString = "server=localhost;Port=3306;database=ratest;user=roo;password=";
                        options.UseMySql(connString, ServerVersion.AutoDetect(connString))
                            .EnableSensitiveDataLogging(false);
                    });



                    services.AddSingleton<IWindowService, WindowService>();
                    services.AddSingleton<IViewModelFactory, ViewModelFactory>();

                    services.AddSingleton<IFolderBrowserDialogService, FolderBrowserDialogService>();
                    services.AddSingleton<IFileBrowserDialogService, FileBrowserDialogService>();
                    services.AddSingleton<IMessageBoxService, MessageBoxService>();
                    services.AddSingleton<IDispatcherService, WpfDispatcherService>();

                    //Navigation services
                    services.AddScoped<INavigationService<MediaLibraryMainViewModel>,
                        NavigationService<MediaLibraryMainViewModel>>();

                    services.AddTransient<INavigationService<MediaLibraryImportItemsViewModel>,
                        NavigationService<MediaLibraryImportItemsViewModel>>();

                    services.AddScoped<MediaLibraryTreeMenuService>();

                    #region DAL services
                    services.AddTransient<IClocksService, ClocksService>();
                    services.AddTransient<ICategoriesService, CategoriesService>();
                    services.AddTransient<ITracksService, TracksService>();
                    services.AddTransient<ITemplatesService, TemplatesService>();
                    services.AddTransient<ICategoriesService, CategoriesService>();
                    services.AddTransient<ITagsService, TagsService>();
                    services.AddTransient<ISchedulesDefaultService, SchedulesDefaultService>();
                    services.AddTransient<IArtistsService, ArtistsService>();
                    services.AddTransient<ISchedulesService, SchedulesService>();
                    services.AddTransient<ISchedulesPlannedService, SchedulesPlannedService>();
                    services.AddTransient<IPlaylistsService, PlaylistsService>();
                    #endregion

                    #region Logic services
                    services.AddTransient<ITrackFilesImporter,TrackFileImporter>();
                    services.AddTransient<ITrackFilesProcessor, TrackFilesProcessor>();
                    services.AddTransient<IPlaylistGenerator, PlaylistGenerator>();
                    #endregion

                    #region Register window factory
                    Dictionary<Type, Type> viewModelToSingletonWindowMap = new();
                    Dictionary<Type, Type> viewModelToTransientWindowMap = new();
                    services.AddSingleton<IWindowFactory>(provider =>
                        new WindowFactory(
                            viewModelToSingletonWindowMap,
                            viewModelToTransientWindowMap,
                            AppHost!.Services
                        )
                    );
                    #endregion

                    #region Singleton viewModel <=> View
                    viewModelToSingletonWindowMap.Add(typeof(AuthViewModel), typeof(AuthWindow));
                    viewModelToSingletonWindowMap.Add(typeof(LauncherViewModel), typeof(LauncherWindow));
                    viewModelToSingletonWindowMap.Add(typeof(DatabaseConfigurationViewModel), typeof(DatabaseConfigurationWindow));

                    //Register the viewmodel&view
                    foreach (KeyValuePair<Type, Type> vmAndView in viewModelToSingletonWindowMap)
                    {
                        //Key: ViewModel, //Value: View
                        //Register viewmodel
                        services.AddSingleton(vmAndView.Key);
                        //Register view
                        services.AddTransient(vmAndView.Value, provider =>
                        {
                            var viewModel = provider.GetRequiredService(vmAndView.Key);
                            var window = (Window)Activator.CreateInstance(vmAndView.Value)!;
                            window.DataContext = viewModel;
                            return window;
                        });
                    }
                    #endregion

                    #region Transient ViewModel <=> View
                    #region Media Library
                    viewModelToTransientWindowMap.Add(typeof(MediaLibraryMainViewModel), typeof(MediaLibraryMainWindow));
                    viewModelToTransientWindowMap.Add(typeof(MediaLibraryImportItemsViewModel), typeof(MediaLibraryImportItemsWindow));

                    #region Media Library Components
                    viewModelToTransientWindowMap.Add(typeof(AllMediaItemsViewModel), typeof(AllMediaItemsView));
                    viewModelToTransientWindowMap.Add(typeof(ArtistsViewModel), typeof(ArtistsView));
                    viewModelToTransientWindowMap.Add(typeof(CategoriesViewModel), typeof(CategoriesView));
                    viewModelToTransientWindowMap.Add(typeof(CategoryItemsViewModel), typeof(CategoryItemsView));
                    viewModelToTransientWindowMap.Add(typeof(TagsViewModel), typeof(TagsView));
                    #endregion


                    viewModelToTransientWindowMap.Add(typeof(ImportItemsFirstViewModel), typeof(ImportItemsFirstView));
                    viewModelToTransientWindowMap.Add(typeof(ImportItemsSecondViewModel), typeof(ImportItemsSecondView));
                    viewModelToTransientWindowMap.Add(typeof(ImportItemsThirdViewModel), typeof(ImportItemsThirdView));

                    viewModelToTransientWindowMap.Add(typeof(MediaLibraryManageTrackViewModel), typeof(MediaLibraryManageTrackWindow));

                    viewModelToTransientWindowMap.Add(typeof(MediaLibraryManageCategoryViewModel), typeof(MediaLibraryManageCategoryWindow));
                    #endregion

                    #region Planner
                    viewModelToTransientWindowMap.Add(typeof(PlannerMainViewModel), typeof(PlannerMainWindow));
                    viewModelToTransientWindowMap.Add(typeof(PlannerClocksViewModel), typeof(PlannerClocksView));
                    viewModelToTransientWindowMap.Add(typeof(PlannerDayTemplatesViewModel), typeof(PlannerDayTemplatesView));
                    viewModelToTransientWindowMap.Add(typeof(PlannerScheduleViewModel), typeof(PlannerScheduleView));
                    viewModelToTransientWindowMap.Add(typeof(PlannerScheduleCalendarViewModel), typeof(PlannerScheduleView));
                    viewModelToTransientWindowMap.Add(typeof(PlannerDefaultScheduleViewModel), typeof(PlannerDefaultScheduleView));
                    viewModelToTransientWindowMap.Add(typeof(PlannerPlaylistsViewModel), typeof(PlannerPlaylistsView));

                    viewModelToTransientWindowMap.Add(typeof(PlannerManageClockCategoryRuleViewModel), typeof(PlannerManageClockCategoryRuleDialog));
                    viewModelToTransientWindowMap.Add(typeof(PlannerManageClockEventRuleViewModel), typeof(PlannerManageClockEventRuleDialog));
                    viewModelToTransientWindowMap.Add(typeof(PlannerManageClockViewModel), typeof(PlannerManageClockDialog));

                    viewModelToTransientWindowMap.Add(typeof(PlannerManageTemplateViewModel), typeof(PlannerManageTemplateDialog));
                    viewModelToTransientWindowMap.Add(typeof(PlannerManageScheduleItemViewModel), typeof(PlannerManageScheduleItemDialog));

                    viewModelToTransientWindowMap.Add(typeof(PlannerGeneratePlaylistsViewModel), typeof(PlannerGeneratePlaylistsWindow));

                    viewModelToTransientWindowMap.Add(typeof(PlannerTemplateSelectClockViewModel), typeof(PlannerTemplateSelectClockWindow));



                    #endregion

                    #region Reports
                    viewModelToTransientWindowMap.Add(typeof(ReportsMainViewModel), typeof(ReportsMainWindow));
                    #endregion

                    #region Settings
                    viewModelToTransientWindowMap.Add(typeof(SettingsMainViewModel), typeof(SettingsMainWindow));
                    #endregion
                    #region Dialogs
                    viewModelToTransientWindowMap.Add(typeof(CategorySelectViewModel), typeof(CategorySelectDialog));
                    viewModelToTransientWindowMap.Add(typeof(TrackSelectViewModel), typeof(TrackSelectDialog));
                    viewModelToTransientWindowMap.Add(typeof(TemplateSelectViewModel), typeof(TemplateSelectDialog));
                    viewModelToTransientWindowMap.Add(typeof(ArtistSelectViewModel),typeof(ArtistSelectDialog));
                    #endregion



                    foreach (KeyValuePair<Type, Type> vmAndView in viewModelToTransientWindowMap)
                    {
                        services.AddTransient(vmAndView.Key);
                        services.AddTransient(vmAndView.Value);
                    }
                    #endregion
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost!.StartAsync();
            StartApp();
            base.OnStartup(e);
        }

        private void StartApp()
        {
            ThemeManager.SetTheme(ThemeType.Light);

            var windowService = AppHost!.Services.GetRequiredService<IWindowService>();
            var dispatcherService = AppHost!.Services.GetRequiredService<IDispatcherService>();

            SplashScreenWindow splashScreen = new SplashScreenWindow();
            splashScreen.Show();

            var testDatabaseTask = Task.Run(() =>
            {
                if (!CanConnectToDatabase())
                {
                    dispatcherService.InvokeOnUIThread(() =>
                    {
                        Application.Current.Shutdown();
                    });
                }
            });

            var loadComponents = Task.Run(async () =>
            {
                //Load any components you need 
                await Task.Delay(1400);
            });

            Task.WhenAll(testDatabaseTask, loadComponents).ContinueWith(t =>
            {
                dispatcherService.InvokeOnUIThread(() =>
                {
                    windowService.ShowWindow<AuthViewModel>();
                    splashScreen.Hide();
                });
            });
            

        }

        private bool CanConnectToDatabase()
        {
            var messageBoxService = AppHost!.Services.GetRequiredService<IMessageBoxService>();
            try
            {
                IDbContextFactory<AppDbContext> dbContextFactory = AppHost!.Services.GetRequiredService<IDbContextFactory<AppDbContext>>();
                var dbContext = dbContextFactory.CreateDbContext();
                return true;
            }
            catch (MySqlException ex)
            {
                messageBoxService.ShowError($"Failed to connect to the database: {ex.Message}");
                return false;
            }

        }
        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost!.StopAsync();
            base.OnExit(e);
        }
    }
}
