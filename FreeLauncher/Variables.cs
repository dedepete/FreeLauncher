using System;
using System.IO;
using System.Windows.Forms;
using CommandLine;
using Newtonsoft.Json;

namespace FreeLauncher
{
    public static class Variables
    {
        public static Arguments ProgramArguments = new Arguments();
        public static Localization ProgramLocalization = new Localization();

        public static string McDirectory = ProgramArguments.WorkingDirectory ?? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".minecraft\\");
        public static string McLauncher = Path.Combine(McDirectory, "freelauncher\\");
        public static string McVersions = Path.Combine(McDirectory, "versions\\");
        public static string McLibs = Path.Combine(McDirectory, "libraries\\");

        public static string LastSnapshotVersion = "15w33c";
        public static string LastReleaseVersion = "1.8.8";

        public static string Libraries = string.Empty;
    }

    public class Arguments
    {
        [Option('d', "working-directory")]
        public string WorkingDirectory { get; set; }
        [Option("not-a-standalone")]
        public bool NotAStandalone { get; set; }
    }

    //TODO: Localization
    public class Localization
    {
        public string Name = "Русский";
        public string LanguageTag = "ru-RU";
        public string Authors = "dedepete";

        #region LauncherForm

        #region Tabs

        public string NewsTabText = "НОВОСТИ";
        public string ConsoleTabText = "КОНСОЛЬ";
        public string ManageVersionsTabText = "УПРАВЛЕНИЕ ВЕРСИЯМИ";
        public string AboutTabText = "О ЛАУНЧЕРЕ";
        public string LicensesTabText = "ЛИЦЕНЗИИ";
        public string SettingsTabText = "НАСТРОЙКИ";

        #endregion

         #region Main Controls

        public string LaunchButtonText = "Запуск игры";
        public string AddProfileButtonText = "Добавить профиль";
        public string EditProfileButtonText = "Изменить профиль";

        #endregion

         #region About Tab

        public string DevInfo = "Разработано dedepete из Space Earth Studio Minecraft\nИздано Space Earth Studio";
        public string GratitudesText = "Благодарности";
        public string GratitudesDescription = "Большое спасибо администрации портала ru-minecraft.ru за содействие в развитии проекта!";
        public string PartnersText = "Партнёры";
        public string MCofflineDescription = "MCoffline - лучшая программа для серверных администраторов!";
        public string CopyrightInfo = "\"SESMC\" расшифровывается как Space Earth Studio Minecraft. Все права защищены святой водой.\n\"Minecraft\" является торговой маркой Mojang AB. Все права защищены.\nMojang AB является дочерней студией Microsoft Studios.";

         #endregion

         #region Settings Tab

        public string EnableMinecraftUpdateAlertsText = "Показывать уведомления о наличии новых версий Minecraft";
        public string EnableMinecraftLoggingText = "Выводить лог игры в консоль";
        public string UseGamePrefixText = "Использовать префикс [GAME] для логов Minecraft";
        public string CloseGameOutputText = "Закрывать вкладку, если завершение было вызвано\nпринудительно или прошло без ошибок";

        #endregion

        public string Launch = "Запустить";
        public string OpenLocation = "Открыть расположение";
        public string DeleteVersion = "Удалить версию";
        public string DeleteConfirmationTitle = "Подтверждение удаления";
        public string DeleteConfirmationText = "Вы действительно хотите удалить версию {0}?";
        public string ReadyToLaunch = "Готов к запуску версии {0}";
        public string ReadyToDownload = "Готов к загрузке версии {0}";
        public string EditingProfileTitle = "Редактирование профиля";
        public string Error = "Ошибка";
        public string ProfileAlreadyExistsErrorText = "Данный профиль уже существует в списке!";
        public string ProfileDeleteConfirmationText = "Вы действительно хотите удалить профиль '{0}'?";
        public string AddingProfileTitle = "Добавление профиля";
        public string CheckingVersionAvailability = "Выполняется проверка доступности версии '{0}'";
        public string CheckingLibraries = "Выполняется проверка библиотек";
        public string GameOutput = "ВЫВОД ИГРЫ";
        public string Close = "Закрыть";
        public string KillProcess = "Убить процесс";
        public string Independent = "Независимая";

        #endregion
    }
}
